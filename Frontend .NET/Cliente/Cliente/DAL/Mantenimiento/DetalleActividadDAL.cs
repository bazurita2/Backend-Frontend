using Cliente.Constants;
using Cliente.Models;
using Cliente.Models.Mantenimiento;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;

namespace Cliente.DAL.Mantenimiento
{
    public class DetalleActividadDAL
    {
        public string chain = Constant.URL;
        public DataTable getDetalleActividadByActivoDataTable(String id)
        {
            DataTable listaDetallesActividades = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("detalleactividad/getbyactivoid/"+id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsAsync<DataTable>();
                    readJob.Wait();
                    listaDetallesActividades = readJob.Result;

                }
                else
                {
                    listaDetallesActividades = null;
                }
                return listaDetallesActividades;
            }
        }

        public List<DetalleActividadModel> getAllDetallesActividadesByActividadId(String id)
        {
            List<DetalleActividadModel> listaDetallesActividades = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("detalleactividad/getbyactividadid/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsAsync<List<DetalleActividadModel>>();
                    readJob.Wait();
                    listaDetallesActividades = readJob.Result;

                }
                else
                {
                    listaDetallesActividades = null;
                }
                return listaDetallesActividades;
            }
        }

        public List<int> getMaxColFilDetalleActividad()
        {
            List<int> dimensionesTablaGastos = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("detalleactividad/getmaxcolfil");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsAsync<List<int>>();
                    readJob.Wait();
                    dimensionesTablaGastos = readJob.Result;

                }
                else
                {
                    dimensionesTablaGastos = null;
                }
                return dimensionesTablaGastos;
            }
        }

        public List<ActivoModel> getFilaActivo()
        {
            List<ActivoModel> listaActivos = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("detalleactividad/getfilaactivo");
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
        public List<string> getColumnaDetalleaActividad(String id)
        {
            List<string> listaDetalle = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("detalleactividad/getcolumnadetalleaactividad/"+id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsAsync<List<string>>();
                    readJob.Wait();
                    listaDetalle = readJob.Result;

                }
                else
                {
                    listaDetalle = null;
                }
                return listaDetalle;
            }
        }

        public bool insertarDetalleActividad(DetalleActividadModel detalleActividadModel)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var postTask = client.PostAsJsonAsync<DetalleActividadModel>("detalleactividad", detalleActividadModel);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode) return true;
                else return false;

            }
        }
        public bool actualizarDetalleActividad(DetalleActividadModel detalleActividadModel)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var putTask = client.PutAsJsonAsync<DetalleActividadModel>("detalleactividad", detalleActividadModel);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode) return true;
                else return false;

            }
        }
        public bool eliminarDetalleActividad(String id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var deleteTask = client.DeleteAsync("detalleactividad/" + id);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode) return true;
                else return false;
            }

        }

        public bool deleteDetalleActividadPorCabecera(String id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var deleteTask = client.DeleteAsync("detalleactividad/deleteidcabecera/" + id);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode) return true;
                else return false;
            }

        }


    }
}