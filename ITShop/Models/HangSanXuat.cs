using System.ComponentModel.DataAnnotations;

namespace ITShop.Models
{
    public class HangSanXuat
    {
        public int ID { get; set; }
        [StringLength(255)]
        public string TenHangSanXuat { get; set; }
        public ICollection<SanPham>? SanPham { get; set; }
    }
}
