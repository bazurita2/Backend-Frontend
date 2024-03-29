
using Cliente.DAL.Nomina;
using Cliente.Models;
using clienteG2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Cliente.BLL.Nomina
{
    public class CatalogoBLL
    {
        private readonly CatalogoDAL DAL = new CatalogoDAL();

        public DataTable listarCatalogo()
        {
            return DAL.listarCatalogo();
        }
        public bool insertarCatalogo(CatalogoModel a)
        {
            return DAL.insertarCatalogo(a);
        }

        public bool actualizarCatalogo(CatalogoModel a)
        {
            return DAL.actualizarCatalogo(a);
        }
        public bool eliminarCatalogo(String id)
        {
            return DAL.eliminarCatalogo(id);
        }
        public CatalogoModel getCatalogoById(String id)
        {
            return DAL.getCatalogoById(id);
        }
        public DataTable getCatalogoByIdDataTable(String id)
        {
            return DAL.getCatalogoByIdDataTable(id);
        }
        public DataTable getCatalogoByNombreDataTable(String nombre)
        {
            return DAL.getCatalogoByNombreDataTable(nombre);
        }

        //-------
        public IEnumerable<CatalogoModel> valoresCatalogo()
        {
            return DAL.valoresCatalogo();
        }

    }
}