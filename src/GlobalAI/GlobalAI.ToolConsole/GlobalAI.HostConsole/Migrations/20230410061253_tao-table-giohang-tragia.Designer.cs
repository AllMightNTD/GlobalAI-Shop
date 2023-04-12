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
    [Migration("20230410061253_tao-table-giohang-tragia")]
    partial class taotablegiohangtragia
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

            modelBuilder.Entity("GlobalAI.ProductEntities.DataEntities.ChiTietDonHang", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("I_D");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Deleted")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("DELETED");

                    b.Property<string>("Id_don_hang")
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("MA_DON_HANG");

                    b.Property<string>("Id_san_pham")
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("MA_SAN_PHAM");

                    b.Property<int>("SoLuong")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("SO_LUONG");

                    b.Property<int>("Status")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("STATUS");

                    b.HasKey("ID");

                    b.ToTable("P_ChiTietDonHang", t =>
                        {
                            t.HasComment("bảng chi tiết đơn hàng");
                        });
                });

            modelBuilder.Entity("GlobalAI.ProductEntities.DataEntities.DanhMuc", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Id_danh_muc")
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("MA_DANH_MUC");

                    b.Property<int>("Status")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("STATUS");

                    b.Property<string>("TenDanhMuc")
                        .HasMaxLength(400)
                        .HasColumnType("NVARCHAR2(400)")
                        .HasColumnName("TEN_DANH_MUC");

                    b.HasKey("ID");

                    b.ToTable("P_DanhMuc", t =>
                        {
                            t.HasComment("Demo bảng danh mục sản phẩm");
                        });
                });

            modelBuilder.Entity("GlobalAI.ProductEntities.DataEntities.DonHang", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<bool>("Deleted")
                        .HasColumnType("NUMBER(1)")
                        .HasColumnName("DELETED");

                    b.Property<string>("HinhThucThanhToan")
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("HINH_THUC_THANH_TOAN");

                    b.Property<string>("Id_don_hang")
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("MA_DON_HANG");

                    b.Property<int?>("Id_Gsaler")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("MA_G_SALER");

                    b.Property<int?>("Id_gstore")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("MA_G_STORE");

                    b.Property<DateTime>("NgayHoanThanh")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("NGAY_HOAN_THANH");

                    b.Property<decimal?>("SoTien")
                        .HasColumnType("DECIMAL(18, 2)")
                        .HasColumnName("SO_TIEN");

                    b.Property<int>("Status")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("STATUS");

                    b.HasKey("ID");

                    b.ToTable("P_DonHang", t =>
                        {
                            t.HasComment("bảng đơn hàng");
                        });
                });

            modelBuilder.Entity("GlobalAI.ProductEntities.DataEntities.GioHang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("ID");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Deleted")
                        .HasColumnType("NUMBER(1)")
                        .HasColumnName("DELETED");

                    b.Property<int>("Id_Gsaler")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("MA_G_SALER");

                    b.Property<string>("Id_gio_hang")
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("MA_GIO_HANG");

                    b.Property<string>("Id_san_pham")
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("MA_SAN_PHAM");

                    b.Property<int>("Status")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("STATUS");

                    b.HasKey("Id");

                    b.ToTable("P_GioHang");
                });

            modelBuilder.Entity("GlobalAI.ProductEntities.DataEntities.SanPham", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

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

                    b.Property<decimal>("GiaBan")
                        .HasColumnType("DECIMAL(18, 2)")
                        .HasColumnName("GIA_BAN");

                    b.Property<decimal>("GiaChietKhau")
                        .HasColumnType("DECIMAL(18, 2)")
                        .HasColumnName("GIA_CHIET_KHAU");

                    b.Property<string>("Id_danh_muc")
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("MA_DANH_MUC");

                    b.Property<int>("Id_gstore")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("MA_G_STORE");

                    b.Property<string>("Id_san_pham")
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("MA_SAN_PHAM");

                    b.Property<string>("MoTa")
                        .HasMaxLength(1000)
                        .HasColumnType("NVARCHAR2(1000)")
                        .HasColumnName("MO_TA");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR2")
                        .HasColumnName("MODIFIED_BY");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("DATE")
                        .HasColumnName("MODIFIED_DATE");

                    b.Property<DateTime>("NgayDangKi")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("NGAY_DANG_KI");

                    b.Property<DateTime>("NgayDuyet")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("NGAY_DUYET");

                    b.Property<int>("Status")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("STATUS");

                    b.Property<string>("TenSanPham")
                        .HasMaxLength(400)
                        .HasColumnType("NVARCHAR2(400)")
                        .HasColumnName("TEN_SAN_PHAM");

                    b.HasKey("ID");

                    b.ToTable("P_SanPham", t =>
                        {
                            t.HasComment("bảng sản phẩm");
                        });
                });

            modelBuilder.Entity("GlobalAI.ProductEntities.DataEntities.TraGia", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("I_D");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<bool>("Deleted")
                        .HasColumnType("NUMBER(1)")
                        .HasColumnName("DELETED");

                    b.Property<decimal>("GiaTien")
                        .HasColumnType("DECIMAL(18, 2)")
                        .HasColumnName("GIA_TIEN");

                    b.Property<int>("Id_Gsaler")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("MA_G_SALER");

                    b.Property<string>("Id_san_pham")
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("MA_SAN_PHAM");

                    b.Property<string>("Id_tra_gia")
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("MA_TRA_GIA");

                    b.Property<int>("Status")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("STATUS");

                    b.HasKey("ID");

                    b.ToTable("P_TraGia");
                });
#pragma warning restore 612, 618
        }
    }
}
