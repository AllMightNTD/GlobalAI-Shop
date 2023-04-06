﻿// <auto-generated />
using System;
using GlobalAI.DataAccess.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace GlobalAI.HostConsole.Migrations
{
    [DbContext(typeof(GlobalAIDbContext))]
    [Migration("20230405024538_catnhatdata")]
    partial class catnhatdata
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GlobalAI.CoreEntities.DataEntities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("USER_ID");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR2")
                        .HasColumnName("CREATED_BY");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("DATE")
                        .HasColumnName("CREATED_DATE");

                    b.Property<bool>("Deleted")
                        .HasColumnType("NUMBER(1)")
                        .HasColumnName("DELETED");

                    b.Property<string>("DeletedBy")
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR2")
                        .HasColumnName("DELETED_BY");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("DATE")
                        .HasColumnName("DELETED_DATE");

                    b.Property<string>("DisplayName")
                        .HasMaxLength(500)
                        .HasColumnType("VARCHAR2")
                        .HasColumnName("DISPLAY_NAME");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("VARCHAR2")
                        .HasColumnName("EMAIL");

                    b.Property<decimal?>("FailAttemp")
                        .HasColumnType("DECIMAL(18, 2)")
                        .HasColumnName("FAIL_ATTEMP");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("VARCHAR2")
                        .HasColumnName("FIRST_NAME");

                    b.Property<bool>("IsFirstTime")
                        .HasColumnType("NUMBER(1)")
                        .HasColumnName("IS_FIRST_TIME");

                    b.Property<bool>("IsTempPassword")
                        .HasColumnType("NUMBER(1)")
                        .HasColumnName("IS_TEMP_PASSWORD");

                    b.Property<bool>("IsVerifiedEmail")
                        .HasColumnType("NUMBER(1)")
                        .HasColumnName("IS_VERIFIED_EMAIL");

                    b.Property<DateTime?>("LastFailedLogin")
                        .HasColumnType("DATE")
                        .HasColumnName("LAST_FAILED_LOGIN");

                    b.Property<DateTime?>("LastLogin")
                        .HasColumnType("DATE")
                        .HasColumnName("LAST_LOGIN");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("VARCHAR2")
                        .HasColumnName("LAST_NAME");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR2")
                        .HasColumnName("MODIFIED_BY");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("DATE")
                        .HasColumnName("MODIFIED_DATE");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("VARCHAR2")
                        .HasColumnName("PASSWORD");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR2")
                        .HasColumnName("PHONE");

                    b.Property<string>("ResetPasswordToken")
                        .HasMaxLength(500)
                        .HasColumnType("VARCHAR2")
                        .HasColumnName("RESET_PASSWORD_TOKEN");

                    b.Property<DateTime?>("ResetPasswordTokenExp")
                        .HasColumnType("DATE")
                        .HasColumnName("RESET_PASSWORD_TOKEN_EXP");

                    b.Property<string>("Status")
                        .HasMaxLength(3)
                        .HasColumnType("CHAR")
                        .HasColumnName("STATUS");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR2")
                        .HasColumnName("USER_TYPE");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR2")
                        .HasColumnName("USERNAME");

                    b.Property<string>("VerifyEmailCode")
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR2")
                        .HasColumnName("VERIFY_EMAIL_CODE");

                    b.HasKey("UserId");

                    b.ToTable("USER", t =>
                        {
                            t.HasComment("User");
                        });
                });

            modelBuilder.Entity("GlobalAI.DemoEntities.DataEntities.AddProductDto", b =>
                {
                    b.Property<int>("ProductRecordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("PRODUCT_RECORD_ID");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductRecordId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("NVARCHAR2(1000)")
                        .HasColumnName("DESCRIPTION");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("NVARCHAR2(200)")
                        .HasColumnName("MANUFACTURER");

                    b.Property<int>("Price")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("PRICE");

                    b.Property<string>("ProductId")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)")
                        .HasColumnName("PRODUCT_ID");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("NVARCHAR2(400)")
                        .HasColumnName("PRODUCT_NAME");

                    b.HasKey("ProductRecordId");

                    b.ToTable("DEMO_PRODUCT", t =>
                        {
                            t.HasComment("Demo bảng sản phẩm");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
