using ClientePRJ.DAL.Mantenimiento;
using ClientePRJ.Models.Mantenimiento;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ClientePRJ.BLL.Mantenimiento
{
    public class ActividadBLL
    {
        private readonly ActividadDAL DAL = new ActividadDAL();
        public DataTable listarActividades()
        {
            return DAL.listarActividades();
        }
        public List<String> getAllResponsablesActividades()
        {
            return DAL.getAllResponsablesActividades();
        }
        public ActividadModel getLastActividad()
        {
            return DAL.getLastActividad();
        }
        public bool insertarActividad(ActividadModel actividadModel)
        {
            return DAL.insertarActividad(actividadModel);
        }
        public bool actualizarActividad(ActividadModel actividadModel)
        {
            return DAL.actualizarActividad(actividadModel);
        }
        public bool eliminarActividad(String id)
        {
            return DAL.eliminarActividad(id);
        }
        public DataTable getActividadesByFecha(DateTime fecha)
        {
            return DAL.getActividadesByFecha(fecha);
        }
        public DataTable getActividadesByResponsable(string responsable)
        {
            return DAL.getActividadesByResponsable(responsable);
        }
    }
}