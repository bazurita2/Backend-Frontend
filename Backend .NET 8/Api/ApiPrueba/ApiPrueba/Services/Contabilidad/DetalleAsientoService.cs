using ApiPrueba.Model;
using ApiPrueba.Model.Contabilidad;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPrueba.Services.Contabilidad
{
    public class DetalleAsientoService
    {
        private IMongoCollection<DetalleAsiento> IMongoCollection;
        MongoClient client;
        IMongoDatabase database;
        public DetalleAsientoService(IBarSettings settings)
        {
            var client = new MongoClient(settings.Server);
            var database = client.GetDatabase(settings.Database);

            IMongoCollection = database.GetCollection<DetalleAsiento>("detalleasiento");
        }

        public List<DetalleAsiento> GetAllDetalleAsiento()
        {
            
            return IMongoCollection.Find(detalleasiento => true).ToList();
        }

        public List<DetalleAsiento> GetDetalleAsientoById(String id)
        {
            return IMongoCollection.Find(detalleasiento => detalleasiento.iddetalle== id).ToList();
        }
        public List<DetalleAsiento> GetDetalleAsientoByIdCabecera(String id)
        {
            return IMongoCollection.Find(detalleasiento => detalleasiento.idasiento == id).ToList();
        }

        public void AddDetalleAsiento(DetalleAsiento detalleasiento)
        {

            IMongoCollection.InsertOne(detalleasiento);
        }

        public void UpdateDetalleAsiento(String id, DetalleAsiento detalleasiento)
        {
            IMongoCollection.ReplaceOne(detalleasiento => detalleasiento.iddetalle== id, detalleasiento);
        }

        public void DeleteDetalleAsiento(String id)
        {
            IMongoCollection.DeleteOne(detalleasiento => detalleasiento.iddetalle== id);
        }
        public void DeleteDetalleAsientoPorCabecera(String idcabecera)
        {
            IMongoCollection.DeleteMany(detalleasiento => detalleasiento.idasiento == idcabecera);
        }
        //public List<DetalleAsiento> GetDetalleByFecha(DateTime fechainicio, DateTime fechafin)
        //{
        //    List<DetalleAsiento> listaData = new List<DetalleAsiento>();
        //    IMongoCollection<Asiento> IMongoCollection2 = database.GetCollection<Asiento>("asiento");

        //    var query = from detalleItem in IMongoCollection.AsQueryable()
        //                join asientoItem in IMongoCollection2.AsQueryable()
        //                on detalleItem.idasiento equals asientoItem.idasiento into joinable
        //                where asientoItem.fechaasiento== fechainicio
        //                select new { valordetalleactividad = detalleItem.valordetalleactividad };

        //    var array = query.ToList();
        //    foreach (var item in array)
        //    {
        //        listaData.Add(item.valordetalleactividad.ToString());
        //    }
        //    return listaData;


        //    return IMongoCollection.Find(asiento => asiento.fechaasiento <=
        //    fechafin.ToUniversalTime() && asiento.fechaasiento >=
        //    fechainicio.ToUniversalTime()).ToList();
        //}

    }
}
