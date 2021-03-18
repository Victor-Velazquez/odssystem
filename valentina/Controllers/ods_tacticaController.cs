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
    public class ods_tacticaController : Controller
    {
        private Modelo db = new Modelo();

        // GET: ods_tactica
        public ActionResult Index()
        {
            var ods_tactica = db.ods_tactica.Include(o => o.ods_municipio);
            return View(ods_tactica.ToList());
        }

        // GET: ods_tactica/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ods_tactica ods_tactica = db.ods_tactica.Find(id);
            if (ods_tactica == null)
            {
                return HttpNotFound();
            }
            return View(ods_tactica);
        }

        // GET: ods_tactica/Create
        public ActionResult Create()
        {
            ViewBag.IdMunicipio = new SelectList(db.ods_municipio, "IdMunicipio", "Municipio");
            return View();
        }

        // POST: ods_tactica/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTactica,Tactica,Vigente,IdMunicipio")] ods_tactica ods_tactica)
        {
            if (ModelState.IsValid)
            {
                db.ods_tactica.Add(ods_tactica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdMunicipio = new SelectList(db.ods_municipio, "IdMunicipio", "Municipio", ods_tactica.IdMunicipio);
            return View(ods_tactica);
        }

        // GET: ods_tactica/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ods_tactica ods_tactica = db.ods_tactica.Find(id);
            if (ods_tactica == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdMunicipio = new SelectList(db.ods_municipio, "IdMunicipio", "Municipio", ods_tactica.IdMunicipio);
            return View(ods_tactica);
        }

        // POST: ods_tactica/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTactica,Tactica,Vigente,IdMunicipio")] ods_tactica ods_tactica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ods_tactica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdMunicipio = new SelectList(db.ods_municipio, "IdMunicipio", "Municipio", ods_tactica.IdMunicipio);
            return View(ods_tactica);
        }

        // GET: ods_tactica/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ods_tactica ods_tactica = db.ods_tactica.Find(id);
            if (ods_tactica == null)
            {
                return HttpNotFound();
            }
            return View(ods_tactica);
        }

        // POST: ods_tactica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ods_tactica ods_tactica = db.ods_tactica.Find(id);
            db.ods_tactica.Remove(ods_tactica);
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
