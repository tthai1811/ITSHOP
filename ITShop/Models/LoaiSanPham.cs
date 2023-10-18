using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ITShop.Models
{
    public class LoaiSanPham
    {
        [DisplayName ("Mã Loại")]
        public int ID { get; set; }
		[Display(Name = "Tên Loại")]
		[StringLength(255)]
		[Required(ErrorMessage = "Tên loại không được bỏ trống!")]
		public string TenLoai { get; set; }
        public ICollection<SanPham>? SanPham { get; set; }
    }
}
