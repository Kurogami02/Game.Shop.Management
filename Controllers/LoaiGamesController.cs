using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetCRUD2.Models;
using Microsoft.Extensions.Hosting;

namespace NetCRUD2.Controllers
{
    public class LoaiGamesController : Controller
    {
        private readonly QLGameDBContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public LoaiGamesController(QLGameDBContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Hangs
        public async Task<IActionResult> Index()
        {
            return _context.LoaiGames != null ?
                        View(await _context.LoaiGames.ToListAsync()) :
                        Problem("Entity set 'QLdienthoaiContext.Hangs'  is null.");
        }

        // GET: Hangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LoaiGames == null)
            {
                return NotFound();
            }

            var hang = await _context.LoaiGames
                .FirstOrDefaultAsync(m => m.ID == id);
            if (hang == null)
            {
                return NotFound();
            }

            return View(hang);
        }
        // GET: Hangs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TenHang,ImageFile")] LoaiGame hang)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(hang.ImageFile.FileName);
                string extension = Path.GetExtension(hang.ImageFile.FileName);
                hang.Anhloaigame = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/images", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await hang.ImageFile.CopyToAsync(fileStream);

                    {
                        await hang.ImageFile.CopyToAsync(fileStream);
                    }
                }
                _context.Add(hang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hang);
        }

        // GET: Hangs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LoaiGames == null)
            {
                return NotFound();
            }

            var hang = await _context.LoaiGames.FindAsync(id);
            if (hang == null)
            {
                return NotFound();
            }
            return View(hang);
        }

        // POST: Hangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TenHang,ImageFile")] LoaiGame hang)
        {
            if (id != hang.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(hang.ImageFile.FileName);
                    string extension = Path.GetExtension(hang.ImageFile.FileName);
                    hang.Tenloaigame = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    string path = Path.Combine(wwwRootPath + "/images", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await hang.ImageFile.CopyToAsync(fileStream);

                        {
                            await hang.ImageFile.CopyToAsync(fileStream);
                        }
                    }
                    _context.Update(hang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HangExists(hang.ID))
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
            return View(hang);
        }

        // GET: Hangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LoaiGames == null)
            {
                return NotFound();
            }

            var hang = await _context.LoaiGames
                .FirstOrDefaultAsync(m => m.ID == id);
            if (hang == null)
            {
                return NotFound();
            }

            return View(hang);
        }

        // POST: Hangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LoaiGames == null)
            {
                return Problem("Entity set 'QLdienthoaiContext.Hangs'  is null.");
            }
            var hang = await _context.LoaiGames.FindAsync(id);
            if (hang != null)
            {
                _context.LoaiGames.Remove(hang);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HangExists(int id)
        {
            return (_context.LoaiGames?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
