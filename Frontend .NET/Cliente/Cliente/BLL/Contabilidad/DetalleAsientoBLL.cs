using Cliente.DAL.Contabilidad;
using Cliente.Models.Contabilidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
namespace Cliente.BLL.Contabilidad
{
    public class DetalleAsientoBLL
    {
        private readonly DetalleAsientoDAL DAL = new DetalleAsientoDAL();
        public DataTable listar()
        {
            return DAL.listar();
        }
        public bool insertar(DetalleAsientoModel a)
        {
            return DAL.insertar(a);
        }

        public bool actualizar(DetalleAsientoModel a)
        {
            return DAL.actualizar(a);
        }
        public bool eliminar(String id)
        {
            return DAL.eliminar(id);
        }
        public bool eliminarPorCabecera(String id)
        {
            return DAL.eliminarPorCabecera(id);
        }
        public DetalleAsientoModel getById(String id)
        {
            return DAL.getById(id);
        }
        public DataTable getByIdDataTable(String id)
        {
            return DAL.getByIdDataTable(id);
        }
        public DataTable getByIdCabecera(String idasiento)
        {
            return DAL.getByIdCabecera(idasiento);
        }
        public DataTable getByFechaDataTable(DateTime fechainicio, DateTime fechafin)
        {
            return DAL.getByFechaDataTable(fechainicio, fechafin);
        }
        }
}