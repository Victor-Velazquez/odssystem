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
    public class ods_estadoController : Controller
    {
        private Modelo db = new Modelo();

        // GET: ods_estado
        [Authorize(Roles = "SuperUsuario")]
        public ActionResult Index()
        {
            var ods_estado = db.ods_estado.Include(o => o.ods_pais);
            return View(ods_estado.ToList());
        }

        // GET: ods_estado/Details/5
        [Authorize(Roles = "SuperUsuario")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ods_estado ods_estado = db.ods_estado.Find(id);
            if (ods_estado == null)
            {
                return HttpNotFound();
            }
            return View(ods_estado);
        }

        // GET: ods_estado/Create
        [Authorize(Roles = "SuperUsuario")]
        public ActionResult Create()
        {
            ViewBag.IdPais = new SelectList(db.ods_pais, "IdPais", "Pais");
            return View();
        }

        // POST: ods_estado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEstado,Estado,IdPais")] ods_estado ods_estado)
        {
            if (ModelState.IsValid)
            {
                db.ods_estado.Add(ods_estado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdPais = new SelectList(db.ods_pais, "IdPais", "Pais", ods_estado.IdPais);
            return View(ods_estado);
        }

        // GET: ods_estado/Edit/5
        [Authorize(Roles = "SuperUsuario")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ods_estado ods_estado = db.ods_estado.Find(id);
            if (ods_estado == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPais = new SelectList(db.ods_pais, "IdPais", "Pais", ods_estado.IdPais);
            return View(ods_estado);
        }

        // POST: ods_estado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEstado,Estado,IdPais")] ods_estado ods_estado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ods_estado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPais = new SelectList(db.ods_pais, "IdPais", "Pais", ods_estado.IdPais);
            return View(ods_estado);
        }

        // GET: ods_estado/Delete/5
        [Authorize(Roles = "SuperUsuario")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ods_estado ods_estado = db.ods_estado.Find(id);
            if (ods_estado == null)
            {
                return HttpNotFound();
            }
            return View(ods_estado);
        }

        // POST: ods_estado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ods_estado ods_estado = db.ods_estado.Find(id);
            db.ods_estado.Remove(ods_estado);
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
