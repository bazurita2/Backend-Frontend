using Cliente.Constants;
using Cliente.Models;
using Cliente.Models.Contabilidad;
using System;
using System.Data;
using System.Net.Http;

namespace Cliente.DAL.Contabilidad
{
    public class CuentaDAL
    {
        public string chain = Constant.URL;
        public DataTable listar()
        {

            DataTable lista = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("cuenta");
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
        public bool insertar(CuentaModel obj)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var postTask = client.PostAsJsonAsync<CuentaModel>("cuenta", obj);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode) return true;
                else return false;

            }
        }
        public bool actualizar(CuentaModel obj)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var putTask = client.PutAsJsonAsync<CuentaModel>("cuenta", obj);
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
                var deleteTask = client.DeleteAsync("cuenta/" + id);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode) return true;
                else return false;
            }

        }
        public CuentaModel getById(String id)
        {
            CuentaModel obj = new CuentaModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("cuenta/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsAsync<CuentaModel>();
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
            DataTable lista= null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("cuenta/" + id);
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
        public DataTable getByNombreDataTable(String nombre)
        {
            DataTable lista = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("cuenta/getbynombre/" + nombre);
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