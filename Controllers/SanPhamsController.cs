using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCRUD2.Models;


namespace NetCRUD2.Controllers
{
    public class SanPhamsController : BaseController
    {
        private readonly QLGameDBContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        public SanPhamsController(QLGameDBContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: SanPhams    
        public async Task<IActionResult> Index(int? id)
        {
            var qLdienThoaiDBContext = _context.SanPhams.Where(s => id == null || s.LoaiGameID == id).Include(s => s.LoaiGame);
            return View(await qLdienThoaiDBContext.ToListAsync());
        }
        public async Task<IActionResult> AdminIndex(int? id)
        {
            var qLdienThoaiDBContext = _context.SanPhams.Where(s => id == null || s.LoaiGameID == id).Include(s => s.LoaiGame);
            return View(await qLdienThoaiDBContext.ToListAsync());
        }

        // GET: SanPhams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SanPhams == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // GET: SanPhams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,LoaiGameID,Nhaphathanh,Tensp,Giatien,Mota,ImageFile")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(sanPham.ImageFile.FileName);
                string extension = Path.GetExtension(sanPham.ImageFile.FileName);
                sanPham.Anhbia = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/images", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await sanPham.ImageFile.CopyToAsync(fileStream);

                    {
                        await sanPham.ImageFile.CopyToAsync(fileStream);
                    }
                }
                _context.Add(sanPham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(AdminIndex));
            }
            return View(sanPham);
        }

        // GET: SanPhams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SanPhams == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams.FindAsync(id);
            if (sanPham == null)
            {
                return NotFound();
            }
            return View(sanPham);
        }

        // POST: SanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,LoaiGameID,Nhaphathanh,Tensp,Giatien,Mota,ImageFile")] SanPham sanPham)
        {
            if (id != sanPham.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(sanPham.ImageFile.FileName);
                    string extension = Path.GetExtension(sanPham.ImageFile.FileName);
                    sanPham.Anhbia = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    string path = Path.Combine(wwwRootPath + "/images", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await sanPham.ImageFile.CopyToAsync(fileStream);

                        {
                            await sanPham.ImageFile.CopyToAsync(fileStream);
                        }
                    }
                    _context.Update(sanPham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanPhamExists(sanPham.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(AdminIndex));
            }
            return View(sanPham);
        }

        // GET: SanPhams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SanPhams == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // POST: SanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SanPhams == null)
            {
                return Problem("Entity set 'QLdienthoaiContext.SanPhams'  is null.");
            }
            var sanPham = await _context.SanPhams.FindAsync(id);
            if (sanPham != null)
            {
                _context.SanPhams.Remove(sanPham);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(AdminIndex));
        }

        private bool SanPhamExists(int id)
        {
            return (_context.SanPhams?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
