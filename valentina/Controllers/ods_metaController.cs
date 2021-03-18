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
    public class ods_metaController : Controller
    {
        private Modelo db = new Modelo();

        // GET: ods_meta
        public ActionResult Index(int? idObjetivo)
        {
            var ods_meta = db.ods_meta.Include(o => o.ods_objetivo);

            if (idObjetivo == null)
            {
                ods_meta = db.ods_meta.Include(o => o.ods_objetivo);
                return View(ods_meta.ToList());
            }

            ods_meta = from p in db.ods_meta where (idObjetivo == p.IdObjetivo) select p;

            if (ods_meta == null)
            {
                return HttpNotFound();
            }

            return View(ods_meta.ToList());
        }

        // GET: ods_meta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ods_meta ods_meta = db.ods_meta.Find(id);
            if (ods_meta == null)
            {
                return HttpNotFound();
            }
            return View(ods_meta);
        }

        // GET: ods_meta/Create
        public ActionResult Create()
        {
            ViewBag.IdObjetivo = new SelectList(db.ods_objetivo, "IdObjetivo", "Objetivo");
            return View();
        }

        // POST: ods_meta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdMeta,Numeral,Meta,IdObjetivo")] ods_meta ods_meta)
        {
            if (ModelState.IsValid)
            {
                db.ods_meta.Add(ods_meta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdObjetivo = new SelectList(db.ods_objetivo, "IdObjetivo", "Objetivo", ods_meta.IdObjetivo);
            return View(ods_meta);
        }

        // GET: ods_meta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ods_meta ods_meta = db.ods_meta.Find(id);
            if (ods_meta == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdObjetivo = new SelectList(db.ods_objetivo, "IdObjetivo", "Objetivo", ods_meta.IdObjetivo);
            return View(ods_meta);
        }

        // POST: ods_meta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdMeta,Numeral,Meta,IdObjetivo")] ods_meta ods_meta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ods_meta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdObjetivo = new SelectList(db.ods_objetivo, "IdObjetivo", "Objetivo", ods_meta.IdObjetivo);
            return View(ods_meta);
        }

        // GET: ods_meta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ods_meta ods_meta = db.ods_meta.Find(id);
            if (ods_meta == null)
            {
                return HttpNotFound();
            }
            return View(ods_meta);
        }

        // POST: ods_meta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ods_meta ods_meta = db.ods_meta.Find(id);
            db.ods_meta.Remove(ods_meta);
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
