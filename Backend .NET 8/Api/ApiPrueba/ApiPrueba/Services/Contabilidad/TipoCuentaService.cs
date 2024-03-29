using ApiPrueba.Model;
using ApiPrueba.Model.Contabilidad;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPrueba.Services.Contabilidad
{
    public class TipoCuentaService
    {
        private IMongoCollection<TipoCuenta> IMongoCollection;

        public TipoCuentaService(IBarSettings settings)
        {
            var client = new MongoClient(settings.Server);
            var database = client.GetDatabase(settings.Database);

            IMongoCollection = database.GetCollection<TipoCuenta>("tipocuenta");
        }

        public List<TipoCuenta> GetAllTipoCuenta()
        {
            return IMongoCollection.Find(tipocuenta => true).ToList();
        }

        public List<TipoCuenta> GetTipoCuentaById(String id)
        {
            return IMongoCollection.Find(tipocuenta => tipocuenta.idtipocuenta== id).ToList();
        }
        public List<TipoCuenta> GetTipoCuentaByNombre(String nombre)
        {
            return IMongoCollection.Find(tipocuenta => tipocuenta.nombretipocuenta == nombre).ToList();
        }

        public void AddTipoCuenta(TipoCuenta tipo)
        {
            IMongoCollection.InsertOne(tipo);
        }

        public void UpdateTipoCuenta(String id, TipoCuenta tipocuenta)
        {
            IMongoCollection.ReplaceOne(tipocuenta => tipocuenta.idtipocuenta== id, tipocuenta);
        }

        public void DeleteTipoCuenta(String id)
        {
            IMongoCollection.DeleteOne(tipocuenta => tipocuenta.idtipocuenta== id);
        }
    }
}
