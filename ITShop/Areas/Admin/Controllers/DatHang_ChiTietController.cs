using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ITShop.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace ITShop.Areas.Admin.Controllers
{
	[Authorize(Roles = "Admin")]
	[Area("Admin")]
    public class DatHang_ChiTietController : Controller
    {
        private readonly ITShopDbContext _context;

        public DatHang_ChiTietController(ITShopDbContext context)
        {
            _context = context;
        }

        // GET: DatHang_ChiTiet
        public async Task<IActionResult> Index()
        {
            var iTShopDbContext = _context.DatHang_ChiTiet.Include(d => d.DatHang).Include(d => d.SanPham);
            return View(await iTShopDbContext.ToListAsync());
        }

        // GET: DatHang_ChiTiet/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DatHang_ChiTiet == null)
            {
                return NotFound();
            }

            var datHang_ChiTiet = await _context.DatHang_ChiTiet
                .Include(d => d.DatHang)
                .Include(d => d.SanPham)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (datHang_ChiTiet == null)
            {
                return NotFound();
            }

            return View(datHang_ChiTiet);
        }

        // GET: DatHang_ChiTiet/Create
        public IActionResult Create()
        {
            ViewData["DatHangID"] = new SelectList(_context.DatHang, "ID", "ID");
            ViewData["SanPhamID"] = new SelectList(_context.SanPham, "ID", "ID");
            return View();
        }

        // POST: DatHang_ChiTiet/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,DatHangID,SanPhamID,SoLuong,DonGia")] DatHang_ChiTiet datHang_ChiTiet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(datHang_ChiTiet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DatHangID"] = new SelectList(_context.DatHang, "ID", "ID", datHang_ChiTiet.DatHangID);
            ViewData["SanPhamID"] = new SelectList(_context.SanPham, "ID", "ID", datHang_ChiTiet.SanPhamID);
            return View(datHang_ChiTiet);
        }

        // GET: DatHang_ChiTiet/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DatHang_ChiTiet == null)
            {
                return NotFound();
            }

            var datHang_ChiTiet = await _context.DatHang_ChiTiet.FindAsync(id);
            if (datHang_ChiTiet == null)
            {
                return NotFound();
            }
            ViewData["DatHangID"] = new SelectList(_context.DatHang, "ID", "ID", datHang_ChiTiet.DatHangID);
            ViewData["SanPhamID"] = new SelectList(_context.SanPham, "ID", "ID", datHang_ChiTiet.SanPhamID);
            return View(datHang_ChiTiet);
        }

        // POST: DatHang_ChiTiet/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DatHangID,SanPhamID,SoLuong,DonGia")] DatHang_ChiTiet datHang_ChiTiet)
        {
            if (id != datHang_ChiTiet.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(datHang_ChiTiet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DatHang_ChiTietExists(datHang_ChiTiet.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DatHangID"] = new SelectList(_context.DatHang, "ID", "ID", datHang_ChiTiet.DatHangID);
            ViewData["SanPhamID"] = new SelectList(_context.SanPham, "ID", "ID", datHang_ChiTiet.SanPhamID);
            return View(datHang_ChiTiet);
        }

        // GET: DatHang_ChiTiet/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DatHang_ChiTiet == null)
            {
                return NotFound();
            }

            var datHang_ChiTiet = await _context.DatHang_ChiTiet
                .Include(d => d.DatHang)
                .Include(d => d.SanPham)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (datHang_ChiTiet == null)
            {
                return NotFound();
            }

            return View(datHang_ChiTiet);
        }

        // POST: DatHang_ChiTiet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DatHang_ChiTiet == null)
            {
                return Problem("Entity set 'ITShopDbContext.DatHang_ChiTiet'  is null.");
            }
            var datHang_ChiTiet = await _context.DatHang_ChiTiet.FindAsync(id);
            if (datHang_ChiTiet != null)
            {
                _context.DatHang_ChiTiet.Remove(datHang_ChiTiet);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DatHang_ChiTietExists(int id)
        {
            return (_context.DatHang_ChiTiet?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
