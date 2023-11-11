using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITShop.Models
{
	[NotMapped]
	public class NguoiDung_ChinhSua

    {
        public NguoiDung_ChinhSua() { }
        public NguoiDung_ChinhSua(NguoiDung n)
                
        {
            ID = n.ID;
            HoVaTen = n.HoVaTen;
            DienThoai = n.DienThoai;
            DiaChi = n.DiaChi;
            TenDangNhap = n.TenDangNhap;
            MatKhau = n.MatKhau;
            XacNhanMatKhau = n.XacNhanMatKhau;
            Quyen = n.Quyen;

        }





        public int ID { get; set; }
        [StringLength(100)]
        [Required(ErrorMessage = "Họ và tên không được bỏ trống!")]
        [DisplayName("Họ và tên")]
        public string HoVaTen { get; set; }
        [StringLength(20)]
        [DisplayName("Điện thoại")]
        public string? DienThoai { get; set; }
        [StringLength(255)]
        [DisplayName("Địa chỉ")]
        public string? DiaChi { get; set; }
        [StringLength(50, ErrorMessage = "{0} phải ít nhất {2} ký tự.", MinimumLength = 4)]
        [Required(ErrorMessage = "Tên đăng nhập không được bỏ trống!")]
        [DisplayName("Tên đăng nhập")]
        public string TenDangNhap { get; set; }
        [StringLength(255)]
        [DataType(DataType.Password)]
        [DisplayName("Mật khẩu")]
        public string? MatKhau { get; set; }
        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("MatKhau", ErrorMessage = "Xác nhận mật khẩu không chính xác!")]
        [DataType(DataType.Password)]
        public string? XacNhanMatKhau { get; set; }
        [DisplayName("Quyền")]
        public bool Quyen { get; set; }
    }

    public class NguoiDung
    {
       

        public int ID { get; set; }
        [StringLength(100)]
		[Required(ErrorMessage = "Tên không được bỏ trống!")]
		[DisplayName("Họ và tên")]
		public string HoVaTen { get; set; }


        [StringLength(20)]
        [RegularExpression("[0-9]{10}", ErrorMessage = " Điện thoại phải là 10 chữ số!")]
        [DisplayName("Diện Thoại")]

		public string? DienThoai { get; set; }
        [StringLength(255)]
		[DisplayName("Dịa Chỉ")]
		public string? DiaChi { get; set; }
		[Required(ErrorMessage = "Tên đăng nhập không được bỏ trống!")]
		[StringLength(50, ErrorMessage = "{0} phải ít nhất {2} ký tự.", MinimumLength = 4)]
		[DisplayName("Tên đăng nhập")]
		public string TenDangNhap { get; set; }


		[Required(ErrorMessage = "Mật khẩu không được bỏ trống!")]
		[StringLength(255, ErrorMessage = "{0} phải ít nhất {2} ký tự.", MinimumLength = 4)]
		[DisplayName("Mật Khẩu")]
		[DataType(DataType.Password)]
		public string MatKhau { get; set; }

        [NotMapped]
        [Display(Name ="Xác nhận mật khẩu")]
        [Required(ErrorMessage ="Xác nhận mật khẩu không được bỏ trống")]
        [Compare("MatKhau", ErrorMessage = "Xác nhận mật khẩu chính xác")]
        [DataType(DataType.Password)]
        public string XacNhanMatKhau { get; set; }



        [DisplayName("Quyền")]
        public bool Quyen { get; set; }
        public ICollection<DatHang>? DatHang { get; set; }

    }

    [NotMapped]
    public class DangNhap
    {
        [StringLength(50, ErrorMessage = "{0} phải ít nhất {2} ký tự.", MinimumLength = 4)]
        [Required(ErrorMessage = "Tên đăng nhập không được bỏ trống!")]
        [DisplayName("Tên đăng nhập")]
        public string TenDangNhap { get; set; }
        [StringLength(255)]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Mật khẩu không được bỏ trống!")]
        [DisplayName("Mật khẩu")]
        public string MatKhau { get; set; }
        [DisplayName("Duy trì đăng nhập")]
        public bool DuyTriDangNhap { get; set; }

        [StringLength(255)]
        [DisplayName("Liên kết chuyển trang")]
        public string? LienKetChuyenTrang { get; set; }
    }
}
