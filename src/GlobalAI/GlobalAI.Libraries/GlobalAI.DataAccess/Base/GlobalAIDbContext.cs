using GlobalAI.CoreEntities.DataEntities;
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.Product;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.DataAccess.Base
{
    public partial class GlobalAIDbContext : DbContext
    {
        #region Core
        public DbSet<User> Users { get; set; }
        public DbSet<CoreRole> CoreRoles { get; set; }
        public DbSet<CoreUserRole> CoreUserRoles { get; set; }
        public DbSet<CoreRolePermisison> CoreRolePermisisons { get; set; }
        #endregion

        #region Bài tin
        public DbSet<BaiTin> BaiTins { get; set; }
        public DbSet<DanhMucBaiTin> DanhMucBaiTins { get; set; }
        #endregion

        #region Tỉnh thành
        public DbSet<CoreProvince> CoreProvinces { get; set; }
        public DbSet<CoreDistrict> CoreDistricts { get; set; }
        public DbSet<CoreWard> CoreWards { get; set; }

        #endregion

        #region Product
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<SanPhamChiTiet> SanPhamChiTiets { get; set; }
        public DbSet<SanPhamChiTietThuocTinh> SanPhamChiTietThuocTinhs { get; set; }
        public DbSet<DanhMuc> DanhMucs { get; set; }
        public DbSet<DonHang> DonHangs { get; set; }
        public DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public DbSet<GioHang> GioHangs { get; set; }
        public DbSet<TraGia> TraGias { get; set; }
        public DbSet<ChiTietTraGia> ChiTietTraGias { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<VoucherChiTiet> VoucherChiTiets { get; set; }
        public DbSet<DanhMucThuocTinh> danhMucThuocTinhs { get; set; }
        public DbSet<ThuocTinh> ThuocTinhs { get; set; }
        public DbSet<ThuocTinhGiaTri> ThuocTinhGiaTris { get; set; }

        #endregion

        public GlobalAIDbContext(DbContextOptions<GlobalAIDbContext> options) : base(options)
        {
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
