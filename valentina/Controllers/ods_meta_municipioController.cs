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
    public class ods_meta_municipioController : Controller
    {
        private Modelo db = new Modelo();

        // GET: ods_meta_municipio
        public ActionResult Index(int? id)
        {
            var ods_meta_municipio = db.ods_meta_municipio.Include(o => o.ods_indicador).Include(o => o.ods_objetivo_municipio);

            if (id == null)
            {
                ods_meta_municipio = db.ods_meta_municipio.Include(o => o.ods_indicador).Include(o => o.ods_objetivo_municipio);
                return View(ods_meta_municipio.ToList());
            }

            ods_meta_municipio = from p in db.ods_meta_municipio where (id == p.IdObjetivoMunicipio) select p;

            if (ods_meta_municipio == null)
            {
                return HttpNotFound();
            }

            return View(ods_meta_municipio.ToList());
        }

        // GET: ods_meta_municipio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ods_meta_municipio ods_meta_municipio = db.ods_meta_municipio.Find(id);

            if (ods_meta_municipio == null)
            {
                return HttpNotFound();
            }
            return View(ods_meta_municipio);
        }

        // GET: ods_meta_municipio/Create
        public ActionResult Create()
        {
            int? idMunicipio = null;

            if (Session["ods_interesado"] != null)
            {
                ods_interesado interesado = (ODS.DataLayer.ods_interesado) Session["ods_interesado"];
                idMunicipio = interesado.IdMunicipio;
            }

            if ( idMunicipio == null)
            {
                ViewBag.IdIndicador = new SelectList(db.ods_indicador.Where(i => i.Vigente == true).OrderBy(i => i.Indicador).ToList(), "IdIndicador", "Indicador");
                ViewBag.IdObjetivoMunicipio = new SelectList(db.ods_objetivo_municipio.OrderBy(o => o.ObjetivoMunicipio).Where(o => o.Vigente == true).ToList(), "IdObjetivoMunicipio", "ObjetivoMunicipio");
            }
            else
            {
                ViewBag.IdIndicador = new SelectList(db.ods_indicador.Where(i => i.Vigente == true && i.IdMunicipio == idMunicipio).OrderBy(i => i.Indicador).ToList(), "IdIndicador", "Indicador");
                ViewBag.IdObjetivoMunicipio = new SelectList(db.ods_objetivo_municipio.Where(o => o.Vigente == true && o.IdMunicipio == idMunicipio).OrderBy(o => o.ObjetivoMunicipio).ToList(), "IdObjetivoMunicipio", "ObjetivoMunicipio");
            }

            List<SelectListItem> lstAnio = new List<SelectListItem>();

            for (int valor = DateTime.Now.Year - 1; valor <= 2050; valor ++)
            {
                SelectListItem item = new SelectListItem();
                item.Text = string.Format("{0:0}", valor);
                item.Value = string.Format("{0:0}", valor);
                lstAnio.Add(item);
            }

            ViewBag.ListaAnios = new SelectList(lstAnio, "Value", "Text");

            return View();
        }

        // POST: ods_meta_municipio/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdMetaMunicipio,MetaMuncipio,Anio,FechaInicio,FechaTermino,DebeCumplirse,EscalaPositiva,IdIndicador,IdObjetivoMunicipio")] ods_meta_municipio ods_meta_municipio)
        {
            if (ModelState.IsValid)
            {
                db.ods_meta_municipio.Add(ods_meta_municipio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdIndicador = new SelectList(db.ods_indicador.OrderBy(i => i.Indicador).Where(i => i.Vigente == true).ToList(), "IdIndicador", "Indicador", ods_meta_municipio.IdIndicador);
            ViewBag.IdObjetivoMunicipio = new SelectList(db.ods_objetivo_municipio.OrderBy(o => o.ObjetivoMunicipio).Where(o => o.Vigente == true).ToList(), "IdObjetivoMunicipio", "ObjetivoMunicipio", ods_meta_municipio.IdObjetivoMunicipio);
            return View(ods_meta_municipio);
        }

        // GET: ods_meta_municipio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ods_meta_municipio ods_meta_municipio = db.ods_meta_municipio.Find(id);

            if (ods_meta_municipio == null)
            {
                return HttpNotFound();
            }

            ViewBag.IdIndicador = new SelectList(db.ods_indicador.OrderBy(i => i.Indicador).Where(i => i.Vigente == true).ToList(), "IdIndicador", "Indicador", ods_meta_municipio.IdIndicador);
            ViewBag.IdObjetivoMunicipio = new SelectList(db.ods_objetivo_municipio.OrderBy(o => o.ObjetivoMunicipio).Where(o => o.Vigente == true).ToList(), "IdObjetivoMunicipio", "ObjetivoMunicipio", ods_meta_municipio.IdObjetivoMunicipio);

            List<SelectListItem> lstAnio = new List<SelectListItem>();

            for (int valor = DateTime.Now.Year - 1; valor <= 2050; valor++)
            {
                SelectListItem item = new SelectListItem();
                item.Text = string.Format("{0:0}", valor);
                item.Value = string.Format("{0:0}", valor);
                lstAnio.Add(item);
            }

            ViewBag.ListaAnios = new SelectList(lstAnio, "Value", "Text");

            return View(ods_meta_municipio);
        }

        // POST: ods_meta_municipio/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdMetaMunicipio,MetaMuncipio,Anio,FechaInicio,FechaTermino,DebeCumplirse,EscalaPositiva,IdIndicador,IdObjetivoMunicipio")] ods_meta_municipio ods_meta_municipio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ods_meta_municipio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdIndicador = new SelectList(db.ods_indicador.OrderBy(i => i.Indicador).Where(i => i.Vigente == true).ToList(), "IdIndicador", "Indicador", ods_meta_municipio.IdIndicador);
            ViewBag.IdObjetivoMunicipio = new SelectList(db.ods_objetivo_municipio.OrderBy(o => o.ObjetivoMunicipio).Where(o => o.Vigente == true).ToList(), "IdObjetivoMunicipio", "ObjetivoMunicipio", ods_meta_municipio.IdObjetivoMunicipio);
            return View(ods_meta_municipio);
        }

        // GET: ods_meta_municipio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ods_meta_municipio ods_meta_municipio = db.ods_meta_municipio.Find(id);
            if (ods_meta_municipio == null)
            {
                return HttpNotFound();
            }
            return View(ods_meta_municipio);
        }

        // POST: ods_meta_municipio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ods_meta_municipio ods_meta_municipio = db.ods_meta_municipio.Find(id);
            db.ods_meta_municipio.Remove(ods_meta_municipio);
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
