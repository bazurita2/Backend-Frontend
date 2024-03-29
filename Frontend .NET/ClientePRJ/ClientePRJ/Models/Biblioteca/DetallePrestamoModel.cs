using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientePRJ.Models.Biblioteca
{
    public class DetallePrestamoModel
    {
        public int idDetalleP { get; set; }
        public int idLibro { get; set; }
        public int idPrestamo { get; set; }
        public int cantidadDetalleP { get; set; }
        public string fechaEntregaDetalleP { get; set; }
        
    }
}