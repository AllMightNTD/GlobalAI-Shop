using GlobalAI.CoreDomain.Implements;
using GlobalAI.CoreDomain.Interfaces;
using GlobalAI.CoreEntities.Mapper;
using GlobalAI.DataAccess.Base;
using GlobalAI.Entites;
using GlobalAI.Utils.ConstantVariables.Shared;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OpenIddict.Validation.AspNetCore;
using PemUtils;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", false, true)
    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", true, true)
    .AddEnvironmentVariables();
var Configuration = builder.Configuration;
var services = builder.Services;

#region config db
string dbConnection = "GLOBALAI";

// Add services to the container.


string connectionString = Configuration.GetConnectionString(dbConnection);
services.AddDbContext<GlobalAIDbContext>(options =>
{
    // Configure Entity Framework Core to use Microsoft SQL Server.
    options.UseOracle(connectionString);
});
services.AddSingleton(new DatabaseOptions { ConnectionString = connectionString });
#endregion

#region config authen openiddict
// Register the signing and encryption credentials.
RsaSecurityKey key;

var path = Configuration.GetValue<string>("JwtKey");

using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
using (var reader = new PemReader(stream))
{
    key = new RsaSecurityKey(reader.ReadRsaKey());
}

// Register the OpenIddict validation components.
builder.Services.AddOpenIddict()
    .AddValidation(options =>
    {
        // Note: the validation handler uses OpenID Connect discovery
        // to retrieve the address of the introspection endpoint.
        options.SetIssuer("http://localhost:5001/");
        options.AddAudiences("http://localhost:5002");
        options.AddEncryptionKey(key);

        // Register the System.Net.Http integration.
        options.UseSystemNetHttp();

        // Register the ASP.NET Core host.
        options.UseAspNetCore();
    });

builder.Services.AddAuthentication(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme);
builder.Services.AddAuthorization();
#endregion

builder.Services.AddControllers();

#region config swagger 
services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = Assembly.GetExecutingAssembly().GetName().Name, Version = "v1" });

    option.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });

    option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = JwtBearerDefaults.AuthenticationScheme
                            }
                        },
                        Array.Empty<string>()
                    }
                });

    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    option.IncludeXmlComments(xmlPath);

});
#endregion

#region Add services
services.AddScoped<IUserServices, UserServices>();
services.AddScoped<IRoleServices, RoleServices>();
services.AddScoped<IPermissionServices, PermissionServices>();
services.AddScoped<IProvinceServices, ProvinceServices>();
#endregion

services.AddAutoMapper(typeof(CoreMappingProfile));
services.AddHttpContextAccessor();
services.AddAuthorization();

var app = builder.Build();

if (!builder.Environment.IsProduction())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", $"{Assembly.GetExecutingAssembly().GetName().Name} v1");
        options.DocExpansion(DocExpansion.None);
    });
}



// Configure the HTTP request pipeline.
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
