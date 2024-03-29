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
    public class ActividadDAL
    {
        public const string chain = EndPoint.javaEndPoint;

        public DataTable listarActividades()
        {

            DataTable listaActividades = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("actividades");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsStringAsync();
                    var actividades = (DataTable)JsonConvert.DeserializeObject<DataTable>(readJob.Result);
                    readJob.Wait();
                    listaActividades = actividades;

                }
                else
                {
                    listaActividades = null;
                }
                return listaActividades;
            }

        }
        public List<String> getAllResponsablesActividades()
        {

            List<String> listaResponsablesActividades = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("actividadesResponsables");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsStringAsync();
                    var actividades = (List<String>)JsonConvert.DeserializeObject<List<String>>(readJob.Result);
                    readJob.Wait();
                    listaResponsablesActividades = actividades;

                }
                else
                {
                    listaResponsablesActividades = null;
                }
                return listaResponsablesActividades;
            }

        }
        public ActividadModel getLastActividad()
        {
            ActividadModel actividad = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("actividadUltima");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsStringAsync();
                    var actividades = (ActividadModel)JsonConvert.DeserializeObject<ActividadModel>(readJob.Result);
                    readJob.Wait();
                    actividad = actividades;

                }
                else
                {
                    actividad = null;
                }
                return actividad;
            }
        }
        public bool insertarActividad(ActividadModel actividadModel)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var json = JsonConvert.SerializeObject(actividadModel, Formatting.Indented);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var postTask = client.PostAsync("actividad/crear", stringContent);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode) return true;
                else return false;

            }
        }
        public bool actualizarActividad(ActividadModel actividadModel)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var json = JsonConvert.SerializeObject(actividadModel, Formatting.Indented);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var putTask = client.PutAsync("actividad/actualizar/" + actividadModel.idactividad, stringContent);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode) return false;
                else return true;
            }
        }
        public bool eliminarActividad(String id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var deleteTask = client.DeleteAsync("actividad/borrar/" + id);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode) return false;
                else return true;
            }
        }

        public DataTable getActividadesByFecha(DateTime fecha)
        {
            DataTable lista = null;
            using (var client = new HttpClient())
            {
                System.Diagnostics.Debug.WriteLine("fecha " + fecha.ToString("dd-MM-yyyy"));
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("actividadesPorFecha/" + fecha.ToString("dd-MM-yyyy"));
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsStringAsync();
                    var actividades = (DataTable)JsonConvert.DeserializeObject<DataTable>(readJob.Result);
                    readJob.Wait();
                    lista = actividades;
                }
                else
                {
                    lista = null;
                }
                return lista;
            }
        }

        public DataTable getActividadesByResponsable(string responsable)
        {
            DataTable lista = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("actividadesPorResponsable/" + responsable);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsStringAsync();
                    var actividades = (DataTable)JsonConvert.DeserializeObject<DataTable>(readJob.Result);
                    readJob.Wait();
                    lista = actividades;
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