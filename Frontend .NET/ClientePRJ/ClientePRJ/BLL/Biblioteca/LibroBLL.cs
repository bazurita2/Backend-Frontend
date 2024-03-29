using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ClientePRJ.Models.Biblioteca;
using ClientePRJ.DAL.Biblioteca;


namespace ClientePRJ.BLL
{
    public class LibroBLL
    {
        private readonly LibroDAL DAL = new LibroDAL();

        public DataTable listarLibro()
        {
            return DAL.listarLibro();
        }
        
        public bool insertarLibro(LibroModel a)
        {
            return DAL.insertarLibro(a);
        }
        
        public bool actualizarLibro(LibroModel a)
        {
            return DAL.actualizarLibro(a);
        }

        
        public DataTable LibrosByCoincidence(String coincidence)
        {
            return DAL.getLibrosByCoincidence(coincidence);
        }

        public bool eliminarLibro(String id)
        {
            return DAL.eliminarLibro(id);
        }
        /*
        
        public AutorModel getAutorById(String id)
        {
            return DAL.getAutorById(id);
        }
        public DataTable getAutorByIdDataTable(String id)
        {
            return DAL.getAutorByIdDataTable(id);
        }
        public DataTable getAutorByNombreDataTable(String nombre)
        {
            return DAL.getAutorByNombreDataTable(nombre);
        }

        //-------
        public IEnumerable<AutorModel> valoresAutor()
        {
            return DAL.valoresAutor();
        }
        */
    }
}