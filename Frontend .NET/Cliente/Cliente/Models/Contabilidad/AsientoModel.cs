using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Cliente.Models.Contabilidad
{
    public class AsientoModel
    {
        public string idasiento { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime fechaasiento { get; set; }
        public string observacionasiento { get; set; }
        
    }
}