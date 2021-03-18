using ODS.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace valentina.Controllers
{
    public class BaseController : Controller
    {
        private Modelo db = new Modelo();

        //// GET: Base
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //GET: Autocompletar Indicadores.
        [HttpGet]
        public ActionResult ObtenerIndicadoresMunicipio(string term)
        {
            var objCustomerlist = db.ods_indicador.Where(i => i.Vigente == true)
                                 .Where(i => i.Indicador.ToUpper().Contains(term.ToUpper()))
                                 .Select(i => new { Nombre = i.Indicador, Identificador = i.IdIndicador })
                                 .Distinct().ToList();

            return Json(objCustomerlist, JsonRequestBehavior.AllowGet);
        }

        //[HttpGet]
        //public ActionResult ObtenerObjetivos(int idMunicipio, string term)
        //{
        //    var objCustomerlist = db.ods_objetivo_municipio.Where(o => o.Vigente == true && o.IdMunicipio == idMunicipio)
        //                         .Where(o => o.ObjetivoMunicipio.ToUpper().Contains(term.ToUpper()))
        //                         .Select(o => new { Nombre = o.ObjetivoMunicipio, Identificador = o.IdObjetivoMunicipio })
        //                         .Distinct().ToList();

        //    return Json(objCustomerlist, JsonRequestBehavior.AllowGet);
        //}

        [HttpGet]
        public ActionResult ObtenerObjetivosMunicipio(string term)
        {
            var objCustomerlist = db.ods_objetivo_municipio.Where(o => o.Vigente == true)
                                 .Where(o => o.ObjetivoMunicipio.ToUpper().Contains(term.ToUpper()))
                                 .Select(o => new { Nombre = o.ObjetivoMunicipio, Identificador = o.IdObjetivoMunicipio })
                                 .Distinct().ToList();

            return Json(objCustomerlist, JsonRequestBehavior.AllowGet);
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