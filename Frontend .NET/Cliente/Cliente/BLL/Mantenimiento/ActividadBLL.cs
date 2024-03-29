using Cliente.DAL.Mantenimiento;
using Cliente.Models.Mantenimiento;
using System;
using System.Data;

namespace Cliente.BLL.Mantenimiento
{
    public class ActividadBLL
    {
        private readonly ActividadDAL DAL = new ActividadDAL();
        public DataTable listarActividades()
        {
            return DAL.listarActividades();
        }

        public DataTable getActividadesByFecha(DateTime fecha)
        {
            return DAL.getActividadesByFecha(fecha);
        }

        public bool insertarActividad(ActividadModel actividadModel)
        {
            return DAL.insertarActividad(actividadModel);
        }

        public ActividadModel getLastActividad()
        {
            return DAL.getLastActividad();
        }

        public bool actualizarActividad(ActividadModel actividadModel)
        {
            return DAL.actualizarActividad(actividadModel);
        }
        public bool eliminarActividad(String id)
        {
            return DAL.eliminarActividad(id);
        }
    }
}