using ApiPrueba.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPrueba
{
    public class CatalogoService
    {
        private IMongoCollection<Catalogo> catalogos;

        public CatalogoService(IBarSettings settings)
        {
            var client = new MongoClient(settings.Server);
            var database = client.GetDatabase(settings.Database);

            catalogos = database.GetCollection<Catalogo>("Catalogo");
        }

        public List<Catalogo> Get()
        {
            return catalogos.Find(d => true).ToList();
        }

        public List<Catalogo> FindById(string _id)
        {
            return catalogos.Find(d => d.id == _id).ToList();
        }

        public List<Catalogo> FindByDesc(string _id)
        {
            return catalogos.Find(d => d.descripcionCatalogo.ToLower().Contains(_id.ToLower())).ToList();
        }

        public Catalogo Create(Catalogo catalogo)
        {
            catalogos.InsertOne(catalogo);
            return catalogo;
        }

        public void Update(String id, Catalogo catalogo)
        {
            catalogos.ReplaceOne(catalogo => catalogo.id == id, catalogo);
            
        }

        public void Delete(String id)
        {
            catalogos.DeleteOne(d => d.id == id);
        }
    }
}
