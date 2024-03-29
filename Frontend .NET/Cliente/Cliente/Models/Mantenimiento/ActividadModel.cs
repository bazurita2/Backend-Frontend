using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Cliente.Models.Mantenimiento
{
    public class ActividadModel
    {

        public string idactividad { get; set; }
        public string idempleado { get; set; }
        public string idtransaccion { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime fechaactividad { get; set; }
    }
}