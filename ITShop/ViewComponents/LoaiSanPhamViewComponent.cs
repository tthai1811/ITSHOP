using ITShop.Logic;
using ITShop.Models;
using Microsoft.AspNetCore.Mvc;
namespace ITShop.ViewComponents
{
	public class LoaiSanPhamViewComponent : ViewComponent
	{
		private readonly ITShopDbContext _context;
		public LoaiSanPhamViewComponent(ITShopDbContext context)
		{
			_context = context;
		}
		public IViewComponentResult Invoke()
		{
			var LoaiSanPham = _context.LoaiSanPham.OrderBy(r => r.TenLoai).ToList();
			return View(LoaiSanPham);
		}
	}
}