using Microsoft.AspNetCore.Mvc;
using MozaikDergi.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace MozaikDergi.Controllers
{
    public class AnasayfaController : Controller
    {
        [Obsolete]
        private readonly IHostingEnvironment _hostingEnvironment;

        private readonly ILogger<AnasayfaController> _logger;

        [Obsolete]
        public AnasayfaController(ILogger<AnasayfaController> logger, IHostingEnvironment hostingEnvironment)
        {
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
        }

        [Obsolete]
        public IActionResult Index()
        {
            string[] filePaths = Directory.GetFiles(Path.Combine(this._hostingEnvironment.WebRootPath, "Files/"));
            List<IssueModel> files = new List<IssueModel>();
            foreach (string file in filePaths)
            {
                string exactFile = file.Split("/")[1];
                files.Add(new IssueModel { Date = exactFile.Split("-")[0].Split("_")[0] + "." + exactFile.Split("-")[0].Split("_")[1], Issue = exactFile.Split("-")[1],Text = exactFile.Split("-")[2]});
            }
            files = files.OrderByDescending(x => x.Issue).ToList();
            var last3 = files.Take(3);

            ViewBag.last3 = last3;
            ViewBag.page = "home";
            return View(files);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Obsolete]
        public IActionResult DownloadFile(string text,string issue,string date)
        {
            var file = date.Replace(".", "_") + "-" + issue + "-" + text + "-.pdf";
            var fileName = "MozaikDergisi_Sayı" + issue + ".pdf";
            string path = Path.Combine(this._hostingEnvironment.WebRootPath, "Files/") + file;
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            return File(bytes,"application/pdf",fileName);
        }
    }
}