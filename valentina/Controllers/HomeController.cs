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
    public class HomeController : Controller
    {
        private Modelo db = new Modelo();

        // GET: ods_objetivo_municipio
        public ActionResult Index()
        {
            var ods_objetivo_municipio = db.ods_objetivo_municipio.Include(o => o.ods_municipio);
            return View(ods_objetivo_municipio.ToList());
        }

        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}