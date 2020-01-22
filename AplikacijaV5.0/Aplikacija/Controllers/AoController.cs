using Aplikacija.Core;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aplikacija.Controllers
{
    public class AoController : Controller
    {
        PolicyRepository p_repo = new PolicyRepository();
        // GET: Ao
        public ActionResult Index()
        {
            return View();
        }

        // GET: Ao/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Ao/Create
        public ActionResult Create()
        {
            ViewBag.ContractorTipkind = new SelectList(p_repo.GetAllTipkinds(), "ID", "Title");
            ViewBag.InsuredTipkind = new SelectList(p_repo.GetAllTipkinds(), "ID", "Title");
            return View();
        }

        // POST: Ao/Create
        [HttpPost]
        public ActionResult Create(PolicyViewModel collection, string contractortipkind, string insuredtipkind)
        {
            try
            {
                string policyID = string.Empty;
                p_repo.SavePolicy(collection, "0", "0", contractortipkind, insuredtipkind, 201, out policyID);
                // TODO: Add insert logic here

                return RedirectToAction("Succes", new { id = int.Parse(policyID) });

            }
            catch
            {
                return View();
            }
        }

        public ActionResult Succes(int id) {
            ViewBag.CapacityMoney = new SelectList(p_repo.GetAllCapacityMoney(), "ID", "Price");
            PolicyViewModel p = p_repo.CapacityToMoney(id);
            return View(p);
        }

        // GET: Ao/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ao/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ao/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ao/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
