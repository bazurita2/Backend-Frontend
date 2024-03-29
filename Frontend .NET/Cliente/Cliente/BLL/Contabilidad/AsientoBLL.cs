using Cliente.DAL.Contabilidad;
using Cliente.Models.Contabilidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Cliente.BLL.Contabilidad
{
    public class AsientoBLL
    {
        private readonly AsientoDAL DAL = new AsientoDAL();
        public DataTable listar()
        {
            return DAL.listar();
        }
        public List<AsientoModel> listarToList()
        {
            return DAL.listarToList();
        }
        //public String getLast()
        //{
        //    return DAL.getLast();
        //}
        public bool insertar(AsientoModel a)
        {
            return DAL.insertar(a);
        }

        public bool actualizar(AsientoModel a)
        {
            return DAL.actualizar(a);
        }
        public bool eliminar(String id)
        {
            return DAL.eliminar(id);
        }
        public List<AsientoModel> getById(String id)
        {
            return DAL.getById(id);
        }
        public DataTable getByIdDataTable(String id)
        {
            return DAL.getByIdDataTable(id);
        }
        public DataTable getByFechaDataTable(DateTime fechainicio, DateTime fechafin)
        {
            return DAL.getByFechaDataTable(fechainicio,fechafin);
        }

    }
}