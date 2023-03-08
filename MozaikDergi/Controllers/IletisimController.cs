using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using MozaikDergi.Models;

namespace MozaikDergi.Controllers
{
    public class IletisimController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.page = "contact";
            return View();
        }

        [HttpPost]
        public IActionResult Index(MailModel mailModel)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(mailModel.Receiver));
            email.To.Add(MailboxAddress.Parse(mailModel.Receiver));
            email.Subject = mailModel.Title; 
            email.Body = new TextPart(TextFormat.Html) { Text = "<h1>İsim: </h1>" + mailModel.Name + "<br/><h1>Mail: </h1>" + mailModel.Email + "<br/><h1>Konu: </h1>" + mailModel.Subject + "<br/><h1>Mesaj: </h1>" + mailModel.Body};

            using var smtp = new SmtpClient();
            smtp.Connect("webmail.mozaikdergi.com", 587, SecureSocketOptions.None);
            smtp.Authenticate(mailModel.Receiver, mailModel.Password);
            smtp.Send(email);
            smtp.Disconnect(true);

            ViewBag.mailSent = "ok";
            ViewBag.page = "contact";
            return View();
        }
    }
}
