using System;
using MongoDB.Bson.Serialization.Attributes;


namespace ApiPrueba.Model
{
    public class Asiento
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string idasiento { get; set; }
        [BsonElement("fechaasiento")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime fechaasiento { get; set; }
        [BsonElement("observacionasiento")]
        public string observacionasiento { get; set; }

    }

}