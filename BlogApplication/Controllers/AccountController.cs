using System.Security.Claims;
using BlogApplication.Context;
using BlogApplication.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BlogApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly BlogDbContext _context;

        public AccountController(BlogDbContext context)
        {
            _context = context;

        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string email, string sifre)
        {
            var user = _context.Kullanicis.FirstOrDefault(x=>x.Email == email && x.Sifre == sifre);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Email),
                    new Claim("Fullname", user.KullaniciAdi + " " + user.Soyad),
                    new Claim(ClaimTypes.Role, user.Rol ?? "Admin")
                };

                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync("MyCookieAuth", principal);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Geçersiz email veya şifre");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(Kullanici user)
        {
            if (ModelState.IsValid)
            {
                var existing = _context.Kullanicis.FirstOrDefault(u => u.Email == user.Email);
                if (existing != null)
                {
                    ModelState.AddModelError("Email", "Bu Email zaten kayıtlı");
                    return View();
                }
                _context.Kullanicis.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Login");

            }
            return View(user);

        }
    }
}
