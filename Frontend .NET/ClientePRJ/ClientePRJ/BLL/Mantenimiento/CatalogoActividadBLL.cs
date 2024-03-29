using ClientePRJ.DAL.Mantenimiento;
using ClientePRJ.Models.Mantenimiento;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ClientePRJ.BLL.Mantenimiento
{
    public class CatalogoActividadBLL
    {
        private readonly CatalogoActividadDAL DAL = new CatalogoActividadDAL();
        public DataTable listarCatalogosActividades()
        {
            return DAL.listarCatalogoActividades();
        }
        public bool insertarCatalogoActividad(CatalogoActividadModel c)
        {
            return DAL.insertarCatalogoActividad(c);
        }

        public bool actualizarCatalogoActividad(CatalogoActividadModel c)
        {
            return DAL.actualizarCatalogoActividad(c);
        }
        public bool eliminarCatalogoActividad(String id)
        {
            return DAL.eliminarCatalogoActividad(id);
        }
        public CatalogoActividadModel getCatalogoActividadById(String id)
        {
            return DAL.getCatalogoActividadById(id);
        }
        public DataTable getCatalogoActividadByNombreDataTable(String nombre)
        {
            return DAL.getCatalogoActividadByNombreDataTable(nombre);
        }
        public List<CatalogoActividadModel> getAllCatalogoActividades()
        {
            return DAL.getAllCatalogoActividades();
        }
    }
}