using ClientePRJ.DAL.Contabilidad;
using ClientePRJ.Models.Contabilidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


namespace ClientePRJ.BLL.Contabilidad
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
        public bool eliminar(int id)
        {
            return DAL.eliminar(id);
        }
        //public CuentaModel getById(int id)
        //{
        //    return DAL.getById(id);
        //}
        //public DataTable getByIdDataTable(String id)
        //{
        //    return DAL.getByIdDataTable(id);
        //}
        public DataTable getByNombreDataTable(String nombre)
        {
            return DAL.getByNombreDataTable(nombre);
        }
        public DataTable getByIdDataTable(int id)
        {
            return DAL.getByIdDataTable(id);
        }

    }
}