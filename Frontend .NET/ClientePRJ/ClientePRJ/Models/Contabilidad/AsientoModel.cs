using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientePRJ.Models.Contabilidad
{
    public class AsientoModel
    {
        public int idasiento { get; set; }       
        public DateTime fechaasiento { get; set; }
        public string observacionasiento { get; set; }
    }
}