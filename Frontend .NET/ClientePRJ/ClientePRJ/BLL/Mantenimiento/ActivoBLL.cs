using ClientePRJ.DAL.Mantenimiento;
using ClientePRJ.Models.Mantenimiento;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ClientePRJ.BLL.Mantenimiento
{
    public class ActivoBLL
    {
        private readonly ActivoDAL DAL = new ActivoDAL();

        public DataTable listarActivos()
        {
            return DAL.listarActivos();
        }
        public DataTable getActivoByNombreDataTable(String nombre)
        {
            return DAL.getActivoByNombreDataTable(nombre);
        }
        public bool insertarActivo(ActivoModel a)
        {
            return DAL.insertarActivo(a);
        }
        public ActivoModel getActivoById(String id)
        {
            return DAL.getActivoById(id);
        }
        public bool actualizarActivo(ActivoModel a)
        {
            return DAL.actualizarActivo(a);
        }
        public bool eliminarActivo(String id)
        {
            return DAL.eliminarActivo(id);
        }
        public List<ActivoModel> listarNombresActivos()
        {
            return DAL.listarNombresActivos();
        }

        public List<ActivoModel> getAllActivos()
        {
            return DAL.getAllActivos();
        }
    }
}