using Cliente.DAL.Contabilidad;
using Cliente.Models.Contabilidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Cliente.BLL.Contabilidad
{
    public class TipoCuentaBLL
    {
        private readonly TipoCuentaDAL DAL = new TipoCuentaDAL();
        public DataTable listar()
        {
            return DAL.listar();
        }
        public bool insertar(TipoCuentaModel a)
        {
            return DAL.insertar(a);
        }

        public bool actualizar(TipoCuentaModel a)
        {
            return DAL.actualizar(a);
        }
        public bool eliminar(String id)
        {
            return DAL.eliminar(id);
        }
        public TipoCuentaModel getById(String id)
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