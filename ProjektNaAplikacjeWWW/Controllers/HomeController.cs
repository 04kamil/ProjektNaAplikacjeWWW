using ProjektNaAplikacjeWWW.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjektNaAplikacjeWWW.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DatabaseContext db = new DatabaseContext();
            db.Users.Add(new Models.User { FirstName = "alfa", LastName = "beta", Active = false, AccountType = 1, Email = "email@email.com",
                Login = "alfabeta",Password="pas",Phone="123123132",UserID = Guid.NewGuid() });
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}