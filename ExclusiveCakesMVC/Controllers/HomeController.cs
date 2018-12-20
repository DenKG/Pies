using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExclusiveCakesMVC.Models;

namespace ExclusiveCakesMVC.Controllers
{
    public class HomeController : Controller
    {
        private PieConstructorEntities db = new PieConstructorEntities(); //Контекст БД

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

        public ActionResult Order()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Products()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.Themes = db.Themes;

            return View();
        }

        public ActionResult DesignConstruct()
        {
            ViewBag.Message = "Your contact page.";

            //ViewBag.Themes = db.Themes.Select(p => new { p });
            //ViewBag.Forms = new SelectList(db.Forms, "Form");

            ViewBag.Themes = db.Themes;
            ViewBag.Forms = db.Forms;
                 
            return View();
        }
    }
}