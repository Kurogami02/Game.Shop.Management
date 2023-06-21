using Microsoft.AspNetCore.Mvc;
using NetCRUD2.Components;
using NetCRUD2.Infrastructure;
using NetCRUD2.Models;

namespace NetCRUD2.Controllers
{
    public class CartController : Controller
    {
        private readonly QLGameDBContext _context;
        
        public CartController(QLGameDBContext context)
        {
            _context = context;
        }
        public Cart? Cart { get; set; }

        public IActionResult Index()
        {
            return View("Cart", HttpContext.Session.GetJson<Cart>("cart"));
        }
        public IActionResult AddtoCart(int ID)
        {
            SanPham? sanPham = _context.SanPhams.FirstOrDefault(p => p.ID == ID);
            if (sanPham != null)
            {
                Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.AddItem(sanPham, 1);
                HttpContext.Session.SetJson("cart", Cart);
            }
            return View("Cart", Cart);
        }

        public IActionResult UpdateCart(int ID)
        {
            SanPham? sanPham = _context.SanPhams.FirstOrDefault(p => p.ID == ID);
            if (sanPham != null)
            {
                Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.AddItem(sanPham, -1);
                HttpContext.Session.SetJson("cart", Cart);
            }
            return View("Cart", Cart);
        }

        public IActionResult RemovefromCart(int ID)
        {
            SanPham? sanPham = _context.SanPhams.FirstOrDefault(p => p.ID == ID);
            if (sanPham != null)
            {
                Cart = HttpContext.Session.GetJson<Cart>("cart");
                Cart.RemoveItem(sanPham);
                HttpContext.Session.SetJson("cart", Cart);
            }
            return View("Cart", Cart);
        }
    }
}