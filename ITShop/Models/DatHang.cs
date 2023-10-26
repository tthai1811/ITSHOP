﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ITShop.Models
{
    public class DatHang
    {
        public int ID { get; set; }
		[DisplayName("Mã người dùng")]
		[Required(ErrorMessage = " không được bỏ trống!")]
		public int NguoiDungID { get; set; }
	
		[Required(ErrorMessage = " không được bỏ trống!")]
		public int TinhTrangID { get; set; }
        [StringLength(20)]
		[DisplayName("Diện thoại giao hàng")]
		[Required(ErrorMessage = " không được bỏ trống!")]
		public string DienThoaiGiaoHang { get; set; }
        [StringLength(255)]
		[DisplayName("Địa chỉ giao hàng")]
		[Required(ErrorMessage = " không được bỏ trống!")]
		public string DiaChiGiaoHang { get; set; }
		[DisplayName("Ngày đặt hàng")]
		[Required(ErrorMessage = " không được bỏ trống!")]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
		public DateTime NgayDatHang { get; set; }
        public ICollection<DatHang_ChiTiet>? DatHang_ChiTiet { get; set; }
        public NguoiDung? NguoiDung { get; set; }
        public TinhTrang? TinhTrang { get; set; }
    }


}
