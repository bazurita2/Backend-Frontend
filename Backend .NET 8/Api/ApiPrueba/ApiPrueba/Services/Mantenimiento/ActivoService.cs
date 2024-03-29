using ApiPrueba.Model;
using ApiPrueba.Model.Mantenimiento;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiPrueba.Services.Mantenimiento
{
    public class ActivoService
    {
        private IMongoCollection<Activo> IMongoCollection;


        public ActivoService(IBarSettings settings)
        {
            var client = new MongoClient(settings.Server);
            var database = client.GetDatabase(settings.Database);

            IMongoCollection = database.GetCollection<Activo>("activo");
        }

        public List<Activo> GetAllActivos()
        {
            return IMongoCollection.Find(activos => true).ToList();
        }

        public List<Activo> GetActivoById(String id)
        {
            return IMongoCollection.Find(activo => activo.idactivo == id).ToList();
        }
        public List<Activo> GetActivoByNombre(String nombre)
        {
            return IMongoCollection.Find(activo => activo.nombreactivo == nombre).ToList();
        }

        public void AddActivo(Activo activo)
        {
            IMongoCollection.InsertOne(activo);
        }

        public void UpdateActivo(String id, Activo activo)
        {
            IMongoCollection.ReplaceOne(activo => activo.idactivo == id, activo);
        }

        public void DeleteActivo(String id)
        {
            IMongoCollection.DeleteOne(activo => activo.idactivo == id);
        }
    }
}
