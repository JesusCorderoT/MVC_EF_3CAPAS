using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;


namespace Negocio
{
    public class NEstatus
    {
        InstitutoTichEntities dbContext = new InstitutoTichEntities();
        public List<EstatusAlumno> Consultar()
        {
            List<EstatusAlumno> listEstatus = new List<EstatusAlumno>();
            listEstatus = dbContext.EstatusAlumno.ToList();
            return listEstatus;
        }
    }
}
