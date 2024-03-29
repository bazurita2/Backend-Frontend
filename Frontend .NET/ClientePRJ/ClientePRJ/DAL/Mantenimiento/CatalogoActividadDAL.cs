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
    public class CatalogoActividadDAL
    {
        public const string chain = EndPoint.javaEndPoint;

        public DataTable listarCatalogoActividades()
        {
            DataTable listaCatalogoActividades = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("catalogoActividades");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsStringAsync();
                    var activos = (DataTable)JsonConvert.DeserializeObject<DataTable>(readJob.Result);
                    readJob.Wait();
                    listaCatalogoActividades = activos;
                }
                else
                {
                    listaCatalogoActividades = null;
                }
                return listaCatalogoActividades;
            }
        }

        public List<CatalogoActividadModel> getAllCatalogoActividades()
        {

            List<CatalogoActividadModel> listaCatalogoActividades = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("catalogoActividades");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsStringAsync();
                    var activos = (List<CatalogoActividadModel>)JsonConvert.DeserializeObject<List<CatalogoActividadModel>>(readJob.Result);
                    readJob.Wait();
                    listaCatalogoActividades = activos;
                }
                else
                {
                    listaCatalogoActividades = null;
                }
                return listaCatalogoActividades;
            }

        }

        public DataTable getCatalogoActividadByNombreDataTable(String nombre)
        {
            DataTable listaCatalogoActividades = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("catalogoActividadesPorNombre/" + nombre);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsStringAsync();
                    var activos = (DataTable)JsonConvert.DeserializeObject<DataTable>(readJob.Result);
                    readJob.Wait();
                    listaCatalogoActividades = activos;
                }
                else
                {
                    listaCatalogoActividades = null;
                }
                return listaCatalogoActividades;
            }
        }

        public bool insertarCatalogoActividad(CatalogoActividadModel catalogoActividad)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var json = JsonConvert.SerializeObject(catalogoActividad, Formatting.Indented);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var postTask = client.PostAsync("catalogoActividad/crear", stringContent);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode) return false;
                else return true;
            }
        }

        public CatalogoActividadModel getCatalogoActividadById(String id)
        {
            CatalogoActividadModel catalogoActividadModel = new CatalogoActividadModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("catalogoActividad/leer/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsStringAsync();
                    var catalogoActividad = (CatalogoActividadModel)JsonConvert.DeserializeObject<CatalogoActividadModel>(readJob.Result);
                    readJob.Wait();
                    catalogoActividadModel = catalogoActividad;
                }
                else
                {
                    catalogoActividadModel = null;
                }
                return catalogoActividadModel;
            }
        }

        public bool actualizarCatalogoActividad(CatalogoActividadModel catalogoActividad)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var json = JsonConvert.SerializeObject(catalogoActividad, Formatting.Indented);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var putTask = client.PutAsync("catalogoActividad/actualizar/" + catalogoActividad.idcatactividad, stringContent);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode) return false;
                else return true;
            }
        }

        public bool eliminarCatalogoActividad(String id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var deleteTask = client.DeleteAsync("catalogoActividad/borrar/" + id);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode) return false;
                else return true;
            }

        }
    }
}