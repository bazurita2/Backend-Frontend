using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPrueba.Model
{
    public class Actividad
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string idactividad { get; set; }
        [BsonElement("idempleado")]
        public string idempleado { get; set; }
        [BsonElement("idtransaccion")]
        public string idtransaccion { get; set; }
        [BsonElement("fechaactividad")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime fechaactividad { get; set; }
    }
}
