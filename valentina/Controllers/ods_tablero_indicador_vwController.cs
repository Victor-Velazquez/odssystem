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
    public class ods_tablero_indicador_vwController : Controller
    {
        private Modelo db = new Modelo();

        // GET: ods_tablero_indicador_vw
        public ActionResult Index()
        {
            return View(db.ods_tablero_indicador_vw.ToList());
        }

        // GET: ods_tablero_indicador_vw/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ods_tablero_indicador_vw ods_tablero_indicador_vw = db.ods_tablero_indicador_vw.Find(id);
            if (ods_tablero_indicador_vw == null)
            {
                return HttpNotFound();
            }
            return View(ods_tablero_indicador_vw);
        }

        // GET: ods_tablero_indicador_vw/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ods_tablero_indicador_vw/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdIndicador,Anio,Municipio,Indicador,ValorIndicador,ValorAlcanzado,EscalaPositiva,ods_objetivos,ods_metas,municipio_objetivos,municipio_metas,municipio_tacticas,municipio_tareas,IdMunicipio,Vigente")] ods_tablero_indicador_vw ods_tablero_indicador_vw)
        {
            if (ModelState.IsValid)
            {
                db.ods_tablero_indicador_vw.Add(ods_tablero_indicador_vw);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ods_tablero_indicador_vw);
        }

        // GET: ods_tablero_indicador_vw/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ods_tablero_indicador_vw ods_tablero_indicador_vw = db.ods_tablero_indicador_vw.Find(id);
            if (ods_tablero_indicador_vw == null)
            {
                return HttpNotFound();
            }
            return View(ods_tablero_indicador_vw);
        }

        // POST: ods_tablero_indicador_vw/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdIndicador,Anio,Municipio,Indicador,ValorIndicador,ValorAlcanzado,EscalaPositiva,ods_objetivos,ods_metas,municipio_objetivos,municipio_metas,municipio_tacticas,municipio_tareas,IdMunicipio,Vigente")] ods_tablero_indicador_vw ods_tablero_indicador_vw)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ods_tablero_indicador_vw).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ods_tablero_indicador_vw);
        }

        // GET: ods_tablero_indicador_vw/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ods_tablero_indicador_vw ods_tablero_indicador_vw = db.ods_tablero_indicador_vw.Find(id);
            if (ods_tablero_indicador_vw == null)
            {
                return HttpNotFound();
            }
            return View(ods_tablero_indicador_vw);
        }

        // POST: ods_tablero_indicador_vw/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ods_tablero_indicador_vw ods_tablero_indicador_vw = db.ods_tablero_indicador_vw.Find(id);
            db.ods_tablero_indicador_vw.Remove(ods_tablero_indicador_vw);
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
