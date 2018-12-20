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
    public class OrdersController : Controller
    {
        private PieConstructorEntities db = new PieConstructorEntities();

        // GET: Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Branches).Include(o => o.Compositions).Include(o => o.Forms).Include(o => o.GettinTypes).Include(o => o.PieCatalogs).Include(o => o.Statements);
            return View(orders.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders orders = db.Orders.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            return View(orders);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.Themes = new SelectList(db.Themes, "ID", "Theme");

            ViewBag.BranchID = new SelectList(db.Branches, "ID", "Branch");
            ViewBag.CompositionID = new SelectList(db.Compositions, "ID", "ID");
            ViewBag.FormID = new SelectList(db.Forms, "ID", "Form");
            ViewBag.GettingID = new SelectList(db.GettinTypes, "ID", "GettingType");
            ViewBag.PieID = new SelectList(db.PieCatalogs, "ID", "Pie");
            ViewBag.StatusID = new SelectList(db.Statements, "ID", "Status");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PieID,CompositionID,Weight,FormID,Inscription,Image,Note,Date,GettingID,BranchID,Name,Phone,Sum,StatusID")] Orders orders)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(orders);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BranchID = new SelectList(db.Branches, "ID", "Branch", orders.BranchID);
            ViewBag.CompositionID = new SelectList(db.Compositions, "ID", "ID", orders.CompositionID);
            ViewBag.FormID = new SelectList(db.Forms, "ID", "Form", orders.FormID);
            ViewBag.GettingID = new SelectList(db.GettinTypes, "ID", "GettingType", orders.GettingID);
            ViewBag.PieID = new SelectList(db.PieCatalogs, "ID", "Pie", orders.PieID);
            ViewBag.StatusID = new SelectList(db.Statements, "ID", "Status", orders.StatusID);

            return View(orders);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders orders = db.Orders.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchID = new SelectList(db.Branches, "ID", "Branch", orders.BranchID);
            ViewBag.CompositionID = new SelectList(db.Compositions, "ID", "ID", orders.CompositionID);
            ViewBag.FormID = new SelectList(db.Forms, "ID", "Form", orders.FormID);
            ViewBag.GettingID = new SelectList(db.GettinTypes, "ID", "GettingType", orders.GettingID);
            ViewBag.PieID = new SelectList(db.PieCatalogs, "ID", "Pie", orders.PieID);
            ViewBag.StatusID = new SelectList(db.Statements, "ID", "Status", orders.StatusID);
            return View(orders);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PieID,CompositionID,Weight,FormID,Inscription,Image,Note,Date,GettingID,BranchID,Name,Phone,Sum,StatusID")] Orders orders)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orders).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BranchID = new SelectList(db.Branches, "ID", "Branch", orders.BranchID);
            ViewBag.CompositionID = new SelectList(db.Compositions, "ID", "ID", orders.CompositionID);
            ViewBag.FormID = new SelectList(db.Forms, "ID", "Form", orders.FormID);
            ViewBag.GettingID = new SelectList(db.GettinTypes, "ID", "GettingType", orders.GettingID);
            ViewBag.PieID = new SelectList(db.PieCatalogs, "ID", "Pie", orders.PieID);
            ViewBag.StatusID = new SelectList(db.Statements, "ID", "Status", orders.StatusID);
            return View(orders);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders orders = db.Orders.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            return View(orders);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Orders orders = db.Orders.Find(id);
            db.Orders.Remove(orders);
            db.SaveChanges();
            return RedirectToAction("Index");
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
