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
    public class DinersController : Controller
    {
        private SplitCheckDBContext db = new SplitCheckDBContext();

        // GET: Diners
        //public ActionResult Index()
        //{
        //    return View(db.Diners.ToList());
        //}

        public ActionResult Index()
        {
            Party p = Session["Party"] as Party;
            if (p.PartyID == 0)
            {
                return View(db.Diners.ToList());
            }
            else
            {
                var diner = db.Diners.ToList();
                DataSet DinersByPartyID = new DataSet();
                for (int i = 0; i < diner.Count; i++) // Loop with for.
                {
                    if (diner[i].PartyID == p.PartyID)
                    {
                        //DinersByPartyID += diner[i]
                    };
                }
                   
                //return View(DinersByPartyID);
                return View(db.Diners.ToList());
            }
        }

        // GET: Diners/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diner diner = db.Diners.Find(id);
            if (diner == null)
            {
                return HttpNotFound();
            }
            return View(diner);
        }

        // GET: Diners/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Diners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DinerID,PartyName,PartyID,DinerName,DinerEntree,DinerDrink,DinerDessert,DinerAppetizer,DinerTotal")] Diner diner)
        {
            if (ModelState.IsValid)
            {
                Party party = db.Parties.Find(diner.PartyID);
                diner.CheckID = party.CheckID;
                diner.DinerTotal = CalculateTotal(diner);
                db.Diners.Add(diner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(diner);
        }

        // GET: Diners/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diner diner = db.Diners.Find(id);
            if (diner == null)
            {
                return HttpNotFound();
            }
            return View(diner);
        }

        // POST: Diners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DinerID,PartyName,PartyID,DinerName,DinerEntree,DinerDrink,DinerDessert,DinerAppetizer,DinerTotal")] Diner diner)
        {
            if (ModelState.IsValid)
            {
                Party party = db.Parties.Find(diner.PartyID);
                diner.CheckID = party.CheckID;
                diner.DinerTotal = CalculateTotal(diner);
                db.Entry(diner).State = EntityState.Modified;
                db.SaveChanges();
                var pc = new PartiesController();
                    pc.CalculatePartyTotals(diner.CheckID, diner.PartyID);
                return RedirectToAction("Index");
            }
            return View(diner);
        }

        // GET: Diners/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diner diner = db.Diners.Find(id);
            if (diner == null)
            {
                return HttpNotFound();
            }
            return View(diner);
        }

        // POST: Diners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Diner diner = db.Diners.Find(id);
            db.Diners.Remove(diner);
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

        private decimal CalculateTotal(Diner diner)
        {
            if (ModelState.IsValid)
            {
                var e = diner.DinerEntree;
                var d = diner.DinerDrink;
                var ds = diner.DinerDessert;
                var da = diner.DinerAppetizer;
                var dt = (e + d + ds + da);
                diner.DinerTotal = dt;
            }

            return diner.DinerTotal;
        }
    }
}
