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
    public class ods_vinculo_meta_municipioController : Controller
    {
        private Modelo db = new Modelo();

        // GET: ods_vinculo_meta_municipio
        public ActionResult Index()
        {
            var ods_vinculo_meta_municipio = db.ods_vinculo_meta_municipio.Include(o => o.ods_meta).Include(o => o.ods_meta_municipio);
            return View(ods_vinculo_meta_municipio.ToList());
        }

        // GET: ods_vinculo_meta_municipio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ods_vinculo_meta_municipio ods_vinculo_meta_municipio = db.ods_vinculo_meta_municipio.Find(id);
            if (ods_vinculo_meta_municipio == null)
            {
                return HttpNotFound();
            }
            return View(ods_vinculo_meta_municipio);
        }

        // GET: ods_vinculo_meta_municipio/Create
        public ActionResult Create()
        {
            ViewBag.IdMeta = new SelectList(db.ods_meta.OrderBy(m => m.IdMeta).ToList(), "IdMeta", "Meta"); ;
            ViewBag.IdMetaMunicipio = new SelectList(db.ods_meta_municipio.OrderBy(m => m.MetaMuncipio).ToList(), "IdMetaMunicipio", "MetaMuncipio");

            return View();
        }

        // POST: ods_vinculo_meta_municipio/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdVinculo,IdMeta,IdMetaMunicipio")] ods_vinculo_meta_municipio ods_vinculo_meta_municipio)
        {
            if (ModelState.IsValid)
            {
                db.ods_vinculo_meta_municipio.Add(ods_vinculo_meta_municipio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdMeta = new SelectList(db.ods_meta.OrderBy(m => m.IdMeta).ToList(), "IdMeta", "Meta", ods_vinculo_meta_municipio.IdMeta);
            ViewBag.IdMetaMunicipio = new SelectList(db.ods_meta_municipio.OrderBy(m => m.MetaMuncipio).ToList(), "IdMetaMunicipio", "MetaMuncipio", ods_vinculo_meta_municipio.IdMetaMunicipio);
            return View(ods_vinculo_meta_municipio);
        }

        // GET: ods_vinculo_meta_municipio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ods_vinculo_meta_municipio ods_vinculo_meta_municipio = db.ods_vinculo_meta_municipio.Find(id);
            if (ods_vinculo_meta_municipio == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdMeta = new SelectList(db.ods_meta.OrderBy(m => m.IdMeta).ToList(), "IdMeta", "Meta", ods_vinculo_meta_municipio.IdMeta);
            ViewBag.IdMetaMunicipio = new SelectList(db.ods_meta_municipio.OrderBy(m => m.MetaMuncipio).ToList(), "IdMetaMunicipio", "MetaMuncipio", ods_vinculo_meta_municipio.IdMetaMunicipio);
            return View(ods_vinculo_meta_municipio);
        }

        // POST: ods_vinculo_meta_municipio/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdVinculo,IdMeta,IdMetaMunicipio")] ods_vinculo_meta_municipio ods_vinculo_meta_municipio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ods_vinculo_meta_municipio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdMeta = new SelectList(db.ods_meta.OrderBy(m => m.IdMeta).ToList(), "IdMeta", "Meta", ods_vinculo_meta_municipio.IdMeta);
            ViewBag.IdMetaMunicipio = new SelectList(db.ods_meta_municipio.OrderBy(m => m.MetaMuncipio).ToList(), "IdMetaMunicipio", "MetaMuncipio", ods_vinculo_meta_municipio.IdMetaMunicipio);
            return View(ods_vinculo_meta_municipio);
        }

        // GET: ods_vinculo_meta_municipio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ods_vinculo_meta_municipio ods_vinculo_meta_municipio = db.ods_vinculo_meta_municipio.Find(id);
            if (ods_vinculo_meta_municipio == null)
            {
                return HttpNotFound();
            }
            return View(ods_vinculo_meta_municipio);
        }

        // POST: ods_vinculo_meta_municipio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ods_vinculo_meta_municipio ods_vinculo_meta_municipio = db.ods_vinculo_meta_municipio.Find(id);
            db.ods_vinculo_meta_municipio.Remove(ods_vinculo_meta_municipio);
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
