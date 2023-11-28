﻿using System;
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
    public class BinhLuanBaiVietController : Controller
    {
        private readonly ITShopDbContext _context;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public BinhLuanBaiVietController(ITShopDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
			_httpContextAccessor = httpContextAccessor;
		}

        // GET: BinhLuanBaiViet
        public async Task<IActionResult> Index()
        {
            var iTShopDbContext = _context.BinhLuanBaiViet.Include(b => b.BaiViet).Include(b => b.NguoiDung).OrderByDescending(r => r.NgayDang);
			;
			return View(await iTShopDbContext.ToListAsync());
        }

        // GET: BinhLuanBaiViet/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BinhLuanBaiViet == null)
            {
                return NotFound();
            }

            var binhLuanBaiViet = await _context.BinhLuanBaiViet
                .Include(b => b.BaiViet)
                .Include(b => b.NguoiDung)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (binhLuanBaiViet == null)
            {
                return NotFound();
            }

            return View(binhLuanBaiViet);
        }

        // GET: BinhLuanBaiViet/Create
        public IActionResult Create()
        {
            ViewData["BaiVietID"] = new SelectList(_context.BaiViet, "ID", "NoiDung");
            return View();
        }

        // POST: BinhLuanBaiViet/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,BaiVietID,NoiDungBinhLuan")] BinhLuanBaiViet binhLuanBaiViet)
        {
            if (ModelState.IsValid)
            {
				int maNguoiDung = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "ID")?.Value);

				// Gán các giá trị mặc định
				binhLuanBaiViet.NguoiDungID = maNguoiDung;
				binhLuanBaiViet.NgayDang = DateTime.Now;
				binhLuanBaiViet.LuotXem = 0;
				binhLuanBaiViet.KiemDuyet = true;
				_context.Add(binhLuanBaiViet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BaiVietID"] = new SelectList(_context.BaiViet, "ID", "NoiDung", binhLuanBaiViet.BaiVietID);
          
            return View(binhLuanBaiViet);
        }

        // GET: BinhLuanBaiViet/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BinhLuanBaiViet == null)
            {
                return NotFound();
            }

            var binhLuanBaiViet = await _context.BinhLuanBaiViet.FindAsync(id);
            if (binhLuanBaiViet == null)
            {
                return NotFound();
            }
            ViewData["BaiVietID"] = new SelectList(_context.BaiViet, "ID", "NoiDung", binhLuanBaiViet.BaiVietID);

            return View(binhLuanBaiViet);
        }

        // POST: BinhLuanBaiViet/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,BaiVietID,NoiDungBinhLuan,KiemDuyet")] BinhLuanBaiViet binhLuanBaiViet)
        {
            if (id != binhLuanBaiViet.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
					// Bỏ qua không cập nhật
					_context.Entry(binhLuanBaiViet).Property(x => x.NguoiDungID).IsModified = false;
					_context.Entry(binhLuanBaiViet).Property(x => x.NgayDang).IsModified = false;
					_context.Entry(binhLuanBaiViet).Property(x => x.LuotXem).IsModified = false;

					_context.Update(binhLuanBaiViet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BinhLuanBaiVietExists(binhLuanBaiViet.ID))
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
            ViewData["BaiVietID"] = new SelectList(_context.BaiViet, "ID", "NoiDung", binhLuanBaiViet.BaiVietID);
            return View(binhLuanBaiViet);
        }

        // GET: BinhLuanBaiViet/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BinhLuanBaiViet == null)
            {
                return NotFound();
            }

            var binhLuanBaiViet = await _context.BinhLuanBaiViet
                .Include(b => b.BaiViet)
                .Include(b => b.NguoiDung)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (binhLuanBaiViet == null)
            {
                return NotFound();
            }

            return View(binhLuanBaiViet);
        }

        // POST: BinhLuanBaiViet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BinhLuanBaiViet == null)
            {
                return Problem("Entity set 'ITShopDbContext.BinhLuanBaiViet'  is null.");
            }
            var binhLuanBaiViet = await _context.BinhLuanBaiViet.FindAsync(id);
            if (binhLuanBaiViet != null)
            {
                _context.BinhLuanBaiViet.Remove(binhLuanBaiViet);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BinhLuanBaiVietExists(int id)
        {
            return (_context.BinhLuanBaiViet?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
