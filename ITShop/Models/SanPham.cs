using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ITShop.Models
{
    public class SanPham
    {
        public int ID { get; set; }
		[DisplayName("Mã hãng sản xuất")]
		[Required(ErrorMessage = " không được bỏ trống!")]
		public int HangSanXuatID { get; set; }

		[DisplayName("Loại sản phẩm")]
		[Required(ErrorMessage = " không được bỏ trống!")]
		public int LoaiSanPhamID { get; set; }

        [StringLength(255)]
		[DisplayName("Tên sản phẩm")]
		[Required(ErrorMessage = " không được bỏ trống!")]
		public string TenSanPham { get; set; }

		[DisplayName("Đơn giá")]
		[Required(ErrorMessage = " không được bỏ trống!")]
		[DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
		public int DonGia { get; set; }


		[DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
		[Required(ErrorMessage = " không được bỏ trống!")]
		[DisplayName("Số Lượng")]
		public int SoLuong { get; set; }
        [StringLength(255)]

		[DisplayName("Hình ảnh")]
		public string? HinhAnh { get; set; }

        [Column(TypeName = "ntext")]//
		[DisplayName("Mô tả")]
		[DataType(DataType.MultilineText)]
		public string? MoTa { get; set; }
        public ICollection<DatHang_ChiTiet>? DatHang_ChiTiet { get; set; }
        public LoaiSanPham? LoaiSanPham { get; set; }
        public HangSanXuat? HangSanXuat { get; set; }
		[NotMapped]
		[Display(Name = "Hình ảnh sản phẩm")]
		public IFormFile? DuLieuHinhAnh { get; set; }

	}

}
