﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjektNaAplikacjeWWW.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult ErrorMessage()
        {
            return View();
        }
    }
}