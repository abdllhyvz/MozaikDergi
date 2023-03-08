using Microsoft.AspNetCore.Mvc;

namespace MozaikDergi.Controllers
{
    public class YazarlarimizController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.page = "writers";
            return View();
        }
    }
}
