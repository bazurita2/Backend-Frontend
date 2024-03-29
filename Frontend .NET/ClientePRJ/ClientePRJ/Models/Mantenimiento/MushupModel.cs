using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientePRJ.Models.Mantenimiento
{
    public class MushupModel
    {
        public Int32 id { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public string species { get; set; }
        public string gender { get; set; }
        public string image { get; set; }
    }
}