using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GregsCheckSplitter4.Models;

namespace GregsCheckSplitter4.Controllers
{
    public class ChecksController : Controller
    {
        private SplitCheckDBContext db = new SplitCheckDBContext();

        // GET: Checks
        public ActionResult Index()
        {
            return View(db.Checks.ToList());
        }

        // GET: Checks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           // int id = 1;
            Check check = db.Checks.Find(id);
            if (check == null)
            {
                return HttpNotFound();
            }
            return View(check);
        }

        // GET: Checks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Checks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CheckID,CheckName,CheckTotal,TaxPercentage,CheckTaxTotal,TipPercentage,CheckTipTotal,CheckGrandTotal")] Check check)
        {
            if (ModelState.IsValid)
            {
                db.Checks.Add(check);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(check);
        }

        // GET: Checks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Check check = db.Checks.Find(id);
            if (check == null)
            {
                return HttpNotFound();
            }
            return View(check);
        }

        // POST: Checks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CheckID,CheckName,CheckTotal,TaxPercentage,CheckTaxTotal,TipPercentage,CheckTipTotal,CheckGrandTotal")] Check check)
        {
            if (ModelState.IsValid)
            {
                db.Entry(check).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(check);
        }

        // GET: Checks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Check check = db.Checks.Find(id);
            if (check == null)
            {
                return HttpNotFound();
            }
            return View(check);
        }

        // POST: Checks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Check check = db.Checks.Find(id);
            db.Checks.Remove(check);
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
