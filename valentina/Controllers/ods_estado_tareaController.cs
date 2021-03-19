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
    public class ods_estado_tareaController : Controller
    {
        private Modelo db = new Modelo();


        // GET: ods_estado_tarea
        [Authorize(Roles = "SuperUsuario")]
        public ActionResult Index()
        {
            return View(db.ods_estado_tarea.ToList());
        }

        // GET: ods_estado_tarea/Details/5
        [Authorize(Roles = "SuperUsuario")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ods_estado_tarea ods_estado_tarea = db.ods_estado_tarea.Find(id);
            if (ods_estado_tarea == null)
            {
                return HttpNotFound();
            }
            return View(ods_estado_tarea);
        }

        // GET: ods_estado_tarea/Create
        [Authorize(Roles = "SuperUsuario")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ods_estado_tarea/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEstadoTarea,EstadoTarea")] ods_estado_tarea ods_estado_tarea)
        {
            if (ModelState.IsValid)
            {
                db.ods_estado_tarea.Add(ods_estado_tarea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ods_estado_tarea);
        }

        // GET: ods_estado_tarea/Edit/5
        [Authorize(Roles = "SuperUsuario")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ods_estado_tarea ods_estado_tarea = db.ods_estado_tarea.Find(id);
            if (ods_estado_tarea == null)
            {
                return HttpNotFound();
            }
            return View(ods_estado_tarea);
        }

        // POST: ods_estado_tarea/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEstadoTarea,EstadoTarea")] ods_estado_tarea ods_estado_tarea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ods_estado_tarea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ods_estado_tarea);
        }

        // GET: ods_estado_tarea/Delete/5
        [Authorize(Roles = "SuperUsuario")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ods_estado_tarea ods_estado_tarea = db.ods_estado_tarea.Find(id);
            if (ods_estado_tarea == null)
            {
                return HttpNotFound();
            }
            return View(ods_estado_tarea);
        }

        // POST: ods_estado_tarea/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ods_estado_tarea ods_estado_tarea = db.ods_estado_tarea.Find(id);
            db.ods_estado_tarea.Remove(ods_estado_tarea);
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
