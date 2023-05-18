using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalAI.HostConsole.Migrations
{
    /// <inheritdoc />
    public partial class addtblward2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "G_POINT",
                table: "USER",
                type: "DECIMAL(18, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "FAIL_ATTEMP",
                table: "USER",
                type: "DECIMAL(18, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "GIA_CUOI",
                table: "P_TraGia",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "GIA_TOI_THIEU",
                table: "P_SanPhamChiTiet",
                type: "DECIMAL(18, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "GIA_CHIET_KHAU",
                table: "P_SanPhamChiTiet",
                type: "DECIMAL(18, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "GIA_BAN",
                table: "P_SanPhamChiTiet",
                type: "DECIMAL(18, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "GIA_TOI_THIEU",
                table: "P_SanPham",
                type: "DECIMAL(18, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "GIA_CHIET_KHAU",
                table: "P_SanPham",
                type: "DECIMAL(18, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "GIA_BAN",
                table: "P_SanPham",
                type: "DECIMAL(18, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "SO_TIEN",
                table: "P_DonHang",
                type: "DECIMAL(18, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "GIA_TIEN",
                table: "P_ChiTietTraGia",
                type: "DECIMAL(18, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "G_POINT",
                table: "P_ChiTietDonHang",
                type: "DECIMAL(18, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "C_DISTRICTS",
                columns: table => new
                {
                    CODE = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    NAME = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    NAME_EN = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    FULL_NAME = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    FULL_NAME_EN = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CODE_NAME = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PROVINCE_CODE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ADMINISTRATIVE_UNIT_ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_C_DISTRICTS", x => x.CODE);
                });

            migrationBuilder.CreateTable(
                name: "C_WARDS",
                columns: table => new
                {
                    CODE = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    NAME = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    NAME_EN = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    FULL_NAME = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    FULL_NAME_EN = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CODE_NAME = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DISTRICT_CODE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ADMINISTRATIVE_UNIT_ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_C_WARDS", x => x.CODE);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "C_DISTRICTS");

            migrationBuilder.DropTable(
                name: "C_WARDS");

            migrationBuilder.AlterColumn<decimal>(
                name: "G_POINT",
                table: "USER",
                type: "DECIMAL(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "FAIL_ATTEMP",
                table: "USER",
                type: "DECIMAL(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "GIA_CUOI",
                table: "P_TraGia",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "GIA_TOI_THIEU",
                table: "P_SanPhamChiTiet",
                type: "DECIMAL(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "GIA_CHIET_KHAU",
                table: "P_SanPhamChiTiet",
                type: "DECIMAL(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "GIA_BAN",
                table: "P_SanPhamChiTiet",
                type: "DECIMAL(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "GIA_TOI_THIEU",
                table: "P_SanPham",
                type: "DECIMAL(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "GIA_CHIET_KHAU",
                table: "P_SanPham",
                type: "DECIMAL(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "GIA_BAN",
                table: "P_SanPham",
                type: "DECIMAL(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "SO_TIEN",
                table: "P_DonHang",
                type: "DECIMAL(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "GIA_TIEN",
                table: "P_ChiTietTraGia",
                type: "DECIMAL(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "G_POINT",
                table: "P_ChiTietDonHang",
                type: "DECIMAL(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);
        }
    }
}
