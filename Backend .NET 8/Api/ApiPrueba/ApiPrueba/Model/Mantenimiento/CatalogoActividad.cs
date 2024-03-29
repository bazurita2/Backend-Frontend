using MongoDB.Bson.Serialization.Attributes;

namespace ApiPrueba.Model.Mantenimiento
{
    public class CatalogoActividad
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string idcatactividad { get; set; }
        [BsonElement("nombrecatactividad")]
        public string nombrecatactividad { get; set; }
        [BsonElement("descripcioncatactividad")]
        public string descripcioncatactividad { get; set; }
    }
}
