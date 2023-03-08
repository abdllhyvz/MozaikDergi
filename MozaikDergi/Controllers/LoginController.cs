using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace MozaikDergi.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string username,string password) 
        {
            if (username == "admin" && password == "Mozaik_2023*")
            {
                var claims = new List<Claim>
                {
                new Claim(type:ClaimTypes.Name,value:username),
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity),
                    new AuthenticationProperties
                    {
                        IsPersistent = true,
                        AllowRefresh = true,
                    }
                );
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ViewBag.error = "Kullanıcı Adı veya Şifre Yanlış";
                return View();
            }
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Anasayfa");
        }
    }
}
