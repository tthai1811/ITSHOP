using System.ComponentModel.DataAnnotations;

namespace ITShop.Models
{
    public class LoaiSanPham
    {
        public int ID { get; set; }
        [StringLength(255)]
        public string TenLoai { get; set; }
        public ICollection<SanPham>? SanPham { get; set; }
    }
}
