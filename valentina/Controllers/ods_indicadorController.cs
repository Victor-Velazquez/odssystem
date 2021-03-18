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
    public class ods_indicadorController : Controller
    {
        private Modelo db = new Modelo();

        // GET: ods_indicador
        public ActionResult Index()
        {
            var ods_indicador = db.ods_indicador.Include(o => o.ods_municipio);
            return View(ods_indicador.ToList());
        }

        // GET: ods_indicador/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ods_indicador ods_indicador = db.ods_indicador.Find(id);
            if (ods_indicador == null)
            {
                return HttpNotFound();
            }
            return View(ods_indicador);
        }

        // GET: ods_indicador/Create
        public ActionResult Create()
        {
            ViewBag.IdMunicipio = new SelectList(db.ods_municipio, "IdMunicipio", "Municipio");
            return View();
        }

        // POST: ods_indicador/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdIndicador,Indicador,Vigente,IdMunicipio")] ods_indicador ods_indicador)
        {
            if (ModelState.IsValid)
            {
                db.ods_indicador.Add(ods_indicador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdMunicipio = new SelectList(db.ods_municipio, "IdMunicipio", "Municipio", ods_indicador.IdMunicipio);
            return View(ods_indicador);
        }

        // GET: ods_indicador/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ods_indicador ods_indicador = db.ods_indicador.Find(id);
            if (ods_indicador == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdMunicipio = new SelectList(db.ods_municipio, "IdMunicipio", "Municipio", ods_indicador.IdMunicipio);
            return View(ods_indicador);
        }

        // POST: ods_indicador/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdIndicador,Indicador,Vigente,IdMunicipio")] ods_indicador ods_indicador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ods_indicador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdMunicipio = new SelectList(db.ods_municipio, "IdMunicipio", "Municipio", ods_indicador.IdMunicipio);
            return View(ods_indicador);
        }

        // GET: ods_indicador/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ods_indicador ods_indicador = db.ods_indicador.Find(id);
            if (ods_indicador == null)
            {
                return HttpNotFound();
            }
            return View(ods_indicador);
        }

        // POST: ods_indicador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ods_indicador ods_indicador = db.ods_indicador.Find(id);
            db.ods_indicador.Remove(ods_indicador);
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
