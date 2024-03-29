using ApiPrueba.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPrueba.Services
{
    public class UsuarioService
    {
        private IMongoCollection<Usuario> IMongoCollection;


        public UsuarioService(IBarSettings settings)
        {
            var client = new MongoClient(settings.Server);
            var database = client.GetDatabase(settings.Database);

            IMongoCollection = database.GetCollection<Usuario>("empleado");
        }

        public List<Usuario> GetAllUsuarios()
        {
            return IMongoCollection.Find(usuarios => true).ToList();
        }
    }
}
