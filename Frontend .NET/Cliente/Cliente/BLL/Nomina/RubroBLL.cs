using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

using Cliente.DAL.Nomina;
using Cliente.Models.Nomina;

namespace Cliente.BLL.Nomina
{
    public class RubroBLL
    {
        private readonly RubroDAL DAL = new RubroDAL();
        public DataTable getRubrosByIdNomina(String idEmpleado)
        {
            return DAL.getRubrosByIdNomina(idEmpleado);
        }
        public bool insertarRubro(RubroModel a)
        {
            return DAL.insertarRubro(a);
        }

        public bool actualizarRubro(RubroModel r)
        {
            return DAL.actualizarRubro(r);
        }
        public bool eliminarRubro(String id)
        {
            return DAL.eliminarRubro(id);
        }
    }
}