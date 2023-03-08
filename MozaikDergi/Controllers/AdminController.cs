using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MozaikDergi.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string text,string sayi,string tarih,IFormFile file)
        {
            if(text != null && sayi != null && tarih != null && file != null)
            {
                var fileName = tarih + "-" + sayi + "-" + text + "-.pdf";
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\files", fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
            }
            return RedirectToAction("Index", "Anasayfa");
        }
    }
}
