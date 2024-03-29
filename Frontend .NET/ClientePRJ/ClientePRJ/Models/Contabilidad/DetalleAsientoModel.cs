using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientePRJ.Models.Contabilidad
{
    public class DetalleAsientoModel
    {
        public int iddetalleasiento { get; set; }
        public int idcuenta { get; set; }
        public decimal debedetalle { get; set; }
        public decimal haberdetalle { get; set; }
        public int idasiento { get; set; }
    }
}