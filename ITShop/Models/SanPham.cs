using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using ITShop.Models;

namespace ITShop.Models
{
    public class SanPham
    {
        [DisplayName("Mã SP")]
        public int ID { get; set; }
        [DisplayName("Mã HSX")]
        [Required(ErrorMessage = "Mã HSX không được bỏ trống!")]
        public int HangSanXuatID { get; set; }

        [DisplayName("Mã loại SP")]
        [Required(ErrorMessage = "Mã loại SP không được bỏ trống!")]
        public int LoaiSanPhamID { get; set; }

        [StringLength(255)]
        [DisplayName("Tên sản phẩm")]
        [Required(ErrorMessage = "Tên sản phẩm không được bỏ trống!")]
        public string TenSanPham { get; set; }

        [DisplayName("Đơn giá")]
        [Required(ErrorMessage = "Đơn giá không được bỏ trống!")]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public int DonGia { get; set; }

        [DisplayName("Số lượng")]
        [Required(ErrorMessage = "Số lượng không được bỏ trống!")]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
        public int SoLuong { get; set; }

        [StringLength(255)]
        [DisplayName("Hình ảnh sản phẩm")]
        public string? HinhAnh { get; set; }
        [NotMapped]
        public IFormFile? DuLieuHinhAnh { get; set; }

        [Column(TypeName = "ntext")]
        [DisplayName("Mô tả")]
        [DataType(DataType.MultilineText)]
        public string? MoTa { get; set; }

        public ICollection<DatHang_ChiTiet>? DatHang_ChiTiet { get; set; }
        public LoaiSanPham? LoaiSanPham { get; set; }
        public HangSanXuat? HangSanXuat { get; set; }
    }

    [NotMapped]
    public class PhanTrangSanPham
    {
        public int TrangHienTai { get; set; }
        public int TongSoTrang { get; set; }
        public List<SanPham> SanPham { get; set; }
        public bool HasPreviousPage => TrangHienTai > 1;
        public bool HasNextPage => TrangHienTai < TongSoTrang;
    }
}



