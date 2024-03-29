using Cliente.Models;
using Cliente.Constants;
using Cliente.Models.Contabilidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;


namespace Cliente.DAL.Contabilidad
{
    public class AsientoDAL
    {
        public  string chain = Constant.URL;
        public DataTable listar()
        {

            DataTable lista = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("asiento");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsAsync<DataTable>();
                    readJob.Wait();
                    lista = readJob.Result;

                }
                else
                {
                    lista = null;
                }
                return lista;
            }

        }
        public List<AsientoModel> listarToList()
        {

            List<AsientoModel> lista = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("asiento");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsAsync<List<AsientoModel>>();
                    readJob.Wait();
                    lista = readJob.Result;

                }
                else
                {
                    lista = null;
                }
                return lista;
            }

        }
        public bool insertar(AsientoModel obj)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var postTask = client.PostAsJsonAsync<AsientoModel>("asiento", obj);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode) return true;
                else return false;

            }
        }
        public bool actualizar(AsientoModel obj)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var putTask = client.PutAsJsonAsync<AsientoModel>("asiento", obj);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode) return true;
                else return false;

            }
        }
        public bool eliminar(String id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var deleteTask = client.DeleteAsync("asiento/" + id);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode) return true;
                else return false;
            }

        }
        public List<AsientoModel> getById(String id)
        {
            List<AsientoModel> obj = new List<AsientoModel>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("asiento/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsAsync<List<AsientoModel>>();
                    readJob.Wait();
                    obj = readJob.Result;
                }
                else
                {
                    obj = null;
                }
                return obj;
            }
        }

        public DataTable getByIdDataTable(String id)
        {
            DataTable lista = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("asiento/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsAsync<DataTable>();
                    readJob.Wait();
                    lista = readJob.Result;
                }
                else
                {
                    lista = null;
                }
                return lista;
            }
        }
        public DataTable getByFechaDataTable(DateTime fechainicio,DateTime fechafin)
        {
            DataTable lista = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("asiento/getbyfecha/" + fechainicio.ToString("yyyy-MM-dd")+"/"+ fechafin.ToString("yyyy-MM-dd"));
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsAsync<DataTable>();
                    readJob.Wait();
                    lista = readJob.Result;
                }
                else
                {
                    lista = null;
                }
                return lista;
            }
        }
    }
}