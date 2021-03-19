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
    public class ods_tablero_indicador_ods_vwController : HelperController
    {
        private Modelo db = new Modelo();

        [Authorize(Roles ="SuperUsuario,Administrador,Usuario")] 
        // GET: ods_tablero_indicador_ods_vw
        public ActionResult Index(int? idMunicipio)
        {
            ods_interesado ods_interesado = null;
            IQueryable<ods_tablero_indicador_ods_vw> ods_tablero_indicador_ods_vw = null;

            try
            {
                if ((ods_interesado = (ods_interesado)Session["ods_interesado"]) == null)
                    return RedirectToAction("Autenticar", "Login");

                if (idMunicipio == null)
                    ods_tablero_indicador_ods_vw = db.ods_tablero_indicador_ods_vw;
                else
                {
                    if (idMunicipio != ods_interesado.IdMunicipio)
                        idMunicipio = ods_interesado.IdMunicipio;

                    ods_tablero_indicador_ods_vw = from p in db.ods_tablero_indicador_ods_vw where (ods_interesado.IdMunicipio == p.IdMunicipio) select p;
                }

                if (ods_tablero_indicador_ods_vw == null)
                    return HttpNotFound();

                ViewBag.Interesado = ods_interesado;
            }
            catch (Exception  /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Debe iniciar sesión principalmente.");
            }

            return View(ods_tablero_indicador_ods_vw.ToList());
        }

        [Authorize(Roles = "SuperUsuario,Administrador,Usuario")]
        // GET: ods_tablero_indicador_ods_vw/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ods_tablero_indicador_ods_vw ods_tablero_indicador_ods_vw = db.ods_tablero_indicador_ods_vw.Find(id);

            if (ods_tablero_indicador_ods_vw == null)
            {
                return HttpNotFound();
            }

            return View(ods_tablero_indicador_ods_vw);
        }

        // GET: ods_tablero_indicador_ods_vw/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ods_tablero_indicador_ods_vw/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdMunicipio,Municipio,Anio,IdObjetivo,Objetivo,MetasODS,ObjetivosMunicipio,MetasMunicipio,IndicadoresMunicipio,Avance")] ods_tablero_indicador_ods_vw ods_tablero_indicador_ods_vw)
        {
            if (ModelState.IsValid)
            {
                db.ods_tablero_indicador_ods_vw.Add(ods_tablero_indicador_ods_vw);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ods_tablero_indicador_ods_vw);
        }

        // GET: ods_tablero_indicador_ods_vw/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ods_tablero_indicador_ods_vw ods_tablero_indicador_ods_vw = db.ods_tablero_indicador_ods_vw.Find(id);
            if (ods_tablero_indicador_ods_vw == null)
            {
                return HttpNotFound();
            }
            return View(ods_tablero_indicador_ods_vw);
        }

        // POST: ods_tablero_indicador_ods_vw/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdMunicipio,Municipio,Anio,IdObjetivo,Objetivo,MetasODS,ObjetivosMunicipio,MetasMunicipio,IndicadoresMunicipio,Avance")] ods_tablero_indicador_ods_vw ods_tablero_indicador_ods_vw)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ods_tablero_indicador_ods_vw).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ods_tablero_indicador_ods_vw);
        }

        // GET: ods_tablero_indicador_ods_vw/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ods_tablero_indicador_ods_vw ods_tablero_indicador_ods_vw = db.ods_tablero_indicador_ods_vw.Find(id);
            if (ods_tablero_indicador_ods_vw == null)
            {
                return HttpNotFound();
            }
            return View(ods_tablero_indicador_ods_vw);
        }

        // POST: ods_tablero_indicador_ods_vw/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ods_tablero_indicador_ods_vw ods_tablero_indicador_ods_vw = db.ods_tablero_indicador_ods_vw.Find(id);
            db.ods_tablero_indicador_ods_vw.Remove(ods_tablero_indicador_ods_vw);
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
