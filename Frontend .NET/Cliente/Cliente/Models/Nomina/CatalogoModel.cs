using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace clienteG2.Models
{
    public class CatalogoModel
    {
       public string id { get; set; }
        public string descripcionCatalogo { get; set; }
        public string tipoCatalogo { get; set; }
        public int Valor_FDSC { get; set; }
    }
}