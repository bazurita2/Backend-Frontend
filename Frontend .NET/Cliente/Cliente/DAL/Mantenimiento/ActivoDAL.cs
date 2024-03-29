using Cliente.Constants;
using Cliente.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;

namespace Cliente.DAL
{
    public class ActivoDAL
    {
        public string chain = Constant.URL;
        public DataTable listarActivo()
        {

            DataTable listaActivos = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("activo");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsAsync<DataTable>();
                    readJob.Wait();
                    listaActivos = readJob.Result;

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
                var responseTask = client.GetAsync("activo");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsAsync<List<ActivoModel>>();
                    readJob.Wait();
                    listaActivos = readJob.Result;

                }
                else
                {
                    listaActivos = null;
                }
                return listaActivos;
            }

        }
        public IEnumerable<ActivoModel> listarNombresActivos()
        {
            IEnumerable<ActivoModel> listaActivos = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("activo");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsAsync<IList<ActivoModel>>();
                    readJob.Wait();
                    listaActivos = readJob.Result;
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
                var postTask = client.PostAsJsonAsync<ActivoModel>("activo", activo);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode) return true;
                else return false;

            }
        }
        public bool actualizarActivo(ActivoModel activo)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var putTask = client.PutAsJsonAsync<ActivoModel>("activo", activo);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode) return true;
                else return false;

            }
        }
        public bool eliminarActivo(String id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var deleteTask = client.DeleteAsync("activo/" + id);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode) return true;
                else return false;
            }

        }
        public ActivoModel getActivoById(String id)
        {
            ActivoModel activo = new ActivoModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("activo/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsAsync<ActivoModel>();
                    readJob.Wait();
                    activo = readJob.Result;
                }
                else
                {
                    activo = null;
                }
                return activo;
            }
        }
        public DataTable getActivoByIdDataTable(String id)
        {
            DataTable listaActivos = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("activo/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsAsync<DataTable>();
                    readJob.Wait();
                    listaActivos = readJob.Result;
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
                var responseTask = client.GetAsync("activo/getbynombre/" + nombre);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsAsync<DataTable>();
                    readJob.Wait();
                    listaActivos = readJob.Result;
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