using MongoDB.Bson.Serialization.Attributes;
using System;

namespace ApiPrueba.Model.Mantenimiento
{
    public class Activo
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string idactivo { get; set; }
        [BsonElement("nombreactivo")]
        public string nombreactivo { get; set; }
        [BsonElement("tipoactivo")]
        public string tipoactivo { get; set; }
        [BsonElement("estadoactivo")]
        public string estadoactivo { get; set; }
        [BsonElement("precioactivo")]
        public double precioactivo { get; set; }
        [BsonElement("fechacompraactivo")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime fechacompraactivo { get; set; }
    }
}
