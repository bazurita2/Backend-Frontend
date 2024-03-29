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
    public class AutorDAL
    {
        //public const string chain = EndPoint.pythonEndPoint;
        public const string chain = EndPoint.pythonEndPoint;

        public DataTable listarAutor()
        {

            DataTable listaAutores = null;

            using (var client = new HttpClient())
            {


                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("autores");
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
                    var autores = new DataTable();
                    var readJob = result.Content.ReadAsStringAsync();
                    try
                    {
                         autores = (DataTable)JsonConvert.DeserializeObject<DataTable>(readJob.Result);

                    }
                    catch (Exception e)
                    {

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

        public bool insertarAutor(AutorModel activo)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var json = JsonConvert.SerializeObject(activo, Formatting.Indented);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                var postTask = client.PostAsync("autores" , stringContent);
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

        public bool actualizarAutor(AutorModel autor)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var json = JsonConvert.SerializeObject(autor, Formatting.Indented);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var putTask = client.PutAsync("autores/" + autor.idAutor, stringContent);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;

            }
        }

        public bool eliminarAutor(String id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var deleteTask = client.DeleteAsync("autores/" + id);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode) return true;
                else return false;
            }

        }

        public DataTable getAutorByCoincidence(String coincidence)
        {
            DataTable listaAutores = null;

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