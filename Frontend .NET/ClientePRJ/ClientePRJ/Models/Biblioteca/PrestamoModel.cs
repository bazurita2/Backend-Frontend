using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientePRJ.Models.Biblioteca
{
    public class PrestamoModel
    {
        public int idPrestamo { get; set; }
        public int numeroPrestamo { get; set; }
        public string fechaPrestamo { get; set; }
        public string descripcionPrestamo { get; set; }
        public List<DetallePrestamoModel> detallesPrestamo { get; set; }

    }
}