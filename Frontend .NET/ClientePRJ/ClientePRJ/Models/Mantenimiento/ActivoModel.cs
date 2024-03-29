using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientePRJ.Models.Mantenimiento
{
    public class ActivoModel
    {
        public string idactivo { get; set; }
        public double precioactivo { get; set; }
        public string nombreactivo { get; set; }
        public string tipoactivo { get; set; }
        public string estadoactivo { get; set; }
        public DateTime fechacompraactivo { get; set; }
        public string latitudactivo { get; set; }
        public string longitudactivo { get; set; }
        public string largo_bazb { get; set; }
        public string ancho_bazb { get; set; }
        public void dataToString()
        {
            System.Diagnostics.Debug.WriteLine(" idactivo: " + idactivo +
                " precioactivo: " + precioactivo + " nombreactivo: " + nombreactivo +
                " tipoactivo: " + tipoactivo + " estadoactivo: " + estadoactivo +
                " fechacompraactivo " + fechacompraactivo);
        }
    }
}