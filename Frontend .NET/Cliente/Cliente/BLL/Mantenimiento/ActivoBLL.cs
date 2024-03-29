using Cliente.DAL;
using Cliente.Models;
using System;
using System.Collections.Generic;
using System.Data;


namespace Cliente.BLL
{
    public class ActivoBLL
    {
        private readonly ActivoDAL DAL = new ActivoDAL();
        public DataTable listarActivo()
        {
            return DAL.listarActivo();
        }

        public List<ActivoModel> getAllActivos()
        {
            return DAL.getAllActivos();
        }
        public bool insertarActivo(ActivoModel a)
        {
            return DAL.insertarActivo(a);
        }

        public bool actualizarActivo(ActivoModel a)
        {
            return DAL.actualizarActivo(a);
        }
        public bool eliminarActivo(String id)
        {
            return DAL.eliminarActivo(id);
        }
        public ActivoModel getActivoById(String id)
        {
            return DAL.getActivoById(id);
        }
        public DataTable getActivoByIdDataTable(String id)
        {
            return DAL.getActivoByIdDataTable(id);
        }
        public DataTable getActivoByNombreDataTable(String nombre)
        {
            return DAL.getActivoByNombreDataTable(nombre);
        }

        public IEnumerable<ActivoModel> listarNombresActivos()
        {
            return DAL.listarNombresActivos();
        }

    }
}