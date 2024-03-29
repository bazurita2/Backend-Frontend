using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPrueba.Model
{
    public class Rubro
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string id { get; set; }
        [BsonElement("idCatalogo")]
        public string idCatalogo { get; set; }
        [BsonElement("idNomina")]
        public string idNomina { get; set; }
        [BsonElement("valorRubro")]
        public string valorRubro { get; set; }
    }
}
