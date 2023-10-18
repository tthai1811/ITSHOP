using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ITShop.Models
{
    public class TinhTrang
    {
        public int ID { get; set; }
        [StringLength(255)]
		[Required(ErrorMessage = "không được bỏ trống!")]
		[DisplayName("Mô tả")]
		public string MoTa { get; set; }
        public ICollection<DatHang>? DatHang { get; set; }

    }
}
