using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPrueba.Model
{
    public class Nomina
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string id { get; set; }
        [BsonElement("idTransaccion")]
        public string idTransaccion { get; set; }
        [BsonElement("idEmpleado")]
        public string idEmpleado { get; set; }
        [BsonElement("estadoNomina")]
        public string estadoNomina { get; set; }
     
        [BsonElement("fechaNomina")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime fechaNomina { get; set; }
    }
}
