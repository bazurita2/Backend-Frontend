using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using Antlr.Runtime.Misc;
using ClientePRJ.Models.Biblioteca;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ClientePRJ.DAL.Biblioteca
{
    public class PrestamoDAL
    {
        //public const string chain = EndPoint.pythonEndPoint;
        public const string chain = EndPoint.pythonEndPoint;

        public DataTable listarPrestamo()
        {

            DataTable listaPrestamo = null;

            using (var client = new HttpClient())
            {


                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("prestamo");
                try
                {
                    responseTask.Wait();
                }
                catch
                {
                    return null;
                }

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsStringAsync();
                    var autores = (DataTable)JsonConvert.DeserializeObject<DataTable>(readJob.Result);

                    foreach (var item in autores.Rows)
                    {
                        Console.WriteLine(item);
                    }

                    readJob.Wait();
                    listaPrestamo = autores;

                }
                else
                {
                    listaPrestamo = null;
                    //ModelState.AddModelError(string.Empty, "Ocurrio un error, hable con el admin");
                }
                return listaPrestamo;
            }

        }

        public DataTable detallesTotal()
        {

            DataTable listaPrestamo = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("detallesTotal");
                try
                {
                    responseTask.Wait();
                }
                catch
                {
                    return null;
                }
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsStringAsync();
                    var autores = (DataTable)JsonConvert.DeserializeObject<DataTable>(readJob.Result);

                    foreach (var item in autores.Rows)
                    {
                        Console.WriteLine(item);
                    }

                    readJob.Wait();
                    listaPrestamo = autores;

                }
                else
                {
                    listaPrestamo = null;
                    //ModelState.AddModelError(string.Empty, "Ocurrio un error, hable con el admin");
                }
                return listaPrestamo;
            }

        }






        public PrestamoModel getPrestamoById(string id)
        {

            DataTable listaPrestamo = null;
            PrestamoModel pres = new PrestamoModel();

            using (var client = new HttpClient())
            {


                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("prestamo/" + id);
                try
                {
                    responseTask.Wait();
                }
                catch
                {
                    return null;
                }

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsStringAsync();
                    var p = (PrestamoModel)JsonConvert.DeserializeObject<PrestamoModel>(readJob.Result);


                    pres = p;
                    readJob.Wait();
                    //listaPrestamo = autores;

                }
                else
                {
                    listaPrestamo = null;
                    //ModelState.AddModelError(string.Empty, "Ocurrio un error, hable con el admin");
                }
                return pres;
            }

        }

        public bool insertarPrestamo(PrestamoModel activo)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var json = JsonConvert.SerializeObject(activo, Formatting.Indented);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                var postTask = client.PostAsync("prestamo" , stringContent);
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

        public bool actualizarPrestamo(PrestamoModel autor)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var json = JsonConvert.SerializeObject(autor, Formatting.Indented);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var putTask = client.PutAsync("prestamo/" + autor.idPrestamo, stringContent);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;

            }
        }

        public bool eliminarPrestamo(String id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var deleteTask = client.DeleteAsync("prestamo/" + id);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode) return true;
                else return false;
            }

        }

        public DataTable getPrestamoByCoincidence(String coincidence)
        {
            DataTable listaPrestamo = null;

            using (var client = new HttpClient())
            {


                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("autoresByCoincidence/" + coincidence);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsStringAsync();
                    var autores = (DataTable)JsonConvert.DeserializeObject<DataTable>(readJob.Result);

                    foreach (var item in autores.Rows)
                    {
                        Console.WriteLine(item);
                    }

                    readJob.Wait();
                    listaPrestamo = autores;

                }
                else
                {
                    listaPrestamo = null;
                    //ModelState.AddModelError(string.Empty, "Ocurrio un error, hable con el admin");
                }
                return listaPrestamo;
            }
        }

        public DataTable getLibrosPorDia(string inicio, string final)
        {
            DataTable listaPrestamo = null;

            using (var client = new HttpClient())
            {


                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("cantidadLibroPorDia/"+inicio+"/"+final);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsStringAsync();
                    var autores = (DataTable)JsonConvert.DeserializeObject<DataTable>(readJob.Result);

                    foreach (var item in autores.Rows)
                    {
                        Console.WriteLine(item);
                    }

                    readJob.Wait();
                    listaPrestamo = autores;

                }
                else
                {
                    listaPrestamo = null;
                    //ModelState.AddModelError(string.Empty, "Ocurrio un error, hable con el admin");
                }
                return listaPrestamo;
            }
        }

        public DataTable getDetallesDePrestamo(string idPrestamo)
        {

            DataTable listaPrestamo = null;

            using (var client = new HttpClient())
            {


                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("detallesDePrestamo/" + idPrestamo);
                try
                {
                    responseTask.Wait();
                }
                catch
                {
                    return null;
                }

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsStringAsync();
                    var autores = (DataTable)JsonConvert.DeserializeObject<DataTable>(readJob.Result);

                    foreach (var item in autores.Rows)
                    {
                        Console.WriteLine(item);
                    }

                    readJob.Wait();
                    listaPrestamo = autores;

                }
                else
                {
                    listaPrestamo = null;
                    //ModelState.AddModelError(string.Empty, "Ocurrio un error, hable con el admin");
                }
                return listaPrestamo;
            }

        }

        //PrestamosByCoincidence
        public DataTable PrestamosByCoincidence(String coincidence)
        {
            DataTable listaAutores = null;

            using (var client = new HttpClient())
            {


                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("prestamosByCoincidence/" + coincidence);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsStringAsync();
                    var autores = (DataTable)JsonConvert.DeserializeObject<DataTable>(readJob.Result);

                    foreach (var item in autores.Rows)
                    {
                        Console.WriteLine(item);
                    }

                    readJob.Wait();
                    listaAutores = autores;

                }
                else
                {
                    listaAutores = null;
                    //ModelState.AddModelError(string.Empty, "Ocurrio un error, hable con el admin");
                }
                return listaAutores;
            }
        }



    }
}