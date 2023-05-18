using GlobalAI.ProductEntities.Dto.ChiTietDonHang;
using GlobalAI.ProductEntities.Dto.VoucherChiTiet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductEntities.Dto.DonHang
{
    public class DonHangDto
    {
        public int Id { get; set; }
        public string MaDonHang { get; set; }
        public DateTime? NgayHoanThanh { get; set; }
        public int? IdGStore { get; set; }
        public int? IdNguoiMua { get; set; }
        public decimal? SoTien { get; set; }
        public string HinhThucThanhToan { get; set; }
        public int? Status { get; set; }
        public string DiaChi { get; set; }
        public string Thumbnail { get; set; }
        public string GhiChu { get; set; }
        public List<DonHangChiTietDto> DonHangChiTiets { get; set; }
    }
}
