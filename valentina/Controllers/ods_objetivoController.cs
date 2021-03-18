using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ODS.DataLayer;

namespace valentina.Controllers
{
    public class ods_objetivoController : Controller
    {
        private Modelo db = new Modelo();

        // GET: ods_objetivo
        public ActionResult Index()
        {
            return View(db.ods_objetivo.ToList());
        }

        // GET: ods_objetivo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ods_objetivo ods_objetivo = db.ods_objetivo.Find(id);
            if (ods_objetivo == null)
            {
                return HttpNotFound();
            }
            return View(ods_objetivo);
        }

        // GET: ods_objetivo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ods_objetivo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdObjetivo,Objetivo")] ods_objetivo ods_objetivo)
        {
            if (ModelState.IsValid)
            {
                db.ods_objetivo.Add(ods_objetivo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ods_objetivo);
        }

        // GET: ods_objetivo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ods_objetivo ods_objetivo = db.ods_objetivo.Find(id);
            if (ods_objetivo == null)
            {
                return HttpNotFound();
            }
            return View(ods_objetivo);
        }

        // POST: ods_objetivo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdObjetivo,Objetivo")] ods_objetivo ods_objetivo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ods_objetivo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ods_objetivo);
        }

        // GET: ods_objetivo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ods_objetivo ods_objetivo = db.ods_objetivo.Find(id);
            if (ods_objetivo == null)
            {
                return HttpNotFound();
            }
            return View(ods_objetivo);
        }

        // POST: ods_objetivo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ods_objetivo ods_objetivo = db.ods_objetivo.Find(id);
            db.ods_objetivo.Remove(ods_objetivo);
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
