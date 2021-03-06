﻿using ProjektNaAplikacjeWWW.DAL;
using ProjektNaAplikacjeWWW.Models;
using System.Net.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;

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
                return RedirectToAction("Index", "Home");
            }
            return View(u);
        }


        public ActionResult Confirm(string s)
        {
            string text = HttpContext.Request.Url.PathAndQuery;
            var lst  = text.Split('/');
            //test
            //using (DatabaseContext db = new DatabaseContext())
            //{
            //    string si = lst.Last();
            //    var g = (from p in db.Registrations where p.ConfirmRegistrationCode.ToString() == si  select p.Uzk.UserID.ToString()).SingleOrDefault();
            //}
            //koniec
                var r = RegistrationRepository.FindByConfirmationCode(new Guid(lst.Last()));
            
            if(r==null || r.EmailExpired<DateTime.Now)
            {
                ViewBag.Result = "Cos poszlo nie tak";
            }
            else
            {
                ViewBag.Result = "rejestracja udana";
                User u = UserRepository.Read(new Guid(RegistrationRepository.GetUserID(lst.Last())));
                UserRepository.ActiveAccount(u);

            }
            return View();
        }

        //sprawdzane loginu w bazie
        [HttpPost]
        public JsonResult IsLoginAvailable(string log)
        {
            var user = UserRepository.IsLoginAvailable(log);
            return Json(user == null);
        }


        //public ActionResult IsLoginAvailabe( string log)
        //{
        //    try
        //    {
        //        var tag = UserRepository.IsLoginAvailable(log);
        //        return Json(false, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception)
        //    {
        //        return Json(true, JsonRequestBehavior.AllowGet);
        //    }

        //}




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
                + @"<a href=""//localhost:51740/User/Confirm/{0}""/>Click</a>",content
                );
            mail.IsBodyHtml = true;



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