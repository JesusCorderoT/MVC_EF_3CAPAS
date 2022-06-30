using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;
using Negocio;
using Newtonsoft.Json;
using Presentacion.Models;
using Negocio.WCFReferencia;


namespace Presentacion.Controllers
{
    public class AlumnosController : Controller
    {



        List<ALUMNOS> _listAlumno = new List<ALUMNOS>();
        NAlumno capNa = new NAlumno();

        List<Estados> _listET = new List<Estados>();
        NEstado _oEstado = new NEstado();

        NEstado capNe = new NEstado();
        List<EstatusAlumno> _listES = new List<EstatusAlumno>();
        NEstatus _oEstatus = new NEstatus();



        ALUMNOS _oAlumno = new ALUMNOS();

        // GET: Alumnos
        public ActionResult Index()
        {

            //ya sirve no borrar
            //_listAlumno = capNa.Consultar();
            //return View(_listAlumno);



            List<ALUMNOS> alumnoList = new List<ALUMNOS>();
            List<EstatusAlumno> lstEstatus = _oEstatus.Consultar();
            List<Estados> lstEstados = _oEstado.Consultar();
            alumnoList = capNa.Consultar();

            var linq =
                from alum in alumnoList
                join Estatus in lstEstatus on alum.idEstatus equals Estatus.id
                join Estado in lstEstados on alum.idestadoorigen equals Estado.id
                select new
                {
                    id = alum.id,
                    nombre = alum.nombre,
                    primerApellido = alum.primerApellido,
                    segundoApellido = alum.segundoApellido,
                    correo = alum.correo,
                    telefono = alum.telefono,
                    fechaNacimiento = alum.fechaNacimiento,
                    curp = alum.curp,
                    sueldo = alum.sueldo,
                    idestadoorigen = Estado.nombre,
                    idEstatus = Estatus.nombre
                };


            string json = JsonConvert.SerializeObject(linq);
            List<AlumnoM> list = JsonConvert.DeserializeObject<List<AlumnoM>>(json);

            return View(list);
        }

        // GET: Alumnos/Details/5
        public ActionResult Details(int id)
        {
            _oAlumno = capNa.Consultar(id);
            return View(_oAlumno);
        }

        // GET: Alumnos/Create
        public ActionResult Create()
        {
            ViewBag.estados = _oEstado.Consultar();

            ViewBag.estatus = _oEstatus.Consultar();
            return View();
        }

        // POST: Alumnos/Create
        [HttpPost]
        public ActionResult Create(ALUMNOS alu,FormCollection collection)
        {
            try
            {
                capNa.Agregar(alu);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Alumnos/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.estados = _oEstado.Consultar();

            ViewBag.estatus = _oEstatus.Consultar();

            _oAlumno = capNa.Consultar(id);
            return View(_oAlumno);
        }

        // POST: Alumnos/Edit/5
        [HttpPost]
        public ActionResult Edit(ALUMNOS alu)
        {
            try
            {
                capNa.Actualizar(alu);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Alumnos/Delete/5
        public ActionResult Delete(int id)
        {
            _oAlumno = capNa.Consultar(id);
            return View(_oAlumno);
        }

        // POST: Alumnos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                capNa.Eliminar(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult _AportacionesIMSS(int id)
        {
            AportacionesIMSS iMSS = capNa.CalcularIMSS(id);
            ViewBag.nombre = "IMSS";
            return PartialView(iMSS);
        }



        public ActionResult _TablaISR(int id)
        {

            ItemTablaISR isr = capNa.CalcularISR(id);
            ViewBag.nombre = "ISR";
            return PartialView(isr);


            //capNa.CalcularISR(id);
            //return PartialView();
        }





    }
}
