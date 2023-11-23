using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ITShop.Models
{
    public class TinhTrang
    {
        public int ID { get; set; }

        [StringLength(255)]
        [DisplayName("Mô tả tình trạng")]
        [Required(ErrorMessage = "Mô tả tình trạng không được bỏ trống!")]
        public string MoTa { get; set; }

        public ICollection<DatHang>? DatHang { get; set; }
    }
}
