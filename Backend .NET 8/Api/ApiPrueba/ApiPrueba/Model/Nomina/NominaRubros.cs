using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPrueba.Model
{
    public class NominaRubros
    {
        public Nomina nomina { set; get; }
        public IEnumerable<Rubro> rubrosToInsert { set; get; }
    }
}
