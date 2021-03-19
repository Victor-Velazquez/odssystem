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
        private readonly Modelo db = new Modelo();

        // GET: ods_indicador
        [Authorize(Roles = "SuperUsuario,Administrador")]
        public ActionResult Index(int? id)
        {
            ods_interesado ods_interesado = null;
            IQueryable<ods_indicador> ods_indicador = null;

            try
            {
                if ((ods_interesado = (ods_interesado)Session["ods_interesado"]) == null)
                    return RedirectToAction("Autenticar", "Login");

                if (id == null)
                    ods_indicador = db.ods_indicador;
                else
                {
                    if (id != ods_interesado.IdMunicipio)
                        id = ods_interesado.IdMunicipio;

                    ods_indicador = from p in db.ods_indicador where (id == p.IdMunicipio) select p;
                }
                    
                if (ods_indicador == null)
                    return HttpNotFound();

                ViewBag.Interesado = ods_interesado;
            }
            catch (Exception  /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Debe iniciar sesión principalmente.");
            }

            return View(ods_indicador.ToList());
        }

        // GET: ods_indicador/Details/5
        [Authorize(Roles = "SuperUsuario,Administrador")]
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
        [Authorize(Roles = "SuperUsuario,Administrador")]
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
        [Authorize(Roles = "SuperUsuario,Administrador")]
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
        [Authorize(Roles = "SuperUsuario,Administrador")]
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
