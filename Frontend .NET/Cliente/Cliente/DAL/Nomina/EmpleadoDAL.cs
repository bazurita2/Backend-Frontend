
using Cliente.Constants;
using clienteG2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Cliente.DAL.Nomina
{
    public class EmpleadoDAL
    {
        public string chain = Constant.URL;
        public DataTable listarEmpleado()
        {

            DataTable listaEmpleados = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("Empleado");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsAsync<DataTable>();
                    readJob.Wait();
                    listaEmpleados = readJob.Result;

                }
                else
                {
                    listaEmpleados = null;
                    //ModelState.AddModelError(string.Empty, "Ocurrio un error, hable con el admin");
                }
                return listaEmpleados;
            }

        }
        public bool insertarEmpleado(EmpleadoModel empleado)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var postTask = client.PostAsJsonAsync<EmpleadoModel>("Empleado", empleado);
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
        public bool actualizarEmpleado(EmpleadoModel empleado)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var putTask = client.PutAsJsonAsync<EmpleadoModel>("Empleado", empleado);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;

            }
        }
        public bool eliminarEmpleado(String id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var deleteTask = client.DeleteAsync("Empleado/" + id);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode) return true;
                else return false;
            }

        }
        public EmpleadoModel getEmpleadoById(String id)
        {
            EmpleadoModel empleado = new EmpleadoModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("Empleado/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsAsync<EmpleadoModel>();
                    readJob.Wait();
                    empleado = readJob.Result;
                }
                else
                {
                    empleado = null;
                    // ModelState.AddModelError(string.Empty, "Ocurrio un error, hable con el admin");
                }
                return empleado;
            }
        }
        public DataTable getEmpleadoByIdDataTable(String id)
        {
            DataTable listaEmpleados = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("Empleado/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsAsync<DataTable>();
                    readJob.Wait();
                    listaEmpleados = readJob.Result;
                }
                else
                {
                    listaEmpleados = null;
                    // ModelState.AddModelError(string.Empty, "Ocurrio un error, hable con el admin");
                }
                return listaEmpleados;
            }
        }
        public DataTable getEmpleadoByNombreDataTable(String nombre)
        {
            DataTable listaEmpleados = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("Empleado/getbyNombreApellido/" + nombre);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsAsync<DataTable>();
                    readJob.Wait();
                    listaEmpleados = readJob.Result;
                }
                else
                {
                    listaEmpleados = null;
                    // ModelState.AddModelError(string.Empty, "Ocurrio un error, hable con el admin");
                }
                return listaEmpleados;
            }
        }

        public List<EmpleadoModel> getAllEmpleados()
        {

            List<EmpleadoModel> listaEmpleados = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("Empleado");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsAsync<List<EmpleadoModel>>();
                    readJob.Wait();
                    listaEmpleados = readJob.Result;

                }
                else
                {
                    listaEmpleados = null;
                    //ModelState.AddModelError(string.Empty, "Ocurrio un error, hable con el admin");
                }
                return listaEmpleados;
            }

        }
    }
}