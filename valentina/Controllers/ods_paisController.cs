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
    public class ods_paisController : Controller
    {
        private Modelo db = new Modelo();

        // GET: ods_pais
        public ActionResult Index()
        {
            return View(db.ods_pais.ToList());
        }

        // GET: ods_pais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ods_pais ods_pais = db.ods_pais.Find(id);
            if (ods_pais == null)
            {
                return HttpNotFound();
            }
            return View(ods_pais);
        }

        // GET: ods_pais/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ods_pais/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPais,Pais")] ods_pais ods_pais)
        {
            if (ModelState.IsValid)
            {
                db.ods_pais.Add(ods_pais);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ods_pais);
        }

        // GET: ods_pais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ods_pais ods_pais = db.ods_pais.Find(id);
            if (ods_pais == null)
            {
                return HttpNotFound();
            }
            return View(ods_pais);
        }

        // POST: ods_pais/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPais,Pais")] ods_pais ods_pais)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ods_pais).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ods_pais);
        }

        // GET: ods_pais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ods_pais ods_pais = db.ods_pais.Find(id);
            if (ods_pais == null)
            {
                return HttpNotFound();
            }
            return View(ods_pais);
        }

        // POST: ods_pais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ods_pais ods_pais = db.ods_pais.Find(id);
            db.ods_pais.Remove(ods_pais);
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
