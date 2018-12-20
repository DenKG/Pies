using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ExclusiveCakesMVC.Models;

namespace ExclusiveCakesMVC.Controllers
{
    public class PieCatalogsController : Controller
    {
        private PieConstructorEntities db = new PieConstructorEntities();

        // GET: PieCatalogs
        public async Task<ActionResult> Catalog(String searchString)
        {
            ViewBag.Themes = db.Themes;
            //var pieCatalogs = db.PieCatalogs.Include(p => p.Themes);
            var pieCatalogs = from p in db.PieCatalogs select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                pieCatalogs = pieCatalogs.Where(s => s.Themes.Theme.Contains(searchString));
            }

            return View(await pieCatalogs.ToListAsync());
        }

        // GET: PieCatalogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PieCatalogs pieCatalogs = db.PieCatalogs.Find(id);
            if (pieCatalogs == null)
            {
                return HttpNotFound();
            }
            return View(pieCatalogs);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
