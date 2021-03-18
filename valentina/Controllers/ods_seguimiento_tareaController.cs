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
    public class ods_seguimiento_tareaController : Controller
    {
        private Modelo db = new Modelo();

        // GET: ods_seguimiento_tarea
        public ActionResult Index(int? id)
        {
            var ods_seguimiento_tarea = db.ods_seguimiento_tarea.Include(o => o.ods_interesado).Include(o => o.ods_tarea);

            if (id == null)
            {
                ods_seguimiento_tarea = db.ods_seguimiento_tarea.Include(o => o.ods_interesado).Include(o => o.ods_tarea);
                return View(ods_seguimiento_tarea.ToList());
            }

            ods_seguimiento_tarea = from p in db.ods_seguimiento_tarea where (id == p.IdTarea) select p;

            if (ods_seguimiento_tarea == null)
            {
                return HttpNotFound();
            }

            return View(ods_seguimiento_tarea.ToList());
        }

        // GET: ods_seguimiento_tarea/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ods_seguimiento_tarea ods_seguimiento_tarea = db.ods_seguimiento_tarea.Find(id);
            if (ods_seguimiento_tarea == null)
            {
                return HttpNotFound();
            }
            return View(ods_seguimiento_tarea);
        }

        // GET: ods_seguimiento_tarea/Create
        public ActionResult Create(int? idTarea)
        {
            ViewBag.IdInteresado = new SelectList(db.ods_interesado.OrderBy(i => i.Interesado).Where(i => i.Activo == true).ToList(), "IdInteresado", "Interesado");

            if (idTarea == null)
                ViewBag.IdTarea = new SelectList(db.ods_tarea.OrderBy(t => t.Tarea).ToList(), "IdTarea", "Tarea");
            else
                ViewBag.IdTarea = new SelectList(db.ods_tarea.OrderBy(t => t.Tarea).ToList(), "IdTarea", "Tarea", idTarea);

            List<SelectListItem> lstAvance = new List<SelectListItem>();

            for (int valor = 10; valor <= 100; valor+=5)
            {
                SelectListItem item = new SelectListItem();
                item.Text = string.Format("{0:0}", valor);
                item.Value = string.Format("{0:0}", valor);
                lstAvance.Add(item);
            }

            ViewBag.ListaAvance = new SelectList(lstAvance, "Value", "Text");

            return View();
        }

        // POST: ods_seguimiento_tarea/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdSeguimiento,Fecha,Avance,Comentarios,IdInteresado,IdTarea")] ods_seguimiento_tarea ods_seguimiento_tarea)
        {
            if (ModelState.IsValid)
            {
                db.ods_seguimiento_tarea.Add(ods_seguimiento_tarea);
                db.SaveChanges();
                return RedirectToAction(string.Format("../ods_tarea/Index/{0}", ods_seguimiento_tarea.IdTarea));
            }

            ViewBag.IdInteresado = new SelectList(db.ods_interesado.OrderBy(i => i.Interesado).Where(i => i.Activo == true).ToList(), "IdInteresado", "Interesado", ods_seguimiento_tarea.IdInteresado);
            ViewBag.IdTarea = new SelectList(db.ods_tarea.OrderBy(t => t.Tarea).ToList(), "IdTarea", "Tarea", ods_seguimiento_tarea.IdTarea);

            return RedirectToAction(string.Format("../ods_tarea/Index/{0}", ods_seguimiento_tarea.IdTarea));

            //return View(ods_seguimiento_tarea);
        }

        // GET: ods_seguimiento_tarea/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ods_seguimiento_tarea ods_seguimiento_tarea = db.ods_seguimiento_tarea.Find(id);

            if (ods_seguimiento_tarea == null)
            {
                return HttpNotFound();
            }

            ViewBag.IdInteresado = new SelectList(db.ods_interesado.OrderBy(i => i.Interesado).Where(i => i.Activo == true).ToList(), "IdInteresado", "Interesado", ods_seguimiento_tarea.IdInteresado);
            ViewBag.IdTarea = new SelectList(db.ods_tarea.OrderBy(t => t.Tarea).ToList(), "IdTarea", "Tarea", ods_seguimiento_tarea.IdTarea);

            List<SelectListItem> lstAvance = new List<SelectListItem>();

            for (int valor = 10; valor <= 100; valor += 5)
            {
                SelectListItem item = new SelectListItem();
                item.Text = string.Format("{0:0}", valor);
                item.Value = string.Format("{0:0}", valor);
                lstAvance.Add(item);
            }

            ViewBag.ListaAvance = new SelectList(lstAvance, "Value", "Text");

            return View(ods_seguimiento_tarea);
        }

        // POST: ods_seguimiento_tarea/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdSeguimiento,Fecha,Avance,Comentarios,IdInteresado,IdTarea")] ods_seguimiento_tarea ods_seguimiento_tarea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ods_seguimiento_tarea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("../ods_tarea/Index");
            }

            ViewBag.IdInteresado = new SelectList(db.ods_interesado.OrderBy(i => i.Interesado).Where(i => i.Activo == true).ToList(), "IdInteresado", "Interesado", ods_seguimiento_tarea.IdInteresado);
            ViewBag.IdTarea = new SelectList(db.ods_tarea.OrderBy(t => t.Tarea).ToList(), "IdTarea", "Tarea", ods_seguimiento_tarea.IdTarea);
            return RedirectToAction("../ods_tarea/Index");

            //return View(ods_seguimiento_tarea);
        }

        // GET: ods_seguimiento_tarea/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ods_seguimiento_tarea ods_seguimiento_tarea = db.ods_seguimiento_tarea.Find(id);
            if (ods_seguimiento_tarea == null)
            {
                return HttpNotFound();
            }
            return View(ods_seguimiento_tarea);
        }

        // POST: ods_seguimiento_tarea/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ods_seguimiento_tarea ods_seguimiento_tarea = db.ods_seguimiento_tarea.Find(id);
            db.ods_seguimiento_tarea.Remove(ods_seguimiento_tarea);
            db.SaveChanges();
            return RedirectToAction("../ods_tarea/Index");
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
