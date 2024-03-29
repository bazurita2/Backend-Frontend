
using Cliente.Constants;
using Cliente.Models.Nomina;
using clienteG2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Cliente.DAL.Nomina
{
    public class NominaDAL
    {
        public string chain = Constant.URL;
        public DataTable listarNomina()
        {

            DataTable listaNominas = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("Nomina");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsAsync<DataTable>();
                    readJob.Wait();
                    listaNominas = readJob.Result;

                }
                else
                {
                    listaNominas = null;
                    //ModelState.AddModelError(string.Empty, "Ocurrio un error, hable con el admin");
                }
                return listaNominas;
            }

        }
        public bool insertarNomina(NominaRubros nominaRubros)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var postTask = client.PostAsJsonAsync<NominaRubros>("Nomina", nominaRubros);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    //ModelState.AddModelError(string.Empty, "Ocurrio un error, hable con el admin");
                    return false;
                }

            }
        }
        public bool actualizarNomina(NominaModel nomina)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var putTask = client.PutAsJsonAsync<NominaModel>("Nomina", nomina);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;

            }
        }
        public bool eliminarNomina(String id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var deleteTask = client.DeleteAsync("Nomina/" + id);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode) return true;
                else return false;
            }

        }
        public NominaModel getNominaById(String id)
        {
            NominaModel nomina = new NominaModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("Nomina/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsAsync<NominaModel>();
                    readJob.Wait();
                    nomina = readJob.Result;
                }
                else
                {
                    nomina = null;
                    // ModelState.AddModelError(string.Empty, "Ocurrio un error, hable con el admin");
                }
                return nomina;
            }
        }
        public DataTable getNominaByIdDataTable(String id)
        {
            DataTable listaNominas = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("Nomina/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsAsync<DataTable>();
                    readJob.Wait();
                    listaNominas = readJob.Result;
                }
                else
                {
                    listaNominas = null;
                    // ModelState.AddModelError(string.Empty, "Ocurrio un error, hable con el admin");
                }
                return listaNominas;
            }
        }
        public DataTable listarNominasEmpleado(String idEmpleado)
        {
            DataTable listaNominas = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("Nomina/FindByIdEmpleado/" + idEmpleado);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsAsync<DataTable>();
                    readJob.Wait();
                    listaNominas = readJob.Result;
                }
                else
                {
                    listaNominas = null;
                    // ModelState.AddModelError(string.Empty, "Ocurrio un error, hable con el admin");
                }
                return listaNominas;
            }
        }

        public DataTable listarNominasByRangoFechas(DateTime lowerDate, DateTime higherDate)
        {
            DataTable listaNominas = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("Nomina/FindByFechas/"+lowerDate+";"+higherDate);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsAsync<DataTable>();
                    readJob.Wait();
                    listaNominas = readJob.Result;
                }
                else
                {
                    listaNominas = null;
                    // ModelState.AddModelError(string.Empty, "Ocurrio un error, hable con el admin");
                }
                return listaNominas;
            }
        }

        public DataTable listarNominaFiltradaPorEmpleado(string nombreApellido)
        {
            DataTable listaNominas = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("Nomina/FindByNombreEmpleado/" + nombreApellido);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsAsync<DataTable>();
                    readJob.Wait();
                    listaNominas = readJob.Result;
                }
                else
                {
                    listaNominas = null;
                    // ModelState.AddModelError(string.Empty, "Ocurrio un error, hable con el admin");
                }
                return listaNominas;
            }
        }
    }
}