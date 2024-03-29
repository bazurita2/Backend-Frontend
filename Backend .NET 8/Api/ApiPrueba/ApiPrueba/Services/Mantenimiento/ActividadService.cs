using ApiPrueba.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiPrueba.Services.Mantenimiento
{
    public class ActividadService
    {
        private IMongoCollection<Actividad> IMongoCollection;

        public ActividadService(IBarSettings settings)
        {
            var client = new MongoClient(settings.Server);
            var database = client.GetDatabase(settings.Database);

            IMongoCollection = database.GetCollection<Actividad>("actividad");
        }

        public List<Actividad> GetAllActividades()
        {
            return IMongoCollection.Find(actividades => true).ToList();
        }

        public List<Actividad> GetActividadesByFecha(DateTime fecha)
        {
            return IMongoCollection.Find(actividades => actividades.fechaactividad 
            == fecha.ToUniversalTime()).ToList();
        }

        public void AddActividad(Actividad actividad)
        {
            IMongoCollection.InsertOne(actividad);
        }

        public Actividad GetLastActividad()
        {
            List<Actividad> lista = IMongoCollection.Find(actividad => true).ToList();
            return lista[lista.Count - 1];
        }

        public void UpdateActividad(String id, Actividad actividad)
        {
            IMongoCollection.ReplaceOne(actividad => actividad.idactividad == id, actividad);
        }

        public void DeleteActividad(String id)
        {
            IMongoCollection.DeleteOne(actividad => actividad.idactividad == id);
        }

    }
}
