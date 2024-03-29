using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientePRJ.Models.Contabilidad
{
    public class CuentaModel
    {
        public int idcuenta { get; set; }
        public int idtipocuenta { get; set; }
        public string numerocuenta { get; set; }
        public string nombrecuenta { get; set; }
        public string descripcioncuenta { get; set; }
    }
}