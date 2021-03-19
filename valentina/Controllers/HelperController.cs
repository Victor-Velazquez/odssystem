using ODS.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace valentina.Controllers
{
    public abstract partial class HelperController : Controller
    {
        private readonly Modelo db = new Modelo();
        
        //public ods_interesado Interesado { get; set; }

        //public HelperController()
        //{
        //    //this.Interesado = this.ObtenerInteresado();
        //}

        public ods_interesado ObtenerInteresado()
        {
            ods_interesado ods_interesado = null;

            try
            {
                ViewBag.Interesado = null;
                ViewBag.Mensaje = "Debe iniciar sesión.";

                if (Session == null)
                    return ods_interesado;

                if (Session["ods_interesado"] != null)
                {
                    ods_interesado = (ods_interesado)Session["ods_interesado"];

                    ods_interesado.ods_municipio = db.ods_municipio.Find(ods_interesado.IdMunicipio);
                    ods_interesado.ods_seguimiento_tarea = db.ods_seguimiento_tarea.SqlQuery(string.Format("select * from dbo.ods_seguimiento tarea where IdInteresado = {0}", ods_interesado.IdInteresado)).ToList();
                    //ViewBag.Interesado = ods_interesado;
                    //ViewBag.Mensaje = string.Empty;
                }

                //this.Interesado = this.ObtenerInteresado();
            }
            catch (Exception  /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Debe iniciar sesión.");
            }

            return ods_interesado;
        }

        public string ObtenerDireccionIP()
        {
            string ipaddress = string.Empty;

            try
            {
                ipaddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

                if (ipaddress == "" || ipaddress == null)
                    ipaddress = Request.ServerVariables["REMOTE_ADDR"];

                //Session["ip"] = ipaddress;
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Error al recuperar dirección IP.");
            }

            return ipaddress;
        }

        //// GET: Helper
        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}