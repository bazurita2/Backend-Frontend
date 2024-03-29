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
    public class LibroDAL
    {
        //public const string chain = EndPoint.pythonEndPoint;
        public const string chain = EndPoint.pythonEndPoint;

        public DataTable listarLibro()
        {

            DataTable listaLibro = null;

            using (var client = new HttpClient())
            {


                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("libro");
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
                    var libros = (DataTable)JsonConvert.DeserializeObject<DataTable>(readJob.Result);

                    foreach (var item in libros.Rows)
                    {
                        Console.WriteLine(item);
                    }

                    readJob.Wait();
                    listaLibro = libros;

                }
                else
                {
                    listaLibro = null;
                    //ModelState.AddModelError(string.Empty, "Ocurrio un error, hable con el admin");
                }
                return listaLibro;
            }

        }

        public bool insertarLibro(LibroModel libro)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var json = JsonConvert.SerializeObject(libro, Formatting.Indented);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                var postTask = client.PostAsync("libro" , stringContent);
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

        public bool actualizarLibro(LibroModel libro)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var json = JsonConvert.SerializeObject(libro, Formatting.Indented);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var putTask = client.PutAsync("libro/" + libro.idLibro, stringContent);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;

            }
        }

        public bool eliminarLibro(String id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var deleteTask = client.DeleteAsync("libro/" + id);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode) return true;
                else return false;
            }

        }

        public DataTable getLibrosByCoincidence(String coincidence)
        {
            DataTable listaLibro = null;

            using (var client = new HttpClient())
            {


                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("librosByCoincidence/" + coincidence);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsStringAsync();
                    var libros = (DataTable)JsonConvert.DeserializeObject<DataTable>(readJob.Result);

                    foreach (var item in libros.Rows)
                    {
                        Console.WriteLine(item);
                    }

                    readJob.Wait();
                    listaLibro = libros;

                }
                else
                {
                    listaLibro = null;
                    //ModelState.AddModelError(string.Empty, "Ocurrio un error, hable con el admin");
                }
                return listaLibro;
            }
        }

    }
}