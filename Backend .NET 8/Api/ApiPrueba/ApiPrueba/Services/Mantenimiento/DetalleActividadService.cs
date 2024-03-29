using ApiPrueba.Model;
using ApiPrueba.Model.Mantenimiento;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiPrueba.Services.Mantenimiento
{
    public class DetalleActividadService
    {
        private IMongoCollection<DetalleActividad> IMongoCollection;
        MongoClient client;
        IMongoDatabase database;

        public DetalleActividadService(IBarSettings settings)
        {
            client = new MongoClient(settings.Server);
            database = client.GetDatabase(settings.Database);

            IMongoCollection = database.GetCollection<DetalleActividad>("detalleactividad");
        }

        public List<DetalleActividad> GetAllDetallesActividadesByActivoId(String idactivo)
        {
            return IMongoCollection.Find(detalleActividad => detalleActividad.idactivo == idactivo).ToList();
        }

        public List<DetalleActividad> GetAllDetallesActividadesByActividadId(String idactividad)
        {
            return IMongoCollection.Find(detalleActividad => detalleActividad.idactividad == idactividad).ToList();
        }

        public List<int> GetMaxColFilDetalleActividad()
        {
            int maxNumCol = 0;
            int maxNumFil = 0;
            List<int> listaData = new List<int>();
            maxNumFil = IMongoCollection.AsQueryable()
                                        .Select(x => x.idactivo)
                                        .Distinct()
                                        .Count();
            maxNumCol = IMongoCollection.AsQueryable()
                                        .GroupBy(x => x.idactivo)
                                        .Select(x => new { Activetype = x.Key, Count = x.Count() })
                                        .OrderByDescending(x => x.Count)
                                        .First().Count;
            listaData.Add(maxNumCol);
            listaData.Add(maxNumFil);
            return listaData;
        }

        public List<Activo> GetFilaActivo()
        {
            List<Activo> listaData = new List<Activo>();
            Activo activo = new Activo();
            IMongoCollection<Activo> IMongoCollection2 = database.GetCollection<Activo>("activo");
            var query = from activoItem in IMongoCollection2.AsQueryable()
                        join detalleItem in IMongoCollection.AsQueryable()
                        on activoItem.idactivo equals detalleItem.idactivo into joinableItems
                        select new
                        {
                            idactivo = activoItem.idactivo,
                            nombreactivo = activoItem.nombreactivo,
                            tipoactivo = activoItem.tipoactivo,
                            estadoactivo = activoItem.estadoactivo,
                            precioactivo = activoItem.precioactivo,
                            fechacompraactivo = activoItem.fechacompraactivo
                        };

            var array = query.ToList();
            foreach (var item in array)
            {
                activo = new Activo();
                activo.idactivo = item.idactivo;
                activo.nombreactivo = item.nombreactivo;
                activo.tipoactivo = item.tipoactivo;
                activo.estadoactivo = item.estadoactivo;
                activo.precioactivo = item.precioactivo;
                activo.fechacompraactivo = item.fechacompraactivo;
                listaData.Add(activo);
            }
            return listaData;
        }

        public List<string> GetColumnaDetalleaActividad(string idactivo)
        {
            List<string> listaData = new List<string>();
            IMongoCollection<Activo> IMongoCollection2 = database.GetCollection<Activo>("activo");

            var query = from detalleItem in IMongoCollection.AsQueryable()
                        join activoItem in IMongoCollection2.AsQueryable()
                        on detalleItem.idactivo equals activoItem.idactivo into joinable
                        where detalleItem.idactivo == idactivo
                        select new { valordetalleactividad = detalleItem.valordetalleactividad };

            var array = query.ToList();
            foreach (var item in array)
            {
                listaData.Add(item.valordetalleactividad.ToString());
            }
            return listaData;
        }

        public void AddDetalleActividad(DetalleActividad detalleActividad)
        {
            IMongoCollection.InsertOne(detalleActividad);
        }

        public void UpdateDetalleActividad(String id, DetalleActividad detalleActividad)
        {
            IMongoCollection.ReplaceOne(d => d.iddetalleactividad == id, detalleActividad);
        }

        public void DeleteDetalleActividad(String id)
        {
            IMongoCollection.DeleteOne(d => d.iddetalleactividad == id);
        }

        public void DeleteDetalleActividadPorCabecera(String idcabecera)
        {
            IMongoCollection.DeleteMany(d => d.idactividad == idcabecera);
        }

    }
}
