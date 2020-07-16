using straks_nl.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace straks_nl.Web.Features.Pages
{
    public class HomeController : Controller
    {
        public HomeController(ApplicationDbContext db)
        {
           var temp =  db.Articles.ToList();
        }
        public ActionResult Index()
        {
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