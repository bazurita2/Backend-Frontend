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
    public class ActivoDAL
    {

        public const string chain = EndPoint.javaEndPoint;

        public DataTable listarActivos()
        {
            DataTable listaActivos = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("activos");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsStringAsync();
                    var activos = (DataTable)JsonConvert.DeserializeObject<DataTable>(readJob.Result);
                    readJob.Wait();
                    listaActivos = activos;
                }
                else
                {
                    listaActivos = null;
                }
                return listaActivos;
            }
        }

        public List<ActivoModel> getAllActivos()
        {

            List<ActivoModel> listaActivos = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("activos");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsStringAsync();
                    var activos = (List<ActivoModel>)JsonConvert.DeserializeObject<List<ActivoModel>>(readJob.Result);
                    readJob.Wait();
                    listaActivos = activos;
                }
                else
                {
                    listaActivos = null;
                }
                return listaActivos;
            }

        }
        public DataTable getActivoByNombreDataTable(String nombre)
        {
            DataTable listaActivos = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("activosPorNombre/"+nombre);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsStringAsync();
                    var activos = (DataTable)JsonConvert.DeserializeObject<DataTable>(readJob.Result);
                    readJob.Wait();
                    listaActivos = activos;
                }
                else
                {
                    listaActivos = null;
                }
                return listaActivos;
            }
        }

        public bool insertarActivo(ActivoModel activo)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var json = JsonConvert.SerializeObject(activo, Formatting.Indented);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var postTask = client.PostAsync("activo/crear", stringContent);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode) return false;
                else return true;
            }
        }

        public ActivoModel getActivoById(String id)
        {
            ActivoModel activoModel = new ActivoModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("activo/leer/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsStringAsync();
                    var activo = (ActivoModel)JsonConvert.DeserializeObject<ActivoModel>(readJob.Result);
                    readJob.Wait();
                    activoModel = activo;
                }
                else
                {
                    activoModel = null;
                }
                return activoModel;
            }
        }

        public bool actualizarActivo(ActivoModel activo)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var json = JsonConvert.SerializeObject(activo, Formatting.Indented);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var putTask = client.PutAsync("activo/actualizar/" + activo.idactivo, stringContent);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode) return false;
                else return true;
            }
        }

        public bool eliminarActivo(String id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var deleteTask = client.DeleteAsync("activo/borrar/" + id);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode) return false;
                else return true;
            }

        }

        public List<ActivoModel> listarNombresActivos()
        {
            List<ActivoModel> listaActivos = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("activosPorNombre");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsStringAsync();
                    var activos = (List<ActivoModel>)JsonConvert.DeserializeObject<List<ActivoModel>>(readJob.Result);
                    readJob.Wait();
                    listaActivos = activos;
                }
                else
                {
                    listaActivos = null;
                }
                return listaActivos;
            }
        }
    }
}