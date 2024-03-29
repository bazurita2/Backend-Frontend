using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPrueba.Model
{
    public class Empleado
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string id { get; set; }
        [BsonElement("nombre")]
        public string nombre { get; set; }
        [BsonElement("apellido")]
        public string apellido { get; set; }
        [BsonElement("cedula")]
        public string cedula { get; set; }
        [BsonElement("fechaIngreso")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime fechaIngreso { get; set; }
        [BsonElement("sueldo")]
        public string sueldo { get; set; }
        [BsonElement("usuario")]
        public string usuario { get; set; }
        [BsonElement("contrasena")]
        public string contrasena { get; set; }

    }
}
