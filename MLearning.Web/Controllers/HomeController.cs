
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MLearning.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            /* (!Request.IsAuthenticated)
            {
                return 
            }*/
            var a = Request.IsAuthenticated;
            return View();
        }

        public ActionResult Index0()
        {
            return PartialView();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return PartialView();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return PartialView();
        }
    }
}