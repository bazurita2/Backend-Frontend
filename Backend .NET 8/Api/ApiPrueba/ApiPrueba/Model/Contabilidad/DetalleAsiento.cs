using System;
using MongoDB.Bson.Serialization.Attributes;


namespace ApiPrueba.Model.Contabilidad
{
    public class DetalleAsiento
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string iddetalle { get; set; }
        [BsonElement("idcuenta")]
        public string idcuenta { get; set; }
        [BsonElement("debedetalle")]
        public string debedetalle { get; set; }
        [BsonElement("haberdetalle")]
        public string haberdetalle { get; set; }
        [BsonElement("idasiento")]
        public string idasiento { get; set; }

    }

}