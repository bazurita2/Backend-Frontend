
using Cliente.DAL.Nomina;
using Cliente.Models;
using Cliente.Models.Nomina;
using clienteG2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Cliente.BLL.Nomina
{
    public class NominaBLL
    {
        private readonly NominaDAL DAL = new NominaDAL();

        public DataTable listarNomina()
        {
            return DAL.listarNomina();
        }
        public bool insertarNomina(NominaRubros a)
        {
            return DAL.insertarNomina(a);
        }

        public bool actualizarNomina(NominaModel a)
        {
            return DAL.actualizarNomina(a);
        }
        public bool eliminarNomina(String id)
        {
            return DAL.eliminarNomina(id);
        }
        public NominaModel getNominaById(String id)
        {
            return DAL.getNominaById(id);
        }
        public DataTable getNominaByIdDataTable(String id)
        {
            return DAL.getNominaByIdDataTable(id);
        }
      

        public DataTable listarNominasEmpleado(String idEmpleado)
        {
            return DAL.listarNominasEmpleado(idEmpleado);
        }
        public DataTable listarNominasByRangoFechas(DateTime lowerDate, DateTime higherDate)
        {
            return DAL.listarNominasByRangoFechas(lowerDate,higherDate);
        }

        public DataTable listarNominaFiltradaPorEmpleado(String nombre)
        {
            return DAL.listarNominaFiltradaPorEmpleado(nombre);
        }

    }
}