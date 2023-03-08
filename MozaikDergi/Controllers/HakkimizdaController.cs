using Microsoft.AspNetCore.Mvc;

namespace MozaikDergi.Controllers
{
    public class HakkimizdaController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.page = "about";
            return View();
        }
    }
}
