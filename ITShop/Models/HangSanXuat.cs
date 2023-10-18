using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ITShop.Models
{
    public class HangSanXuat
    {

        public int ID { get; set; }
        [StringLength(255)]
		[Required(ErrorMessage = "Tên loại sản sản xuất không được bỏ trống!")]
		[DisplayName("Tên Sản Xuất")]
		public string TenHangSanXuat { get; set; }
        public ICollection<SanPham>? SanPham { get; set; }
    }
}
