using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ClientePRJ.Models.Biblioteca;
using ClientePRJ.DAL.Biblioteca;


namespace ClientePRJ.BLL
{
    public class PrestamoBLL
    {
        private readonly PrestamoDAL DAL = new PrestamoDAL();

        public DataTable listarPrestamo()
        {
            return DAL.listarPrestamo();
        }
        
        public bool insertarPrestamo(PrestamoModel a)
        {
            return DAL.insertarPrestamo(a);
        }

        public bool eliminarPrestamo(String id)
        {
            return DAL.eliminarPrestamo(id);
        }

        public DataTable detallesDePrestamo(string id)
        {
            return DAL.getDetallesDePrestamo(id);
        }

        public PrestamoModel getPrestamo(string id)
        {
            return DAL.getPrestamoById(id);
        }

        
        public DataTable PrestamosByCoincidence(string coincidence)
        {
            return DAL.PrestamosByCoincidence(coincidence);
        }

        
        public DataTable getLibrosPorDia(string inicio, string final)
        {
            return DAL.getLibrosPorDia(inicio,final);
        }
        
        public DataTable detallesTotal()
        {
            return DAL.detallesTotal();
        }
        /*
        public bool actualizarPrestamo(PrestamoModel a)
        {
            return DAL.actualizarPrestamo(a);
        }

        
        public DataTable PrestamoesByCoincidence(String coincidence)
        {
            return DAL.getPrestamoByCoincidence(coincidence);
        }

       
        */
        /*
        
        public PrestamoModel getPrestamoById(String id)
        {
            return DAL.getPrestamoById(id);
        }
        public DataTable getPrestamoByIdDataTable(String id)
        {
            return DAL.getPrestamoByIdDataTable(id);
        }
        public DataTable getPrestamoByNombreDataTable(String nombre)
        {
            return DAL.getPrestamoByNombreDataTable(nombre);
        }

        //-------
        public IEnumerable<PrestamoModel> valoresPrestamo()
        {
            return DAL.valoresPrestamo();
        }
        */
    }
}