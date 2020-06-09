using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SendEmail.Models;
using System.Net;
using System.Net.Mail;

namespace SendEmail.Controllers
{
    public class EmailSetupController : Controller
    {
        // GET: EmailSetup
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(SendEmail.Models.gmail model)
        {
            MailMessage mm = new MailMessage("for.rohan002@gmail.com", model.To);
            mm.Subject = model.Subject;
            mm.Body = model.Body;
            mm.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            NetworkCredential nc = new NetworkCredential("for.rohan002@gmail.com", "mynameis(kribo)");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            smtp.Send(mm);
            ViewBag.Message = "Email Sudah Terkirim";
            return View();
        }
    }
}