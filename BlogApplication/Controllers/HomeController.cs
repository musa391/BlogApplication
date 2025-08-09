using System.Diagnostics;
using BlogApplication.Models;
using Microsoft.AspNetCore.Mvc;
using BlogApplication.Context;
using System.Net.Mail;
using System.Net;

namespace BlogApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly BlogDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(BlogDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var posts = _context.Posts
                .Where(p => p.IsPublished)
                .OrderByDescending(p => p.YayýmlanmaTarihi)
                .ToList(); // ? Burasý önemli

            return View(posts);
        }


        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Contact(string name,string email, string phone, string message)
        {
            try
            {
            SendEmail(name, email, phone, message);
            ViewBag.Message = "Mesajýnýz baþarýyla gönderildi.";
            }
           catch(Exception ex)
            {
                ViewBag.Error = "Mesajýnýz gönderilirken bir hata oluþtu: ";
            }
            return View();
        }
        public void SendEmail(string name, string email, string phone, string message)
        {
            var mail = new MailMessage();
            mail.From = new MailAddress("musaa.sahn66@gmail.com");
            mail.To.Add("musaa.sahn66@gmail.com");
            mail.Subject = "Yeni Ýletiþim Formu Mesajý";
            mail.Body = $"Ýsim:{name} \n Email:{email} \n Telefon:{phone} \n Mesaj:{message}";

            var smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("musaa.sahn66@gmail.com", "cgix uwju kpnd pbjh"),
                EnableSsl = true
            };
            smtp.Send(mail);

        }
         

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
