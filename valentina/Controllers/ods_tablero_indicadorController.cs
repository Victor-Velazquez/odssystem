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
    public class ods_tablero_indicadorController : Controller
    {
        private Modelo db = new Modelo();

        // GET: ods_tablero_indicador
        public ActionResult Index()
        {
            var ods_tablero_indicador = db.ods_tablero_indicador.Include(o => o.ods_indicador);
            return View(ods_tablero_indicador.ToList());
        }

        // GET: ods_tablero_indicador/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ods_tablero_indicador ods_tablero_indicador = db.ods_tablero_indicador.Find(id);
            if (ods_tablero_indicador == null)
            {
                return HttpNotFound();
            }
            return View(ods_tablero_indicador);
        }

        // GET: ods_tablero_indicador/Create
        public ActionResult Create()
        {
            ViewBag.IdIndicador = new SelectList(db.ods_indicador.OrderBy(t => t.Indicador).Where(t => t.Vigente == true).ToList(), "IdIndicador", "Indicador");

            List<SelectListItem> lstAnio = new List<SelectListItem>();

            for (int valor = DateTime.Now.Year - 1; valor <= 2050; valor++)
            {
                SelectListItem item = new SelectListItem();
                item.Text = string.Format("{0:0}", valor);
                item.Value = string.Format("{0:0}", valor);
                lstAnio.Add(item);
            }

            ViewBag.ListaAnios = new SelectList(lstAnio, "Value", "Text");

            return View();
        }

        // POST: ods_tablero_indicador/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTableroIndicador,Anio,ValorIndicador,ValorAlcanzado,EscalaPositiva,ods_objetivos,ods_metas,municipio_objetivos,municipio_metas,municipio_tacticas,municipio_tareas,IdIndicador")] ods_tablero_indicador ods_tablero_indicador)
        {
            if (ModelState.IsValid)
            {
                db.ods_tablero_indicador.Add(ods_tablero_indicador);
                db.SaveChanges();
                return RedirectToAction("Index", "ods_tablero_indicador_ods_vw");                
            }

            ViewBag.IdIndicador = new SelectList(db.ods_indicador.OrderBy(t => t.Indicador).Where(t => t.Vigente == true).ToList(), "IdIndicador", "Indicador", ods_tablero_indicador.IdIndicador);
            return RedirectToAction("Index", "ods_tablero_indicador_ods_vw");
        }

        //GET: Autocompletar
       [HttpGet]
        public ActionResult ObtenerIndicadores(string term)
        {
            var objCustomerlist = db.ods_indicador.Where(i => i.Vigente == true)
                                 .Where(i => i.Indicador.ToUpper().Contains(term.ToUpper()))
                                 .Select(i => new { Name = i.Indicador, ID = i.IdIndicador })
                                 .Distinct().ToList();

            return Json(objCustomerlist, JsonRequestBehavior.AllowGet);
        }

        // GET: ods_tablero_indicador/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ods_tablero_indicador ods_tablero_indicador = db.ods_tablero_indicador.Find(id);

            if (ods_tablero_indicador == null)
            {
                return HttpNotFound();
            }

            ViewBag.IdIndicador = new SelectList(db.ods_indicador.OrderBy(t => t.Indicador).Where(t => t.Vigente == true).ToList(), "IdIndicador", "Indicador", ods_tablero_indicador.IdIndicador);

            List<SelectListItem> lstAnio = new List<SelectListItem>();

            for (int valor = DateTime.Now.Year - 1; valor <= 2050; valor++)
            {
                SelectListItem item = new SelectListItem();
                item.Text = string.Format("{0:0}", valor);
                item.Value = string.Format("{0:0}", valor);
                lstAnio.Add(item);
            }

            ViewBag.ListaAnios = new SelectList(lstAnio, "Value", "Text");

            return View(ods_tablero_indicador);
        }

        // POST: ods_tablero_indicador/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTableroIndicador,Anio,ValorIndicador,ValorAlcanzado,EscalaPositiva,ods_objetivos,ods_metas,municipio_objetivos,municipio_metas,municipio_tacticas,municipio_tareas,IdIndicador")] ods_tablero_indicador ods_tablero_indicador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ods_tablero_indicador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "ods_tablero_indicador_ods_vw");
            }

            ViewBag.IdIndicador = new SelectList(db.ods_indicador.OrderBy(t => t.Indicador).Where(t => t.Vigente == true).ToList(), "IdIndicador", "Indicador", ods_tablero_indicador.IdIndicador);
            return RedirectToAction("Index", "ods_tablero_indicador_ods_vw");
        }

        // GET: ods_tablero_indicador/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ods_tablero_indicador ods_tablero_indicador = db.ods_tablero_indicador.Find(id);
            if (ods_tablero_indicador == null)
            {
                return HttpNotFound();
            }
            return View(ods_tablero_indicador);
        }

        // POST: ods_tablero_indicador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ods_tablero_indicador ods_tablero_indicador = db.ods_tablero_indicador.Find(id);
            db.ods_tablero_indicador.Remove(ods_tablero_indicador);
            db.SaveChanges();
            return RedirectToAction("Index", "ods_tablero_indicador_ods_vw");
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
