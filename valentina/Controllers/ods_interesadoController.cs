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
        private readonly Modelo db = new Modelo();

        // GET: ods_interesado
        [Authorize(Roles = "SuperUsuario,Administrador,Usuario")]
        public ActionResult Index(int? idMunicipio, int? idInteresado)
        {
            ods_interesado ods_interesado = null;
            IQueryable<ods_interesado> lst_ods_interesado = null;

            try
            {                
                if ((ods_interesado = (ods_interesado)Session["ods_interesado"]) == null)
                    return RedirectToAction("Autenticar", "Login");

                bool autenticado = User.Identity.IsAuthenticated;

                if (idMunicipio == null && idInteresado == null)
                    lst_ods_interesado = db.ods_interesado;
                else if(idMunicipio != null && idInteresado == null)
                {
                    if (idMunicipio != ods_interesado.IdMunicipio)
                        idMunicipio = ods_interesado.IdMunicipio;

                    lst_ods_interesado = from p in db.ods_interesado where (idMunicipio == p.IdMunicipio && p.SuperUsuario == false) select p;
                }
                else if ( idMunicipio == null && idInteresado != null)
                {
                    if (idInteresado != ods_interesado.IdInteresado)
                        idInteresado = ods_interesado.IdInteresado;

                    lst_ods_interesado = from p in db.ods_interesado where (idInteresado == p.IdInteresado && p.SuperUsuario == false) select p;
                }
                else if (idMunicipio != null && idInteresado != null)
                {
                    if (idInteresado != ods_interesado.IdInteresado)
                        idInteresado = ods_interesado.IdInteresado;

                    lst_ods_interesado = from p in db.ods_interesado where (idMunicipio == p.IdMunicipio && idInteresado == p.IdInteresado && p.SuperUsuario == false) select p;
                }

                if (lst_ods_interesado == null)
                    return HttpNotFound();

                ViewBag.Interesado = ods_interesado;
            }
            catch (Exception  /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Debe iniciar sesión principalmente.");
            }

            return View(lst_ods_interesado.ToList());
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
        public ActionResult Create([Bind(Include = "IdInteresado,Interesado,Nombre,Usuario,Contrasenia,CorreoRecuperacion,UltimaSesion,IPUltimaSesion,Administrador,SuperUsuario,Bloqueado,Activo,IdMunicipio")] ods_interesado ods_interesado)
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

        //// POST: ods_interesado/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "IdInteresado,Interesado,Nombre,Usuario,Contrasenia,CorreoRecuperacion,UltimaSesion,IPUltimaSesion,Bloqueado,Activo,IdMunicipio")] ods_interesado ods_interesado)
        //{
        //    if (ModelState.IsValid)
        //    {
               
                
                    
        //        ods_interesado.Contrasenia = Cifrar(ods_interesado.Contrasenia);
        //        db.Entry(ods_interesado).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.IdMunicipio = new SelectList(db.ods_municipio.OrderBy(t => t.Municipio).ToList(), "IdMunicipio", "Municipio", ods_interesado.IdMunicipio);
        //    return View(ods_interesado);
        //}

        //// POST: ods_interesado/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int IdInteresado, string Interesado, string Nombre, string Usuario, string ContraseniaActual, string Contrasenia, string CorreoRecuperacion, bool Administrador, bool SuperUsuario, bool Bloqueado, bool Activo, int IdMunicipio )
        //{
        //    ods_interesado ods_interesado = null;
        //    string vcontrasenia = string.Empty;

        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {

        //            if (ContraseniaActual == Contrasenia)
        //                vcontrasenia = ContraseniaActual;
        //            else
        //                vcontrasenia = Cifrar(Contrasenia);

        //            ods_interesado = new ods_interesado
        //            {
        //               IdInteresado = IdInteresado,
        //               Interesado = Interesado,
        //               Nombre = Nombre,
        //               Usuario = Usuario,
        //               Contrasenia = vcontrasenia,
        //               CorreoRecuperacion = CorreoRecuperacion,
        //               Administrador = Administrador,
        //               SuperUsuario = SuperUsuario,
        //               Bloqueado = Bloqueado,
        //               Activo = Activo,
        //               IdMunicipio = IdMunicipio
        //            };
                    
        //            db.Entry(ods_interesado).State = EntityState.Modified;
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
                                               
        //    ViewBag.IdMunicipio = new SelectList(db.ods_municipio.OrderBy(t => t.Municipio).ToList(), "IdMunicipio", "Municipio", ods_interesado.IdMunicipio);
        //    return View(ods_interesado);
        //}

        // POST: ods_interesado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection valores)
        {
            ods_interesado ods_interesado = null;
            string vcontrasenia = string.Empty;
            int IdInteresado = 0;
            string Interesado = string.Empty;
            string Nombre = string.Empty;
            string Usuario = string.Empty;
            string ContraseniaActual = string.Empty;
            string Contrasenia = string.Empty;
            string CorreoRecuperacion = string.Empty;
            DateTime UltimaSesion = DateTime.Now;
            string IPUltimaSesion = string.Empty;
            bool Administrador = false;
            bool SuperUsuario = false;
            bool Bloqueado = false;
            bool Activo = false;
            int IdMunicipio = 0;

            try
            {
                if (ModelState.IsValid) 
                {
                    var lstContrasenias = ((string)valores["Contrasenia"]).Split(',');

                    Contrasenia = lstContrasenias[0];
                    ContraseniaActual = lstContrasenias[1];

                    if (ContraseniaActual == Contrasenia)
                        vcontrasenia = ContraseniaActual;
                    else
                        vcontrasenia = Cifrar(Contrasenia);

                    string fecha = (string)valores["UltimaSesion"];

                    IdInteresado = int.Parse(valores["IdInteresado"]);
                    Interesado = (string)valores["Interesado"];
                    Nombre = (string)valores["Nombre"];
                    Usuario = (string)valores["Usuario"];
                    Contrasenia = vcontrasenia;
                    CorreoRecuperacion = (string)valores["CorreoRecuperacion"];
                    UltimaSesion = DateTime.Parse((string)valores["UltimaSesion"]);
                    IPUltimaSesion = (string)valores["IPUltimaSesion"];
                    Administrador = bool.Parse(valores["Administrador"].Split(',')[0]);
                    SuperUsuario = bool.Parse(valores["SuperUsuario"].Split(',')[0]);
                    Bloqueado = bool.Parse(valores["Bloqueado"].Split(',')[0]);
                    Activo = bool.Parse(valores["Activo"].Split(',')[0]);
                    IdMunicipio = int.Parse(valores["IdMunicipio"]);

                    ods_interesado = new ods_interesado
                    {
                        IdInteresado = IdInteresado,
                        Interesado = Interesado,
                        Nombre = Nombre,
                        Usuario = Usuario,
                        Contrasenia = vcontrasenia,
                        CorreoRecuperacion = CorreoRecuperacion,
                        UltimaSesion = UltimaSesion,
                        IPUltimaSesion = IPUltimaSesion,
                        Administrador = Administrador,
                        SuperUsuario = SuperUsuario,
                        Bloqueado = Bloqueado,
                        Activo = Activo,
                        IdMunicipio = IdMunicipio
                    };

                    db.Entry(ods_interesado).State = EntityState.Modified;
                    db.SaveChanges();

                    
                    return RedirectToAction("Index");
                }

            }
            catch (Exception)
            {

                throw;
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
