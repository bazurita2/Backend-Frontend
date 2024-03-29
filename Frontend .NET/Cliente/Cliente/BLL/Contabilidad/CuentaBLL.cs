using Cliente.DAL.Contabilidad;
using Cliente.Models.Contabilidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


namespace Cliente.BLL.Contabilidad
{
    public class CuentaBLL
    {
        private readonly CuentaDAL DAL = new CuentaDAL();
        public DataTable listar()
        {
            return DAL.listar();
        }
        public bool insertar(CuentaModel a)
        {
            return DAL.insertar(a);
        }

        public bool actualizar(CuentaModel a)
        {
            return DAL.actualizar(a);
        }
        public bool eliminar(String id)
        {
            return DAL.eliminar(id);
        }
        public CuentaModel getById(String id)
        {
            return DAL.getById(id);
        }
        public DataTable getByIdDataTable(String id)
        {
            return DAL.getByIdDataTable(id);
        }
        public DataTable getByNombreDataTable(String nombre)
        {
            return DAL.getByNombreDataTable(nombre);
        }

    }
}