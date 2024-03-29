using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Cliente.Models.Contabilidad
{
    public class DetalleAsientoModel
    {
        public string iddetalleasiento { get; set; }        
        public string idcuenta { get; set; }
        public string debedetalle { get; set; }
        public string haberdetalle { get; set; }
        public string idasiento { get; set; }

    }
}