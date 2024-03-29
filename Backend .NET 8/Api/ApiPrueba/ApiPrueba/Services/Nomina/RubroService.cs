using ApiPrueba.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPrueba
{
    public class RubroService
    {
        private IMongoCollection<Rubro> rubros;

        public RubroService(IBarSettings settings)
        {
            var client = new MongoClient(settings.Server);
            var database = client.GetDatabase(settings.Database);

            rubros = database.GetCollection<Rubro>("Rubro");
        }

        public List<Rubro> Get()
        {
            return rubros.Find(d => true).ToList();
        }

        public List<Rubro> FindByIdNomina(string _idNomina)
        {
            return rubros.Find(d => d.idNomina == _idNomina).ToList();
        }

        public List<Rubro> FindById(string _id)
        {
            return rubros.Find(d => d.id == _id).ToList();
        }

        public Rubro Create(Rubro rubro)
        {
            rubros.InsertOne(rubro);
            return rubro;
        }

        public void Update(String id, Rubro rubro)
        {
            rubros.ReplaceOne(rubro => rubro.id == id, rubro);
            
        }

        public void Delete(String id)
        {
            rubros.DeleteOne(d => d.id == id);
        }
    }
}
