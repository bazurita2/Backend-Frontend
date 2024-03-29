using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;

namespace Cliente.Models.Nomina
{
    public class NominaModel
    {
        public string id { get; set; }
        public string idTransaccion { get; set; }
        public string idEmpleado { get; set; }
        public string estadoNomina { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime fechaNomina { get; set; }
    }
}