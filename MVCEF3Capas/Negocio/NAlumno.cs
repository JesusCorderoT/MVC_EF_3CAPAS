using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.WCFReferencia;
using Entidades;
using Newtonsoft.Json;
using Datos;


namespace Negocio
{
    public class NAlumno
    {

        InstitutoTichEntities dbContext = new InstitutoTichEntities();

        
        ALUMNOS alumno = new ALUMNOS();

        public List<ALUMNOS> Consultar()
        {
            List<ALUMNOS> lstAlumnos = new List<ALUMNOS>();
            lstAlumnos = dbContext.ALUMNOS.ToList();
            return lstAlumnos;
        }

        public ALUMNOS Consultar(int id)
        {
            alumno = dbContext.ALUMNOS.Find(id);
            return alumno;
        }

        public void Agregar(ALUMNOS alumno)
        {
            dbContext.ALUMNOS.Add(alumno);
            dbContext.SaveChanges();
           
        }

        public void Actualizar(ALUMNOS alumno)
        {
            dbContext.Entry(alumno).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        public void Eliminar(int id)
        {
            alumno = dbContext.ALUMNOS.Find(id);
            dbContext.ALUMNOS.Remove(alumno);
            dbContext.SaveChanges();
            
        }

        public AportacionesIMSS CalcularIMSS(int id)
        {
            WCFAlumnosClient wcf = new WCFAlumnosClient();
            AportacionesIMSS IMSS = wcf.CalcularIMSS(id);
            return IMSS;
        }
        public ItemTablaISR CalcularISR(int id)
        {

            WCFAlumnosClient wcf = new WCFAlumnosClient();
            ItemTablaISR ISR = wcf.CalcularISR(id);
            return ISR;
        }


    }
}
