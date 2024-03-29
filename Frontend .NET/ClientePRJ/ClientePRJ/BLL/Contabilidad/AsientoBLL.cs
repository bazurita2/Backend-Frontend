using ClientePRJ.DAL.Contabilidad;
using ClientePRJ.Models.Contabilidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ClientePRJ.BLL.Contabilidad
{
    public class AsientoBLL
    {
        private readonly AsientoDAL DAL = new AsientoDAL();
        public DataTable listar()
        {
            return DAL.listar();
        }
        //public List<AsientoModel> listarToList()
        //{
        //   // return DAL.listarToList();
        //}
        //public String getLast()
        //{
        //    return DAL.getLast();
        //}
        public string insertar(AsientoModel a)
        {
            return DAL.insertar(a);
        }

        public bool actualizar(AsientoModel a)
        {
            return DAL.actualizar(a);
        }
        public bool eliminar(int id)
        {
            return DAL.eliminar(id);
        }
        public AsientoModel getById(int id)
        {
            return DAL.getById(id);
        }
        public DataTable getByFechas(DateTime inicio, DateTime fin)
        {
            return DAL.getByFechas(inicio,fin);
        }
        //public DataTable getByFechaDataTable(DateTime fechainicio, DateTime fechafin)
        //{
        //    return DAL.getByFechaDataTable(fechainicio, fechafin);
        //}

    }
}