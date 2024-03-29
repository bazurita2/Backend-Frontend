using Cliente.Constants;
using Cliente.Models;
using Cliente.Models.Contabilidad;
using System;
using System.Data;
using System.Net.Http;


namespace Cliente.DAL.Contabilidad
{
    public class DetalleAsientoDAL
    {
        public string chain = Constant.URL;
        public DataTable listar()
        {

            DataTable lista = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("detalleasiento");
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
        public bool insertar(DetalleAsientoModel obj)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var postTask = client.PostAsJsonAsync<DetalleAsientoModel>("detalleasiento", obj);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode) return true;
                else return false;

            }
        }
        public bool actualizar(DetalleAsientoModel obj)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var putTask = client.PutAsJsonAsync<DetalleAsientoModel>("detalleasiento", obj);
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
                var deleteTask = client.DeleteAsync("detalleasiento/" + id);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode) return true;
                else return false;
            }

        }
        public bool eliminarPorCabecera(String id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var deleteTask = client.DeleteAsync("detalleasiento/deleteidcabecera/" + id);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode) return true;
                else return false;
            }

        }
        public DetalleAsientoModel getById(String id)
        {
            DetalleAsientoModel obj = new DetalleAsientoModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("detalleasiento/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsAsync<DetalleAsientoModel>();
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
                var responseTask = client.GetAsync("detalleasiento/" + id);
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
        public DataTable getByIdCabecera(String idasiento)
        {
            DataTable lista = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("detalleasiento/getbyidcabecera/" + idasiento);
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
        public DataTable getByFechaDataTable(DateTime fechainicio, DateTime fechafin)
        {
            DataTable lista = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("detalleasiento/getbyfecha/" + fechainicio.ToString("yyyy-MM-dd") + "/" + fechafin.ToString("yyyy-MM-dd"));
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