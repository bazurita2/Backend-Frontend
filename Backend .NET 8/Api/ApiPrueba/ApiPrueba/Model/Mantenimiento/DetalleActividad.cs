using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPrueba.Model.Mantenimiento
{
    public class DetalleActividad
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string iddetalleactividad { get; set; }
        [BsonElement("idactividad")]
        public string idactividad { get; set; }
        [BsonElement("idcatactividad")]
        public string idcatactividad { get; set; }
        [BsonElement("idactivo")]
        public string idactivo { get; set; }
        [BsonElement("valordetalleactividad")]
        public double valordetalleactividad { get; set; }
    }
}
