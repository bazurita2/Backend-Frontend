using ApiPrueba.Model;
using ApiPrueba.Model.Mantenimiento;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiPrueba.Services.Mantenimiento
{
    public class CatalogoActividadService
    {
        private IMongoCollection<CatalogoActividad> IMongoCollection;

        public CatalogoActividadService(IBarSettings settings)
        {
            var client = new MongoClient(settings.Server);
            var database = client.GetDatabase(settings.Database);

            IMongoCollection = database.GetCollection<CatalogoActividad>("catalogoactividad");
        }

        public List<CatalogoActividad> GetAllCatalogoActividades()
        {
            return IMongoCollection.Find(catalogoActividades => true).ToList();
        }

        public List<CatalogoActividad> GetCatalogoActividadById(String id)
        {
            return IMongoCollection.Find(catalogoActividad => catalogoActividad.idcatactividad == id).ToList();
        }
        public List<CatalogoActividad> GetCatalogoActividadByNombre(String nombre)
        {
            return IMongoCollection.Find(catalogoActividad => catalogoActividad.nombrecatactividad == nombre).ToList();
        }

        public void AddCatalogoActividad(CatalogoActividad catalogoActividad)
        {
            IMongoCollection.InsertOne(catalogoActividad);
        }

        public void UpdateCatalogoActividad(String id, CatalogoActividad catalogoActividad)
        {
            IMongoCollection.ReplaceOne(catalogoActividad => catalogoActividad.idcatactividad == id, catalogoActividad);
        }

        public void DeleteCatalogoActividad(String id)
        {
            IMongoCollection.DeleteOne(catalogoActividad => catalogoActividad.idcatactividad == id);
        }

    }
}
