using ApiPrueba.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ApiPrueba
{
    public class NominaService
    {
        private IMongoCollection<Nomina> nominas;
        private IMongoCollection<Rubro> rubros;
        private RubroService rubroService;

        public NominaService(IBarSettings settings)
        {
            rubroService = new RubroService(settings);
            var client = new MongoClient(settings.Server);
            var database = client.GetDatabase(settings.Database);

            nominas = database.GetCollection<Nomina>("Nomina");
            rubros = database.GetCollection<Rubro>("Rubros");
        }

        public List<Nomina> Get()
        {
            return nominas.Find(d => true).ToList();
        }

        public List<Nomina> FindById(string _id)
        {
            return nominas.Find(d => d.id == _id).ToList();
        }

        public List<Nomina> FindByIdEmpleado(string _idEmpleado)
        {
            return nominas.Find(d => d.idEmpleado == _idEmpleado).ToList();
        }
        public List<Nomina> FindByFechas(DateTime lowerDate, DateTime higherDate)
        {
            var filterBuilder = Builders<Nomina>.Filter;
            var filter = filterBuilder.Gte(x => x.fechaNomina, lowerDate) &
            filterBuilder.Lt(x => x.fechaNomina, higherDate);
            return nominas.Find(filter).ToList();

        }

        public IEnumerable<Rubro> Create(Nomina nomina, IEnumerable<Rubro> rubrosToInsert)
        //public Nomina Create(Nomina nomina)
        {
            nominas.InsertOne(nomina);
          foreach(Rubro r in rubrosToInsert)
            {
                r.idNomina = nomina.id;
                rubroService.Create(r);
            }
           
            
            return rubrosToInsert;
        }

        public void Update(String id, Nomina nomina)
        {
            nominas.ReplaceOne(nomina => nomina.id == id, nomina);
            
        }

        public void Delete(String id)
        {
            List<Rubro> rubrosList = rubroService.FindByIdNomina(id);
            foreach (Rubro r in rubrosList)
            {
                rubroService.Delete(r.id);
            }
            nominas.DeleteOne(d => d.id == id);
        }
    }
}
