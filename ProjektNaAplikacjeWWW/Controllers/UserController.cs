using ProjektNaAplikacjeWWW.DAL;
using ProjektNaAplikacjeWWW.Models;
using System.Net.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace ProjektNaAplikacjeWWW.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public  ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Registration(User u)
        {
            u.AccountType = 0;
            u.Active = false;
            await UserRepository.Create(u);
            return Redirect("Create");
        }


        //EmailControl

        public static void SendMail(string userEmail, string content)
        {

            var fromAdress = new MailAddress("projectappweb@gmail.com", "Ebook Shop App");
            var toAdress = new MailAddress(userEmail);
            //tu wpisac poprawne haslo
            string pass = "";




            MailMessage mail = new MailMessage("projectappweb@gmail.com", userEmail);
            mail.Subject = "witaj";
            mail.Body = content;



            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(fromAdress.Address, pass);


            client.Send(mail);
        }


        
    }
}