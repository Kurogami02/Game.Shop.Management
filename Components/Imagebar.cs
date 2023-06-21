using NetCRUD2.Models;
using Microsoft.AspNetCore.Mvc;


namespace NetCRUD2.Components
{
    public class Imagebar:ViewComponent
    {
        private readonly QLGameDBContext _context;

        public Imagebar(QLGameDBContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            return View("Index",_context.LoaiGames.ToList());
        }
    }
}
