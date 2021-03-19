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
using System.Web.Security;
using ODS.DataLayer;

namespace valentina.Controllers
{
    public class LoginController : Controller
    {
        private readonly Modelo db = new Modelo();

        //// GET: Login
        [AllowAnonymous]
        public ActionResult Autenticar()
        {
            string ipaddress = string.Empty;

            try
            {
                ipaddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

                if (ipaddress == "" || ipaddress == null)
                    ipaddress = Request.ServerVariables["REMOTE_ADDR"];

                Session["ip"] = ipaddress;
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Error al recuperar dirección IP.");
            }

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
            int resultado = 0;
            string mensaje = "Usuario o Contraseña Incorrectos...";

            resultado = ValidarAcceso(ods_interesado.Usuario, ods_interesado.Contrasenia, out ods_interesado_existe);

            if(resultado == 200)
            {
                ViewBag.Mensaje = string.Format("Bienvenido {0}",ods_interesado_existe.Nombre);
                return RedirectToAction("Index", "ods_tablero_indicador_ods_vw");
            }
            else if(resultado == 401)
            {
                mensaje = "Usuario o Contraseña Incorrectos...";
            }
            else if (resultado == 403)
            {
                mensaje = "Su usuario se encuentra inactivo, favor de contactar a su administrador.";
            }
            else if(resultado == 307)
            {
                mensaje = "Su usuario se encuentra bloqueado, favor de contactar a su administrador.";
            }

            //ViewBag.Mensaje = mensaje;
            ModelState.AddModelError("", mensaje);
            return View(ods_interesado);
        }

        private int ValidarAcceso(string pUsuario, string pPassword, out ods_interesado ods_interesado)
        {
            int resultado = 400;
            string hash_password = string.Empty;
            IQueryable<ods_interesado> ods_Interesado_encontrado = null;
            ods_interesado = null;

            try
            {
                hash_password = Cifrar(pPassword);

                ods_Interesado_encontrado = from p in db.ods_interesado where (pUsuario.Trim().ToLower() == p.Usuario.ToLower()) select p;

                if (ods_Interesado_encontrado != null)
                {
                    ods_interesado = ods_Interesado_encontrado.First();
                   
                    if (ods_interesado.Contrasenia.Trim() == hash_password.Trim())
                    {

                        if (!ods_interesado.Activo)
                        {
                            resultado = 403;
                        }
                        else if (ods_interesado.Bloqueado)
                        {
                            resultado = 307;
                        }
                        else
                        {
                            //Actualizar los datos de sesión.
                            ods_interesado.UltimaSesion = DateTime.Now;
                            ods_interesado.IPUltimaSesion = (string)Session["ip"];

                            db.Entry(ods_interesado).State = EntityState.Modified;
                            db.SaveChanges();

                            ods_interesado.ods_municipio = db.ods_municipio.Find(ods_interesado.IdMunicipio);
                            ods_interesado.ods_seguimiento_tarea = db.ods_seguimiento_tarea.SqlQuery(string.Format("select * from dbo.ods_seguimiento_tarea where IdInteresado = {0}", ods_interesado.IdInteresado)).ToList();
                            ods_interesado.ods_tarea = db.ods_tarea.SqlQuery(string.Format("select * from dbo.ods_tarea where IdInteresado = {0}", ods_interesado.IdInteresado)).ToList();

                            Session["ods_interesado"] = ods_interesado;
                            FormsAuthentication.SetAuthCookie(ods_interesado.Usuario, false);

                            resultado = 200;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Error: Usuario o Contraseña Incorrecta.";
                ViewBag.Debug = ex.ToString();
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
            //ViewBag.NombreCompleto = String.Empty;
            Session["ods_interesado"] = null;
            ViewBag.Mensaje = "Ha cerrado su sesión correctamente.";
            FormsAuthentication.SignOut();
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
