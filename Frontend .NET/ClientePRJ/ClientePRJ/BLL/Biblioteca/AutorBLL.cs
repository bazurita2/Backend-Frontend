using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ClientePRJ.Models.Biblioteca;
using ClientePRJ.DAL.Biblioteca;


namespace ClientePRJ.BLL
{
    public class AutorBLL
    {
        private readonly AutorDAL DAL = new AutorDAL();

        public DataTable listarAutor()
        {
            return DAL.listarAutor();
        }
        
        public bool insertarAutor(AutorModel a)
        {
            return DAL.insertarAutor(a);
        }
        
        public bool actualizarAutor(AutorModel a)
        {
            return DAL.actualizarAutor(a);
        }

        
        public DataTable AutoresByCoincidence(String coincidence)
        {
            return DAL.getAutorByCoincidence(coincidence);
        }

        public bool eliminarAutor(String id)
        {
            return DAL.eliminarAutor(id);
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