using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GregsCheckSplitter4.Models;

namespace GregsCheckSplitter4.Controllers
{
    public class HomeController : Controller
    {
        private SplitCheckDBContext db = new SplitCheckDBContext();
        public ActionResult Index()
        {
            return View(db.Checks.ToList());
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