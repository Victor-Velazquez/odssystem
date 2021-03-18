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
    public class ods_tareaController : Controller
    {
        private Modelo db = new Modelo();

        // GET: ods_tarea
        public ActionResult Index()
        {
            var ods_tarea = db.ods_tarea.Include(o => o.ods_estado_tarea).Include(o => o.ods_interesado).Include(o => o.ods_meta_municipio).Include(o => o.ods_tactica);
            return View(ods_tarea.ToList());
        }

        // GET: ods_tarea/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ods_tarea ods_tarea = db.ods_tarea.Find(id);

            if (ods_tarea == null)
            {
                return HttpNotFound();
            }
            return View(ods_tarea);
        }

        // GET: ods_tarea/Create
        public ActionResult Create()
        {
            ViewBag.IdEstadoTarea = new SelectList(db.ods_estado_tarea.OrderBy(ta => ta.EstadoTarea).ToList(), "IdEstadoTarea", "EstadoTarea");
            ViewBag.IdInteresado = new SelectList(db.ods_interesado.OrderBy(i => i.Interesado).Where(i => i.Activo == true).ToList(), "IdInteresado", "Interesado");
            ViewBag.IdMetaMunicipio = new SelectList(db.ods_meta_municipio.OrderBy(m => m.MetaMuncipio).Where(m => m.Cumplida == false).ToList(), "IdMetaMunicipio", "MetaMuncipio");
            ViewBag.IdTactica = new SelectList(db.ods_tactica.OrderBy(t => t.Tactica).Where(t => t.Vigente == true).ToList(), "IdTactica", "Tactica");

            return View();
        }

        // POST: ods_tarea/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTarea,Tarea,FechaInicio,FechaTermino,FechaInicioReal,FechaTerminoReal,Avance,IdEstadoTarea,IdTactica,IdInteresado,IdMetaMunicipio")] ods_tarea ods_tarea)
        {
            if (ModelState.IsValid)
            {
                ods_tarea.IdEstadoTarea = 1;
                db.ods_tarea.Add(ods_tarea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEstadoTarea = new SelectList(db.ods_estado_tarea.OrderBy(ta => ta.EstadoTarea).ToList(), "IdEstadoTarea", "EstadoTarea", ods_tarea.IdEstadoTarea);
            ViewBag.IdInteresado = new SelectList(db.ods_interesado.OrderBy(i => i.Interesado).Where(i => i.Activo == true).ToList(), "IdInteresado", "Interesado", ods_tarea.IdInteresado);
            ViewBag.IdMetaMunicipio = new SelectList(db.ods_meta_municipio.OrderBy(m => m.MetaMuncipio).Where(m => m.Cumplida == false).ToList(), "IdMetaMunicipio", "MetaMuncipio", ods_tarea.IdMetaMunicipio);
            ViewBag.IdTactica = new SelectList(db.ods_tactica.OrderBy(t => t.Tactica).Where(t => t.Vigente == true).ToList(), "IdTactica", "Tactica", ods_tarea.IdTactica);

            return View(ods_tarea);
        }

        // GET: ods_tarea/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ods_tarea ods_tarea = db.ods_tarea.Find(id);

            if (ods_tarea == null)
            {
                return HttpNotFound();
            }

            ViewBag.IdEstadoTarea = new SelectList(db.ods_estado_tarea.OrderBy(ta => ta.EstadoTarea).ToList(), "IdEstadoTarea", "EstadoTarea", ods_tarea.IdEstadoTarea);
            ViewBag.IdInteresado = new SelectList(db.ods_interesado.OrderBy(i => i.Interesado).Where(i => i.Activo == true).ToList(), "IdInteresado", "Interesado", ods_tarea.IdInteresado);
            ViewBag.IdMetaMunicipio = new SelectList(db.ods_meta_municipio.OrderBy(m => m.MetaMuncipio).Where(m => m.Cumplida == false).ToList(), "IdMetaMunicipio", "MetaMuncipio", ods_tarea.IdMetaMunicipio);
            ViewBag.IdTactica = new SelectList(db.ods_tactica.OrderBy(t => t.Tactica).Where(t => t.Vigente == true).ToList(), "IdTactica", "Tactica", ods_tarea.IdTactica);

            //ViewBag.IdEstadoTarea = new SelectList(db.ods_estado_tarea, "IdEstadoTarea", "EstadoTarea", ods_tarea.IdEstadoTarea);
            //ViewBag.IdInteresado = new SelectList(db.ods_interesado, "IdInteresado", "Interesado", ods_tarea.IdInteresado);
            //ViewBag.IdMetaMunicipio = new SelectList(db.ods_meta_municipio, "IdMetaMunicipio", "MetaMuncipio", ods_tarea.IdMetaMunicipio);
            //ViewBag.IdTactica = new SelectList(db.ods_tactica, "IdTactica", "Tactica", ods_tarea.IdTactica);

            return View(ods_tarea);
        }

        // POST: ods_tarea/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTarea,Tarea,FechaInicio,FechaTermino,FechaInicioReal,FechaTerminoReal,Avance,IdEstadoTarea,IdTactica,IdInteresado,IdMetaMunicipio")] ods_tarea ods_tarea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ods_tarea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            ViewBag.IdEstadoTarea = new SelectList(db.ods_estado_tarea.OrderBy(ta => ta.EstadoTarea).ToList(), "IdEstadoTarea", "EstadoTarea", ods_tarea.IdEstadoTarea);
            ViewBag.IdInteresado = new SelectList(db.ods_interesado.OrderBy(i => i.Interesado).Where(i => i.Activo == true).ToList(), "IdInteresado", "Interesado", ods_tarea.IdInteresado);
            ViewBag.IdMetaMunicipio = new SelectList(db.ods_meta_municipio.OrderBy(m => m.MetaMuncipio).Where(m => m.Cumplida == false).ToList(), "IdMetaMunicipio", "MetaMuncipio", ods_tarea.IdMetaMunicipio);
            ViewBag.IdTactica = new SelectList(db.ods_tactica.OrderBy(t => t.Tactica).Where(t => t.Vigente == true).ToList(), "IdTactica", "Tactica", ods_tarea.IdTactica);
            return View(ods_tarea);
        }

        // GET: ods_tarea/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ods_tarea ods_tarea = db.ods_tarea.Find(id);
            if (ods_tarea == null)
            {
                return HttpNotFound();
            }
            return View(ods_tarea);
        }

        // POST: ods_tarea/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ods_tarea ods_tarea = db.ods_tarea.Find(id);
            db.ods_tarea.Remove(ods_tarea);
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
