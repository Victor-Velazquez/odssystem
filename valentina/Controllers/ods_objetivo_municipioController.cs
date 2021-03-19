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
    public class ods_objetivo_municipioController : HelperController
    {
        private Modelo db = new Modelo();

        // GET: ods_objetivo_municipio
        public ActionResult Index(int? id)
        {
            ods_interesado ods_interesado = null;
            var ods_objetivo_municipio = db.ods_objetivo_municipio.Include(o => o.ods_municipio);

            try
            {
                if ((ods_interesado = this.ObtenerInteresado()) == null)
                    return RedirectToAction("Autenticar", "Login");

                ViewBag.Interesado = ods_interesado;
            }
            catch (Exception  /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Debe iniciar sesión principalmente.");
            }
            
            return View(ods_objetivo_municipio.ToList());
        }

        // GET: ods_objetivo_municipio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ods_objetivo_municipio ods_objetivo_municipio = db.ods_objetivo_municipio.Find(id);
            if (ods_objetivo_municipio == null)
            {
                return HttpNotFound();
            }
            return View(ods_objetivo_municipio);
        }

        // GET: ods_objetivo_municipio/Create
        public ActionResult Create()
        {
            ViewBag.IdMunicipio = new SelectList(db.ods_municipio.OrderBy(t => t.Municipio).ToList(), "IdMunicipio", "Municipio");
            return View();
        }

        // POST: ods_objetivo_municipio/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdObjetivoMunicipio,Numeral,ObjetivoMunicipio,Vigente,IdMunicipio")] ods_objetivo_municipio ods_objetivo_municipio)
        {
            if (ModelState.IsValid)
            {
                db.ods_objetivo_municipio.Add(ods_objetivo_municipio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdMunicipio = new SelectList(db.ods_municipio.OrderBy(t => t.Municipio).ToList(), "IdMunicipio", "Municipio", ods_objetivo_municipio.IdMunicipio);
            return View(ods_objetivo_municipio);
        }

        // GET: ods_objetivo_municipio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ods_objetivo_municipio ods_objetivo_municipio = db.ods_objetivo_municipio.Find(id);
            if (ods_objetivo_municipio == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdMunicipio = new SelectList(db.ods_municipio.OrderBy(t => t.Municipio).ToList(), "IdMunicipio", "Municipio", ods_objetivo_municipio.IdMunicipio);
            return View(ods_objetivo_municipio);
        }

        // POST: ods_objetivo_municipio/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdObjetivoMunicipio,Numeral,ObjetivoMunicipio,Vigente,IdMunicipio")] ods_objetivo_municipio ods_objetivo_municipio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ods_objetivo_municipio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdMunicipio = new SelectList(db.ods_municipio.OrderBy(t => t.Municipio).ToList(), "IdMunicipio", "Municipio", ods_objetivo_municipio.IdMunicipio);
            return View(ods_objetivo_municipio);
        }

        // GET: ods_objetivo_municipio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ods_objetivo_municipio ods_objetivo_municipio = db.ods_objetivo_municipio.Find(id);
            if (ods_objetivo_municipio == null)
            {
                return HttpNotFound();
            }
            return View(ods_objetivo_municipio);
        }

        // POST: ods_objetivo_municipio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ods_objetivo_municipio ods_objetivo_municipio = db.ods_objetivo_municipio.Find(id);
            db.ods_objetivo_municipio.Remove(ods_objetivo_municipio);
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
