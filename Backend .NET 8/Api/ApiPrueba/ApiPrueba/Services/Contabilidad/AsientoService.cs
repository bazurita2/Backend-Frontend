using ApiPrueba.Model;
using ApiPrueba.Model.Contabilidad;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPrueba.Services.Contabilidad
{
    public class AsientoService
    {
        private IMongoCollection<Asiento> IMongoCollection;

        public AsientoService(IBarSettings settings)
        {
            var client = new MongoClient(settings.Server);
            var database = client.GetDatabase(settings.Database);

            IMongoCollection = database.GetCollection<Asiento>("asiento");
        }

        public List<Asiento> GetAllAsiento()
        {
            return IMongoCollection.Find(asiento => true).ToList();
        }

        public List<Asiento> GetAsientoById(String id)
        {
            return IMongoCollection.Find(asiento => asiento.idasiento== id).ToList();
        }
        public List<Asiento> GetAsientoByFecha(DateTime fechainicio, DateTime fechafin)
        {
            return IMongoCollection.Find(asiento => asiento.fechaasiento <=
            fechafin.ToUniversalTime() && asiento.fechaasiento >=
            fechainicio.ToUniversalTime()).ToList();
        }

        public void AddAsiento(Asiento asiento)
        {
            IMongoCollection.InsertOne(asiento);
        }

        public void UpdateAsiento(String id, Asiento asiento)
        {
            IMongoCollection.ReplaceOne(asiento => asiento.idasiento== id, asiento);
        }

        public void DeleteAsiento(String id)
        {
            IMongoCollection.DeleteOne(asiento => asiento.idasiento== id);
        }
    }
}
