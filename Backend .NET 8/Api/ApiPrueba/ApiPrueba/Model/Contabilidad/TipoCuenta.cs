using System;
using MongoDB.Bson.Serialization.Attributes;

namespace ApiPrueba.Model.Contabilidad
{
    public class TipoCuenta
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string idtipocuenta { get; set; }
        [BsonElement("nombretipocuenta")]
        public string nombretipocuenta { get; set; }
        [BsonElement("descripciontipocuenta")]
        public string descripciontipocuenta { get; set; }
       
    }
}
