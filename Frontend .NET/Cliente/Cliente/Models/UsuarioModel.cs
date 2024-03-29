using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cliente.Models
{
    public class UsuarioModel
    {
        public string idempleado { get; set; }
        public string cedulaempleado { get; set; }
        public string nombreempleado { get; set; }
        public string apellidoempleado { get; set; }
        public string usuarioempleado { get; set; }
        public string claveempleado { get; set; }
        public DateTime fechacontratacionempleado { get; set; }
        public string correoempleado { get; set; }
        public string direccionempleado { get; set; }
        public string telefonoempleado { get; set; }
        public double sueldoempleado { get; set; }
    }
}