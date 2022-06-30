using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;
namespace Negocio
{
    public class NEstado
    {
        InstitutoTichEntities dbContext = new InstitutoTichEntities();
        Estados estados = new Estados();

        public List<Estados> Consultar()
        {
            List<Estados> listEstados = new List<Estados>();
            listEstados = dbContext.Estados.ToList();
            return listEstados;
        }

        public Estados Consultar(int id)
        {
            estados = dbContext.Estados.Find(id);
            return estados;
        }


        //public Estados Consultar(int id)
        //{
        //    alumno = dbContext.ALUMNOS.Find(id);
        //    return alumno;
        //}

        //public void Agregar(Estados alumno)
        //{
        //    dbContext.ALUMNOS.Add(alumno);
        //    dbContext.SaveChanges();

        //}

        //public void Actualizar(Estados alumno)
        //{
        //    dbContext.Entry(alumno).State = EntityState.Modified;
        //    dbContext.SaveChanges();
        //}

        //public void Eliminar(int id)
        //{
        //    alumno = dbContext.ALUMNOS.Find(id);
        //    dbContext.ALUMNOS.Remove(alumno);
        //    dbContext.SaveChanges();

        //}

    }
}
