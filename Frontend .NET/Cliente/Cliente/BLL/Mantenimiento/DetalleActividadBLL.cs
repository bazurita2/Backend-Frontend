using Cliente.DAL.Mantenimiento;
using Cliente.Models;
using Cliente.Models.Mantenimiento;
using System;
using System.Collections.Generic;
using System.Data;

namespace Cliente.BLL.Mantenimiento
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

        public List<int> getMaxColFilDetalleActividad()
        {
            return DAL.getMaxColFilDetalleActividad();
        }

        public List<ActivoModel> getFilaActivo()
        {
            return DAL.getFilaActivo();
        }

        public List<string> getColumnaDetalleaActividad(String id)
        {
            return DAL.getColumnaDetalleaActividad(id);
        }

        public bool insertarDetalleActividad(DetalleActividadModel d)
        {
            return DAL.insertarDetalleActividad(d);
        }

        public bool actualizarDetalleActividad(DetalleActividadModel d)
        {
            return DAL.actualizarDetalleActividad(d);
        }
        public bool eliminarDetalleActividad(String id)
        {
            return DAL.eliminarDetalleActividad(id);
        }

        public bool deleteDetalleActividadPorCabecera(String id)
        {
            return DAL.deleteDetalleActividadPorCabecera(id);
        }
    }
}