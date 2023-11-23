using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ITShop.Models
{
    public class HangSanXuat
    {
        [DisplayName("Mã HSX")]
        public int ID { get; set; }

        [StringLength(255)]
        [Required(ErrorMessage = "Tên hãng sản xuất không được bỏ trống!")]
        [DisplayName("Hãng sản xuất")]
        public string TenHangSanXuat { get; set; }

        public ICollection<SanPham>? SanPham { get; set; }

    }
}
