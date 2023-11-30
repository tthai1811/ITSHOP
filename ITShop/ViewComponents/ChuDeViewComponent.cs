using ITShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITShop.ViewComponents_
{
    public class ChuDeViewComponent : ViewComponent
    {
        private readonly ITShopDbContext _context;
        public ChuDeViewComponent(ITShopDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var chuDe = _context.ChuDe.OrderBy(r => r.TenChuDe).ToList();
            return View("Default", chuDe);
        }
    }
}
