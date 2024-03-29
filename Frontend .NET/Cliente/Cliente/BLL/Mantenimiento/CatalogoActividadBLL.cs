using Cliente.DAL.Mantenimiento;
using Cliente.Models.Mantenimiento;
using System;
using System.Collections.Generic;
using System.Data;

namespace Cliente.BLL.Mantenimiento
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

        public List<CatalogoActividadModel> getAllCatalogoActividades()
        {
            return DAL.getAllCatalogoActividades();
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
        public DataTable getCatalogoActividadByIdDataTable(String id)
        {
            return DAL.getCatalogoActividadByIdDataTable(id);
        }
        public DataTable getCatalogoActividadByNombreDataTable(String nombre)
        {
            return DAL.getCatalogoActividadByNombreDataTable(nombre);
        }
    }
}