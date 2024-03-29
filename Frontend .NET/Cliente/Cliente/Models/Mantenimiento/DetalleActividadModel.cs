using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cliente.Models.Mantenimiento
{
    public class DetalleActividadModel
    {

        public string iddetalleactividad { get; set; }
        public string idactividad { get; set; }
        public string idcatactividad { get; set; }
        public string idactivo { get; set; }
        public double valordetalleactividad { get; set; }
    }
}