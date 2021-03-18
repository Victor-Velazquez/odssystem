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
    public class ods_municipioController : Controller
    {
        private Modelo db = new Modelo();

        // GET: ods_municipio
        public ActionResult Index()
        {
            var ods_municipio = db.ods_municipio.Include(o => o.ods_estado);
            return View(ods_municipio.ToList());
        }

        // GET: ods_municipio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ods_municipio ods_municipio = db.ods_municipio.Find(id);
            if (ods_municipio == null)
            {
                return HttpNotFound();
            }
            return View(ods_municipio);
        }

        // GET: ods_municipio/Create
        public ActionResult Create()
        {
            ViewBag.IdEstado = new SelectList(db.ods_estado, "IdEstado", "Estado");
            return View();
        }

        // POST: ods_municipio/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdMunicipio,Municipio,IdEstado")] ods_municipio ods_municipio)
        {
            if (ModelState.IsValid)
            {
                db.ods_municipio.Add(ods_municipio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEstado = new SelectList(db.ods_estado, "IdEstado", "Estado", ods_municipio.IdEstado);
            return View(ods_municipio);
        }

        // GET: ods_municipio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ods_municipio ods_municipio = db.ods_municipio.Find(id);
            if (ods_municipio == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEstado = new SelectList(db.ods_estado, "IdEstado", "Estado", ods_municipio.IdEstado);
            return View(ods_municipio);
        }

        // POST: ods_municipio/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdMunicipio,Municipio,IdEstado")] ods_municipio ods_municipio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ods_municipio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEstado = new SelectList(db.ods_estado, "IdEstado", "Estado", ods_municipio.IdEstado);
            return View(ods_municipio);
        }

        // GET: ods_municipio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ods_municipio ods_municipio = db.ods_municipio.Find(id);
            if (ods_municipio == null)
            {
                return HttpNotFound();
            }
            return View(ods_municipio);
        }

        // POST: ods_municipio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ods_municipio ods_municipio = db.ods_municipio.Find(id);
            db.ods_municipio.Remove(ods_municipio);
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
