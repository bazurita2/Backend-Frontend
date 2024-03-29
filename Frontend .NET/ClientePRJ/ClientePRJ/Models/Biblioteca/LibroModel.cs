using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientePRJ.Models.Biblioteca
{
    public class LibroModel
    {
        public int idLibro { get; set; }
        public int idAutor { get; set; }
        public string ISBNLibro { get; set; }
        public string tituloLibro { get; set; }
        public string valorPrestamoLibro { get; set; }


    }
}