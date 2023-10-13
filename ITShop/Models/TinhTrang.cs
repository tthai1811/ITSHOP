using System.ComponentModel.DataAnnotations;

namespace ITShop.Models
{
    public class TinhTrang
    {
        public int ID { get; set; }
        [StringLength(255)]
        public string MoTa { get; set; }
        public ICollection<DatHang>? DatHang { get; set; }

    }
}
