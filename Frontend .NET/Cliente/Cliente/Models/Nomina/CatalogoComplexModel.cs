using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace clienteG2.Models
{
    public class CatalogoComplexModel
    {
       public  IEnumerable<clienteG2.Models.CatalogoModel> catalogos { get; set; }
       public CatalogoModel catalogo { get; set; }
    }
}