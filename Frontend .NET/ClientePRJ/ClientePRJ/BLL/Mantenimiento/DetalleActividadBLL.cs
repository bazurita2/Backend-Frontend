using ClientePRJ.DAL.Mantenimiento;
using ClientePRJ.Models.Mantenimiento;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ClientePRJ.BLL.Mantenimiento
{
    public class DetalleActividadBLL
    {
        private readonly DetalleActividadDAL DAL = new DetalleActividadDAL();
        public DataTable getDetalleActividadByActivoDataTable(String id)
        {
            return DAL.getDetalleActividadByActivoDataTable(id);
        }
        public List<DetalleActividadModel> getAllDetallesActividadesByActividadId(String id)
        {
            return DAL.getAllDetallesActividadesByActividadId(id);
        }
        public bool insertarDetalleActividad(DetalleActividadModel d)
        {
            return DAL.insertarDetalleActividad(d);
        }
        public bool deleteDetalleActividadPorCabecera(String id)
        {
            return DAL.deleteDetalleActividadPorCabecera(id);
        }
    }
}