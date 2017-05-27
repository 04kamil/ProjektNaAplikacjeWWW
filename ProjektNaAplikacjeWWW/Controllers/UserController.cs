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
            
            //SendMail("04kamil@gmail.com", "Witaj tu twoja apka teraz gin");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Registration(User u)
        {
            if (ModelState.IsValid)
            {
                u.AccountType = 0;
                u.Active = false;
                await UserRepository.Create(u);

                //mechanizm uwierzytelniania
                Guid g = Guid.NewGuid();
                await RegistrationRepository.Create(new Registration()
                {
                    ConfirmRegistrationCode = g.ToString(),
                    EmailSend = DateTime.Now,
                    EmailExpired = DateTime.Now.AddDays(2),
                    Uzk = u
                });
                SendMail(u.Email.ToString(),g.ToString());
            }
            return Redirect("Registration");
        }


        public ActionResult Confirm(string s)
        {
            string text = HttpContext.Request.Url.PathAndQuery;
            var lst  = text.Split('/');
            Registration r = RegistrationRepository.FindByConfirmationCode(new Guid(lst.Last()));

            if(r==null)
            {
                ViewBag.Result = "Cos poszlo nie tak";
            }
            else
            {
                ViewBag.Result = "rejestracja udana";
                //Registration reg = RegistrationRepository.FindByConfirmationCode(new Guid(lst.Last()));
                UserRepository.ActiveAccount(r.Uzk.UserID);

            }
            return View();
        }


        //EmailControl

        public static void SendMail(string userEmail, string content)
        {

            var fromAdress = new MailAddress("projectappweb@gmail.com", "Ebook Shop App");
            var toAdress = new MailAddress(userEmail);
            //tu wpisac poprawne haslo
            string pass = "Alfa1234";


            //"localhost:51740/User/Confirm/"

            MailMessage mail = new MailMessage("projectappweb@gmail.com", userEmail);
            mail.Subject = "witaj";
            mail.Body = String.Format(
                "<h3>Welcome to ProjectWebApp</h3>\n"
                +"Please click here to active account\n"
                + @"<a href =""localhost:51740/User/Confirm/""{0}>Click</a>",content
                );



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