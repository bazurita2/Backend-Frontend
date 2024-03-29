using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPrueba.Model
{
    public class Usuario
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string idempleado { get; set; }
        [BsonElement("cedulaempleado")]
        public string cedulaempleado { get; set; }
        [BsonElement("nombreempleado")]
        public string nombreempleado { get; set; }
        [BsonElement("apellidoempleado")]
        public string apellidoempleado { get; set; }
        [BsonElement("usuarioempleado")]
        public string usuarioempleado { get; set; }
        [BsonElement("claveempleado")]
        public string claveempleado { get; set; }
        [BsonElement("fechacontratacionempleado")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime fechacontratacionempleado { get; set; }
        [BsonElement("correoempleado")]
        public string correoempleado { get; set; }
        [BsonElement("direccionempleado")]
        public string direccionempleado { get; set; }
        [BsonElement("telefonoempleado")]
        public string telefonoempleado { get; set; }
        [BsonElement("sueldoempleado")]
        public double sueldoempleado { get; set; }

    }
}
