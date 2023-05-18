using GlobalAI.Utils;
using GlobalAI.Utils.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductEntities.Dto.Product
{
    public class AddDonHangDto
    {
        /// <summary>
        /// Mã đơn hàng
        /// </summary>
       
        public string MaDonHang { get; set; }

        /// <summary>
        /// Ngày người mua nhận được hàng trên thực tế
        /// (vd: ngày nhận được đồ ship tới)
        /// </summary>
        public DateTime? NgayHoanThanh { get; set; }

        /// <summary>
        /// Id người bán (Id trong bảng User)
        /// </summary>
        public int? IdGStore { get; set; }

        /// <summary>
        /// Id người mua (Id trong bảng User)
        /// </summary>
        public int? IdNguoiMua { get; set; }

        /// <summary>
        /// Số tiền của đơn hàng
        /// </summary>
        public decimal? SoTien { get; set; }

        /// <summary>
        /// Hình thức thanh toán
        /// </summary>
        public string HinhThucThanhToan { get; set; }

        public string DiaChi { get; set; }

        public string GhiChu { get; set; }



    }
}