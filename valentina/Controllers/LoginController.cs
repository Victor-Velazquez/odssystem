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
    public class LoginController : Controller
    {
        Modelo db = new Modelo();

        //// GET: Login
        [AllowAnonymous]
        public ActionResult Autenticar()
        {
            var ods_interesado = new ods_interesado();

            string ipaddress;
            ipaddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (ipaddress == "" || ipaddress == null)
                ipaddress = Request.ServerVariables["REMOTE_ADDR"];

            Session["ip"] = ipaddress;


            return View();
        }

        //// POST: Login/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Autenticar([Bind(Include = "Usuario,Contrasenia")] ods_interesado ods_interesado)
        {
            ods_interesado ods_interesado_existe = null;

            if (!ValidarAcceso(ods_interesado.Usuario, ods_interesado.Contrasenia, out ods_interesado_existe))
            {
                ViewBag.Mensaje = "Usuario o Contraseña Incorrectos...";
                return View(ods_interesado);
            }

            return RedirectToAction("Index", "ods_tablero_indicador_ods_vw");

            //string redirect = string.Format("../ods_tablero_indicador_ods_vw/Index/{0}", ods_interesado_existe.IdMunicipio);

            //return RedirectToAction(redirect);
        }

        private bool ValidarAcceso(string pUsuario, string pPassword, out ods_interesado ods_interesado)
        {
            bool resultado = false;
            string hash_password = Cifrar(pPassword);
            ods_interesado = null;

            List<ods_interesado> ods_interesado_ok = db.ods_interesado.Where(i => i.Usuario == pUsuario).ToList();

                //from p in db.ods_interesado where (iusuario.Trim().ToUpper() == p.Usuario.Trim().ToUpper()) select p;

            if (ods_interesado_ok != null)
            {
                if (ods_interesado_ok.Count() > 0)
                {
                    foreach (var item in ods_interesado_ok)
                        ods_interesado = item;

                    if (ods_interesado.Contrasenia.Trim() == hash_password.Trim())
                    {
                        Session["ods_interesado"] = ods_interesado;
                        resultado = true;
                    }
                        
                }
            }

            return resultado;
        }

        private string Cifrar(string valor)
        {
            SHA256 sha256 = new SHA256CryptoServiceProvider();

            byte[] inputBytes = (new UnicodeEncoding()).GetBytes(valor);
            byte[] hash = sha256.ComputeHash(inputBytes);

            return Convert.ToBase64String(hash);
        }

        public ActionResult CerrarSesion(ods_interesado model)
        {
            //this.GuardarEvento("Cierre de Sesión", "Salida del Sistema", string.Format("El Usuario: {0} ha finalizado su sesión en control de acceso.", Session["usuario"]));
            ViewBag.NombreCompleto = String.Empty;
            Session["usuario"] = null;
            return RedirectToAction("Autenticar", "Login");
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
