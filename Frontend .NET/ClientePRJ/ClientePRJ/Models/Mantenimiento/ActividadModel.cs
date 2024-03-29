using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientePRJ.Models.Mantenimiento
{
    public class ActividadModel
    {
        public string idactividad { get; set; }
        public DateTime fechaactividad { get; set; }

        public string responsableactividad { get; set; }
    }
}