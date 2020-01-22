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
    public class TypePoliciesController : Controller
    {
        private PolicyAPPcontext db = new PolicyAPPcontext();

        // GET: TypePolicies
        public ActionResult Index()
        {
            var typePolicy = db.TypePolicy.Include(t => t.CapacityMoney);
            return View(typePolicy.ToList());
        }

        // GET: TypePolicies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypePolicy typePolicy = db.TypePolicy.Find(id);
            if (typePolicy == null)
            {
                return HttpNotFound();
            }
            return View(typePolicy);
        }

        // GET: TypePolicies/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.CapacityMoney, "Id", "Id");
            return View();
        }

        // POST: TypePolicies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Code,Name,Status")] TypePolicy typePolicy)
        {
            if (ModelState.IsValid)
            {
                db.TypePolicy.Add(typePolicy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.CapacityMoney, "Id", "Id", typePolicy.Id);
            return View(typePolicy);
        }

        // GET: TypePolicies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypePolicy typePolicy = db.TypePolicy.Find(id);
            if (typePolicy == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.CapacityMoney, "Id", "Id", typePolicy.Id);
            return View(typePolicy);
        }

        // POST: TypePolicies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,Name,Status")] TypePolicy typePolicy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typePolicy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.CapacityMoney, "Id", "Id", typePolicy.Id);
            return View(typePolicy);
        }

        // GET: TypePolicies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypePolicy typePolicy = db.TypePolicy.Find(id);
            if (typePolicy == null)
            {
                return HttpNotFound();
            }
            return View(typePolicy);
        }

        // POST: TypePolicies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TypePolicy typePolicy = db.TypePolicy.Find(id);
            db.TypePolicy.Remove(typePolicy);
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
