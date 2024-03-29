using Cliente.Models.Nomina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cliente.DAL.Nomina
{
    public class NominaRubros
    {
        public NominaModel nomina { set; get; }
        public IEnumerable<RubroModel> rubrosToInsert { set; get; }
    }
}