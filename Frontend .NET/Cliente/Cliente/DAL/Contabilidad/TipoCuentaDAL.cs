using Cliente.Constants;
using Cliente.Models;
using Cliente.Models.Contabilidad;
using System;
using System.Data;
using System.Net.Http;

namespace Cliente.DAL.Contabilidad
{
    public class TipoCuentaDAL
    {
        public string chain = Constant.URL;
        public DataTable listar()
        {

            DataTable lista= null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("tipocuenta");
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
        public bool insertar(TipoCuentaModel obj)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var postTask = client.PostAsJsonAsync<TipoCuentaModel>("tipocuenta", obj);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode) return true;
                else return false;

            }
        }
        public bool actualizar(TipoCuentaModel activo)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var putTask = client.PutAsJsonAsync<TipoCuentaModel>("tipocuenta", activo);
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
                var deleteTask = client.DeleteAsync("tipocuenta/" + id);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode) return true;
                else return false;
            }

        }
        public TipoCuentaModel getById(String id)
        {
            TipoCuentaModel activo = new TipoCuentaModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("tipocuenta/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsAsync<TipoCuentaModel>();
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
        public DataTable getByIdDataTable(String id)
        {
            DataTable listaActivos = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("tipocuenta/" + id);
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
        public DataTable getByNombreDataTable(String nombre)
        {
            DataTable lista= null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("tipocuenta/getbynombre/" + nombre);
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