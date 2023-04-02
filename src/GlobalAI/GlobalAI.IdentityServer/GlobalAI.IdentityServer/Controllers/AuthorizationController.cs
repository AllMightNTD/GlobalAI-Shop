﻿using GlobalAI.CoreDomain.Interfaces;
using GlobalAI.IdentitiyServerEntities.Dto;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OpenIddict.Abstractions;
using OpenIddict.Server.AspNetCore;
using System.Collections.Immutable;
using System.Security.Claims;
using static OpenIddict.Abstractions.OpenIddictConstants;

namespace GlobalAI.IdentityServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorizationController : ControllerBase
    {
        private readonly IOpenIddictApplicationManager _applicationManager;
        private readonly IUserServices _userServices;

        public AuthorizationController(IOpenIddictApplicationManager applicationManager, IUserServices userServices)
        {
            _applicationManager = applicationManager;
            _userServices = userServices;
        }

        /// <summary>
        /// Đăng nhập password lấy token
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPost("~/connect/token"), IgnoreAntiforgeryToken, Produces("application/json"), Consumes("application/x-www-form-urlencoded")]
        public async Task<IActionResult> Exchange([FromForm] ConnectTokenDto dto)
        {
            var request = HttpContext.GetOpenIddictServerRequest();
            if (request.IsPasswordGrantType())
            {
                var user = _userServices.ValidateUser(dto.Username, dto.Password);

                if (user != null)
                {
                    // Create the claims-based identity that will be used by OpenIddict to generate tokens.
                    var identity = new ClaimsIdentity(
                        authenticationType: TokenValidationParameters.DefaultAuthenticationType,
                        nameType: Claims.Name,
                        roleType: Claims.Role
                    );

                    // Add the claims that will be persisted in the tokens.
                    identity.SetClaim(Claims.Username, user.Username)
                            .SetClaim(Claims.Subject, user.Username)
                            .SetAudiences(new string[] { "http://localhost:5002" })
                            .SetClaim(Claims.Email, user.Email)
                            .SetClaim(Claims.Name, $"{user.FirstName} {user.LastName}")
                            .SetClaims(Claims.Role, (new List<string> { user.UserType }).ToImmutableArray());

                    // Set the list of scopes granted to the client application.
                    identity.SetScopes(new[]
                    {
                        Scopes.OpenId,
                        Scopes.Email,
                        Scopes.Profile,
                        Scopes.Roles
                    }.Intersect(request.GetScopes()));

                    identity.SetDestinations(GetDestinations);

                    return SignIn(new ClaimsPrincipal(identity), OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
                }
                else
                {
                    throw new Exception("Tên đăng nhập hoặc mật khẩu không chính xác.");
                }
                
            }

            throw new NotImplementedException("The specified grant type is not implemented.");
        }

        private static IEnumerable<string> GetDestinations(Claim claim)
        {
            // Note: by default, claims are NOT automatically included in the access and identity tokens.
            // To allow OpenIddict to serialize them, you must attach them a destination, that specifies
            // whether they should be included in access tokens, in identity tokens or in both.

            switch (claim.Type)
            {
                case Claims.Name:
                    yield return Destinations.AccessToken;

                    if (claim.Subject.HasScope(Scopes.Profile))
                        yield return Destinations.IdentityToken;

                    yield break;

                case Claims.Email:
                    yield return Destinations.AccessToken;

                    if (claim.Subject.HasScope(Scopes.Email))
                        yield return Destinations.IdentityToken;

                    yield break;

                case Claims.Role:
                    yield return Destinations.AccessToken;

                    if (claim.Subject.HasScope(Scopes.Roles))
                        yield return Destinations.IdentityToken;

                    yield break;

                // Never include the security stamp in the access and identity tokens, as it's a secret value.
                case "AspNet.Identity.SecurityStamp": yield break;

                default:
                    yield return Destinations.AccessToken;
                    yield break;
            }
        }
    }
}