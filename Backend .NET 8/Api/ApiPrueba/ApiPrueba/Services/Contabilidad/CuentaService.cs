using ApiPrueba.Model;
using ApiPrueba.Model.Contabilidad;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPrueba.Services.Contabilidad
{
    public class CuentaService
    {
        private IMongoCollection<Cuenta> IMongoCollection;

        public CuentaService(IBarSettings settings)
        {
            var client = new MongoClient(settings.Server);
            var database = client.GetDatabase(settings.Database);

            IMongoCollection = database.GetCollection<Cuenta>("cuenta");
        }

        public List<Cuenta> GetAllCuenta()
        {
            return IMongoCollection.Find(cuenta => true).ToList();
        }

        public List<Cuenta> GetCuentaById(String id)
        {
            return IMongoCollection.Find(cuenta => cuenta.idcuenta== id).ToList();
        }
        public List<Cuenta> GetCuentaByNombre(String nombre)
        {
            return IMongoCollection.Find(cuenta => cuenta.nombrecuenta== nombre).ToList();
        }

        public void AddCuenta(Cuenta tipo)
        {
            IMongoCollection.InsertOne(tipo);
        }

        public void UpdateCuenta(String id, Cuenta cuenta)
        {
            IMongoCollection.ReplaceOne(cuenta => cuenta.idcuenta== id, cuenta);
        }

        public void DeleteCuenta(String id)
        {
            IMongoCollection.DeleteOne(cuenta => cuenta.idcuenta== id);
        }
    }
}
