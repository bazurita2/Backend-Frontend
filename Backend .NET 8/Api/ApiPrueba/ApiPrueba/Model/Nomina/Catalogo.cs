using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPrueba.Model
{
    public class Catalogo
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string id { get; set; }
        [BsonElement("descripcionCatalogo")]
        public string descripcionCatalogo { get; set; }
        [BsonElement("tipoCatalogo")]
        public string tipoCatalogo { get; set; }
        [BsonElement("Valor_FDSC")]
        public int Valor_FDSC { get; set; }
    }
}
