using NetCRUD2.Infrastructure;
using NetCRUD2.Models;
using Microsoft.AspNetCore.Mvc;

namespace NetCRUD2.Components
{
    public class CartWidget:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(HttpContext.Session.GetJson<Cart>("cart"));
        }
    }
}
