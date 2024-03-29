using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Cliente.Models
{
    public class ActivoModel
    {
        public string idactivo { get; set; }
        public string nombreactivo { get; set; }
        public string tipoactivo { get; set; }
        public string estadoactivo { get; set; }
        public double precioactivo { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime fechacompraactivo { get; set; }
    }


}