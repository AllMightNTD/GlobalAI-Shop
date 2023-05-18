using GlobalAI.Utils.Attributes;
using GlobalAI.Utils.ConstantVariables.Product;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductEntities.DataEntities
{
    [Table("P_DonHang")]
    [Comment("Đơn hàng")]
    public class DonHang
    {
        /// <summary>
        /// Id đơn hàng
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Mã đơn hàng
        /// </summary>
        [ColumnSnackCase(nameof(MaDonHang))]
        [MaxLength(50)]
        public string MaDonHang { get; set; }

        /// <summary>
        /// Ngày người mua nhận được hàng trên thực tế
        /// (vd: ngày nhận được đồ ship tới)
        /// </summary>
        [ColumnSnackCase(nameof(NgayHoanThanh))]
        public DateTime? NgayHoanThanh { get; set; }

        /// <summary>
        /// Id người bán (Id trong bảng User)
        /// </summary>
        [ColumnSnackCase(nameof(IdGStore))]
        public int? IdGStore { get; set; }

        /// <summary>
        /// Id người mua (Id trong bảng User)
        /// </summary>
        [ColumnSnackCase(nameof(IdNguoiMua))]
        public int? IdNguoiMua { get; set; }

        /// <summary>
        /// Số tiền của đơn hàng
        /// </summary>
        [ColumnSnackCase(nameof(SoTien))]
        public decimal? SoTien { get; set; }

        /// <summary>
        /// Hình thức thanh toán
        /// </summary>
        [ColumnSnackCase(nameof(HinhThucThanhToan))]
        public string HinhThucThanhToan { get; set; }

        /// <summary>
        /// Trạng thái đơn hàng
        /// 1: Tạo mới; 2: Đã xác nhận; 3: Hoàn Thành
        /// <see cref="TrangThaiDonHang"/>
        /// </summary>
        [ColumnSnackCase(nameof(Status))]
        public int? Status { get; set; }

        /// <summary>
        /// Địa chỉ 
        /// </summary>
        [ColumnSnackCase(nameof(DiaChi), TypeName = "VARCHAR2")]
        [MaxLength(1000)]
        public string DiaChi { get; set; }

        /// <summary>
        /// Ảnh của danh mục bài tin
        /// </summary>
        [ColumnSnackCase(nameof(Thumbnail), TypeName = "VARCHAR2")]
        [MaxLength(1000)]
        public string Thumbnail { get; set; }

        /// <summary>
        /// Ghi chú
        /// </summary>
        [ColumnSnackCase(nameof(GhiChu), TypeName = "VARCHAR2")]
        [MaxLength(4000)]
        public string GhiChu { get; set; }

        #region audit
        [MaxLength(50)]
        [ColumnSnackCase(nameof(CreatedBy), TypeName = "VARCHAR2")]
        public string CreatedBy { get; set; } = String.Empty;

        [ColumnSnackCase(nameof(CreatedDate), TypeName = "DATE")]
        public DateTime? CreatedDate { get; set; }

        [ColumnSnackCase(nameof(Deleted))]
        public bool Deleted { get; set; }

        [MaxLength(50)]
        [ColumnSnackCase(nameof(DeletedBy), TypeName = "VARCHAR2")]
        public string DeletedBy { get; set; } = String.Empty;

        [ColumnSnackCase(nameof(DeletedDate), TypeName = "DATE")]
        public DateTime? DeletedDate { get; set; }

        [MaxLength(50)]
        [ColumnSnackCase(nameof(ModifiedBy), TypeName = "VARCHAR2")]
        public string ModifiedBy { get; set; } = String.Empty;

        [ColumnSnackCase(nameof(ModifiedDate), TypeName = "DATE")]
        public DateTime? ModifiedDate { get; set; }
        #endregion

    }
}
