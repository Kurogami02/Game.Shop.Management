using NetCRUD2.Models;
using Microsoft.AspNetCore.Mvc;

namespace NetCRUD2.Components
{
    public class Product : ViewComponent
    {
        private readonly QLGameDBContext _context;

        public Product(QLGameDBContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            return View(_context.SanPhams.ToList());
        }
    }
}
