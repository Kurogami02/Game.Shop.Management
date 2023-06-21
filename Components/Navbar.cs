using NetCRUD2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace NetCRUD2.Components
{
    public class Navbar:ViewComponent
    {
        private readonly QLGameDBContext _context;

        public Navbar( QLGameDBContext context )
        {
            _context = context;
        }    
        public IViewComponentResult Invoke()
        {
            return View(_context.LoaiGames.ToList());
        }    
    }
}
