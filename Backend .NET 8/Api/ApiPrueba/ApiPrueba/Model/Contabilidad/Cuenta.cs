using System;
using MongoDB.Bson.Serialization.Attributes;

namespace ApiPrueba.Model.Contabilidad
{
    public class Cuenta
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string idcuenta { get; set; }
        [BsonElement("numerocuenta")]
        public string numerocuenta { get; set; }
        [BsonElement("idtipocuenta")]
        public string idtipocuenta { get; set; }
        [BsonElement("nombrecuenta")]
        public string nombrecuenta { get; set; }
        [BsonElement("descripcioncuenta")]
        public string descripcioncuenta { get; set; }
       
    }
}
