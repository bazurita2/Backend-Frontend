
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
    public class EmpleadoBLL
    {
        private readonly EmpleadoDAL DAL = new EmpleadoDAL();

        public DataTable listarEmpleado()
        {
            return DAL.listarEmpleado();
        }
        public bool insertarEmpleado(EmpleadoModel a)
        {
            return DAL.insertarEmpleado(a);
        }

        public bool actualizarEmpleado(EmpleadoModel a)
        {
            return DAL.actualizarEmpleado(a);
        }
        public bool eliminarEmpleado(String id)
        {
            return DAL.eliminarEmpleado(id);
        }
        public EmpleadoModel getEmpleadoById(String id)
        {
            return DAL.getEmpleadoById(id);
        }
        public DataTable getEmpleadoByIdDataTable(String id)
        {
            return DAL.getEmpleadoByIdDataTable(id);
        }
        public DataTable getEmpleadoByNombreDataTable(String nombre)
        {
            return DAL.getEmpleadoByNombreDataTable(nombre);
        }

        public List<EmpleadoModel> getAllEmpleados()
        {
            return DAL.getAllEmpleados();
        }

    }
}