using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCRUD2.Models;
using System.Security.Cryptography;


namespace NetCRUD2.Controllers
{
    public class AccountController : BaseController
    {
        private readonly QLGameDBContext _context;
        public AccountController(QLGameDBContext context) 
        {
            _context = context;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("ID,Email,Password")]  Account model)
        {
            if (ModelState.IsValid) 
            {
                var loginUser = await _context.Accounts.FirstOrDefaultAsync(m => m.Email == model.Email);
                if (loginUser == null) 
                {
                    ModelState.AddModelError("", "Dang nhap that bai");
                    return View(model);
                }
                else
                {
                    SHA256 hashMethod = SHA256.Create();
                    
                    if (Utils.Crytography.VerifyHash(hashMethod, model.Password, loginUser.Password))
                    {

						CurrentUser = loginUser.Email;
						var cv = (from c in _context.Accounts
								  where c.Email == model.Email
								  select c.Quyen).SingleOrDefault();
						if (cv == 1)
						{
							return RedirectToAction("AdminIndex", "SanPhams");
						}
						else
						{
							return RedirectToAction("Index", "Home");
						}
					}
                    else
                    {
                        ModelState.AddModelError("", "Dang nhap that bai");
                        return View(model);
                    }
                }
            }
            return View(model);
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Email, Password, Hoten")] Account model)
        {
            if (ModelState.IsValid)
            {
                SHA256 hashMethod = SHA256.Create();
                model.Password = Utils.Crytography.GetHash(hashMethod, model.Password);


                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Login));
            }
            return View(model);
        }

       

        public IActionResult Logout()
        {
            CurrentUser = "";
            return RedirectToAction("Login");
        }
    }
}
