using Cliente.Constants;
using Cliente.Models.Mantenimiento;
using System;
using System.Data;
using System.Net.Http;

namespace Cliente.DAL.Mantenimiento
{
    public class ActividadDAL
    {
        public string chain = Constant.URL;

        public DataTable listarActividades()
        {

            DataTable listaActividades = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("actividad");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsAsync<DataTable>();
                    readJob.Wait();
                    listaActividades = readJob.Result;

                }
                else
                {
                    listaActividades = null;
                }
                return listaActividades;
            }

        }

        public DataTable getActividadesByFecha(DateTime fecha)
        {
            DataTable lista = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("actividad/getbyfecha/" + fecha.ToString("yyyy-MM-dd"));
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

        public bool insertarActividad(ActividadModel actividadModel)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var postTask = client.PostAsJsonAsync<ActividadModel>("actividad", actividadModel);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode) return true;
                else return false;

            }
        }
        public ActividadModel getLastActividad()
        {
            ActividadModel a = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("actividad/getlastactividad");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsAsync<ActividadModel>();
                    readJob.Wait();
                    a = readJob.Result;
                }
                else
                {
                    a = null;
                }
                return a;
            }
        }

        public bool actualizarActividad(ActividadModel actividadModel)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var putTask = client.PutAsJsonAsync<ActividadModel>("actividad", actividadModel);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode) return true;
                else return false;

            }
        }
        public bool eliminarActividad(String id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var deleteTask = client.DeleteAsync("actividad/" + id);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode) return true;
                else return false;
            }

        }
    }
}