using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MongoDB.Bson.Serialization.Attributes;

namespace clienteG2.Models
{
    public class EmpleadoModel
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string cedula { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime fechaIngreso { get; set; }
        public string usuario { get; set; }
        public string contrasena { get; set; }
        public string sueldo { get; set; }
    }
}