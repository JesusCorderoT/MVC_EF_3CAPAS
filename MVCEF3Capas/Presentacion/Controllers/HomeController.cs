using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio;

namespace Presentacion.Controllers
{
    public class HomeController : Controller
    {


        public ActionResult Index()
        {
   


            return View();
        }

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








//carga PEREZOZA
//_DBContext.Configuration.LazyLoadingEnable = false;
//_lstCursos = _DBContext.Cursos.Tolist();

//return ViewContext(_lstCursos);