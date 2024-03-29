using Cliente.Constants;
using Cliente.Models.Mantenimiento;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;

namespace Cliente.DAL.Mantenimiento
{
    public class CatalogoActividadDAL
    {
        public string chain = Constant.URL;
        public DataTable listarCatalogoActividades()
        {

            DataTable listaCatalogosActividades = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("catalogoactividad");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsAsync<DataTable>();
                    readJob.Wait();
                    listaCatalogosActividades = readJob.Result;

                }
                else
                {
                    listaCatalogosActividades = null;
                }
                return listaCatalogosActividades;
            }

        }

        public List<CatalogoActividadModel> getAllCatalogoActividades()
        {

            List<CatalogoActividadModel> listaCatalogosActividades = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("catalogoactividad");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsAsync<List<CatalogoActividadModel>>();
                    readJob.Wait();
                    listaCatalogosActividades = readJob.Result;

                }
                else
                {
                    listaCatalogosActividades = null;
                }
                return listaCatalogosActividades;
            }

        }
        public bool insertarCatalogoActividad(CatalogoActividadModel catalogoActividad)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var postTask = client.PostAsJsonAsync<CatalogoActividadModel>("catalogoactividad", catalogoActividad);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode) return true;
                else return false;

            }
        }
        public bool actualizarCatalogoActividad(CatalogoActividadModel catalogoActividad)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var putTask = client.PutAsJsonAsync<CatalogoActividadModel>("catalogoactividad", catalogoActividad);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode) return true;
                else return false;

            }
        }
        public bool eliminarCatalogoActividad(String id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var deleteTask = client.DeleteAsync("catalogoactividad/" + id);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode) return true;
                else return false;
            }

        }
        public CatalogoActividadModel getCatalogoActividadById(String id)
        {
            CatalogoActividadModel catalogoActividad = new CatalogoActividadModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("catalogoactividad/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsAsync<CatalogoActividadModel>();
                    readJob.Wait();
                    catalogoActividad = readJob.Result;
                }
                else
                {
                    catalogoActividad = null;
                }
                return catalogoActividad;
            }
        }
        public DataTable getCatalogoActividadByIdDataTable(String id)
        {
            DataTable listaCatalogosActividades = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("catalogoactividad/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsAsync<DataTable>();
                    readJob.Wait();
                    listaCatalogosActividades = readJob.Result;
                }
                else
                {
                    listaCatalogosActividades = null;
                }
                return listaCatalogosActividades;
            }
        }
        public DataTable getCatalogoActividadByNombreDataTable(String nombre)
        {
            DataTable listaCatalogosActividades = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("catalogoactividad/getbynombre/" + nombre);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsAsync<DataTable>();
                    readJob.Wait();
                    listaCatalogosActividades = readJob.Result;
                }
                else
                {
                    listaCatalogosActividades = null;
                }
                return listaCatalogosActividades;
            }
        }
    }
}