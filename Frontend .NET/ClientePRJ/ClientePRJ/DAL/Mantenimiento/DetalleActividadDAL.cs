using ClientePRJ.Models.Mantenimiento;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;

namespace ClientePRJ.DAL.Mantenimiento
{
    public class DetalleActividadDAL
    {
        public const string chain = EndPoint.javaEndPoint;

        public DataTable getDetalleActividadByActivoDataTable(String id)
        {
            DataTable listaDetalleActividad = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("detalleActividad/leerPorActivo/"+id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsStringAsync();
                    var detalleActividades = (DataTable)JsonConvert.DeserializeObject<DataTable>(readJob.Result);
                    readJob.Wait();
                    listaDetalleActividad = detalleActividades;
                }
                else
                {
                    listaDetalleActividad = null;
                }
                return listaDetalleActividad;
            }
        }
        public List<DetalleActividadModel> getAllDetallesActividadesByActividadId(String id)
        {
            List<DetalleActividadModel> listaDetallesActividades = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("detalleActividad/leerPorActividad/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsStringAsync();
                    var detalleActividades = (List<DetalleActividadModel>)JsonConvert.DeserializeObject<List<DetalleActividadModel>>(readJob.Result);
                    readJob.Wait();
                    listaDetallesActividades = detalleActividades;

                }
                else
                {
                    listaDetallesActividades = null;
                }
                return listaDetallesActividades;
            }
        }

        public bool insertarDetalleActividad(DetalleActividadModel detalleActividadModel)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var json = JsonConvert.SerializeObject(detalleActividadModel, Formatting.Indented);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var postTask = client.PostAsync("detalleActividad/crear", stringContent);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode) return true;
                else return false;

            }
        }

        public bool deleteDetalleActividadPorCabecera(String id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var deleteTask = client.DeleteAsync("detalleActividadesPorActividad/borrar/" + id);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode) return false;
                else return true;
            }
        }
    }
}