using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ODS.DataLayer;

namespace valentina.Controllers
{
    public class ods_interesadoController : Controller
    {
        private Modelo db = new Modelo();

        // GET: ods_interesado
        public ActionResult Index()
        {
            var ods_interesado = db.ods_interesado.Include(o => o.ods_municipio);
            return View(ods_interesado.ToList());
        }

        // GET: ods_interesado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ods_interesado ods_interesado = db.ods_interesado.Find(id);
            if (ods_interesado == null)
            {
                return HttpNotFound();
            }
            return View(ods_interesado);
        }

        // GET: ods_interesado/Create
        public ActionResult Create()
        {
            ViewBag.IdMunicipio = new SelectList(db.ods_municipio.OrderBy(t => t.Municipio).ToList(), "IdMunicipio", "Municipio");
            return View();
        }

        // POST: ods_interesado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdInteresado,Interesado,Nombre,Usuario,Contrasenia,CorreoRecuperacion,UltimaSesion,IPUltimaSesion,Bloqueado,Activo,IdMunicipio")] ods_interesado ods_interesado)
        {
            if (ModelState.IsValid)
            {
                ods_interesado.Contrasenia = Cifrar(ods_interesado.Contrasenia);

                db.ods_interesado.Add(ods_interesado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdMunicipio = new SelectList(db.ods_municipio.OrderBy(t => t.Municipio).ToList(), "IdMunicipio", "Municipio", ods_interesado.IdMunicipio);
            return View(ods_interesado);
        }

        // GET: ods_interesado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ods_interesado ods_interesado = db.ods_interesado.Find(id);
            if (ods_interesado == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdMunicipio = new SelectList(db.ods_municipio.OrderBy(t => t.Municipio).ToList(), "IdMunicipio", "Municipio", ods_interesado.IdMunicipio);
            return View(ods_interesado);
        }

        // POST: ods_interesado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdInteresado,Interesado,Nombre,Usuario,Contrasenia,CorreoRecuperacion,UltimaSesion,IPUltimaSesion,Bloqueado,Activo,IdMunicipio")] ods_interesado ods_interesado)
        {
            if (ModelState.IsValid)
            {
                ods_interesado.Contrasenia = Cifrar(ods_interesado.Contrasenia);
                db.Entry(ods_interesado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdMunicipio = new SelectList(db.ods_municipio.OrderBy(t => t.Municipio).ToList(), "IdMunicipio", "Municipio", ods_interesado.IdMunicipio);
            return View(ods_interesado);
        }

        // GET: ods_interesado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ods_interesado ods_interesado = db.ods_interesado.Find(id);
            if (ods_interesado == null)
            {
                return HttpNotFound();
            }
            return View(ods_interesado);
        }

        // POST: ods_interesado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ods_interesado ods_interesado = db.ods_interesado.Find(id);
            db.ods_interesado.Remove(ods_interesado);
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

        private string Cifrar(string valor)
        {
            SHA256 sha256 = new SHA256CryptoServiceProvider();

            byte[] inputBytes = (new UnicodeEncoding()).GetBytes(valor);
            byte[] hash = sha256.ComputeHash(inputBytes);

            return Convert.ToBase64String(hash);
        }

    }
}
