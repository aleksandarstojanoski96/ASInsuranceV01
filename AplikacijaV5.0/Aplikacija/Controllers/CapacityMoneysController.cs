using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Aplikacija.Core;
using Repository;

namespace Aplikacija.Controllers
{
    public class CapacityMoneysController : Controller
    {
        private PolicyAPPcontext db = new PolicyAPPcontext();

        // GET: CapacityMoneys
        public ActionResult Index()
        {
            var capacityMoney = db.CapacityMoney.Include(c => c.TypePolicy);
            return View(capacityMoney.ToList());
        }

        // GET: CapacityMoneys/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CapacityMoney capacityMoney = db.CapacityMoney.Find(id);
            if (capacityMoney == null)
            {
                return HttpNotFound();
            }
            return View(capacityMoney);
        }

        // GET: CapacityMoneys/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.TypePolicy, "Id", "Code");
            return View();
        }

        // POST: CapacityMoneys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PowerFrom,PowerTo,Price")] CapacityMoney capacityMoney)
        {
            if (ModelState.IsValid)
            {
                db.CapacityMoney.Add(capacityMoney);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.TypePolicy, "Id", "Code", capacityMoney.Id);
            return View(capacityMoney);
        }

        // GET: CapacityMoneys/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CapacityMoney capacityMoney = db.CapacityMoney.Find(id);
            if (capacityMoney == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.TypePolicy, "Id", "Code", capacityMoney.Id);
            return View(capacityMoney);
        }

        // POST: CapacityMoneys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PowerFrom,PowerTo,Price")] CapacityMoney capacityMoney)
        {
            if (ModelState.IsValid)
            {
                db.Entry(capacityMoney).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.TypePolicy, "Id", "Code", capacityMoney.Id);
            return View(capacityMoney);
        }

        // GET: CapacityMoneys/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CapacityMoney capacityMoney = db.CapacityMoney.Find(id);
            if (capacityMoney == null)
            {
                return HttpNotFound();
            }
            return View(capacityMoney);
        }

        // POST: CapacityMoneys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CapacityMoney capacityMoney = db.CapacityMoney.Find(id);
            db.CapacityMoney.Remove(capacityMoney);
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
