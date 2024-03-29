
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
    public class CatalogoDAL
    {
        public  string chain = Constant.URL;
        public DataTable listarCatalogo()
        {

            DataTable listaCatalogos = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("Catalogo");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsAsync<DataTable>();
                    readJob.Wait();
                    listaCatalogos = readJob.Result;

                }
                else
                {
                    listaCatalogos = null;
                    //ModelState.AddModelError(string.Empty, "Ocurrio un error, hable con el admin");
                }
                return listaCatalogos;
            }

        }
        // borraras
        public IEnumerable<CatalogoModel> valoresCatalogo()
        {

            IEnumerable<CatalogoModel> catalogos = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("Catalogo");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsAsync<IList<CatalogoModel>>();
                    readJob.Wait();
                    catalogos = readJob.Result;
                }
                else
                {
                    catalogos = Enumerable.Empty<CatalogoModel>();
                    
                }
                return catalogos;
            }

        }


        public bool insertarCatalogo(CatalogoModel activo)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var postTask = client.PostAsJsonAsync<CatalogoModel>("Catalogo", activo);
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
        public bool actualizarCatalogo(CatalogoModel activo)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var putTask = client.PutAsJsonAsync<CatalogoModel>("Catalogo", activo);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;

            }
        }
        public bool eliminarCatalogo(String id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var deleteTask = client.DeleteAsync("Catalogo/" + id);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode) return true;
                else return false;
            }

        }
        public CatalogoModel getCatalogoById(String id)
        {
            CatalogoModel activo = new CatalogoModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("Catalogo/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsAsync<CatalogoModel>();
                    readJob.Wait();
                    activo = readJob.Result;
                }
                else
                {
                    activo = null;
                    // ModelState.AddModelError(string.Empty, "Ocurrio un error, hable con el admin");
                }
                return activo;
            }
        }
        public DataTable getCatalogoByIdDataTable(String id)
        {
            DataTable listaCatalogos = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("Catalogo/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsAsync<DataTable>();
                    readJob.Wait();
                    listaCatalogos = readJob.Result;
                }
                else
                {
                    listaCatalogos = null;
                    // ModelState.AddModelError(string.Empty, "Ocurrio un error, hable con el admin");
                }
                return listaCatalogos;
            }
        }
        public DataTable getCatalogoByNombreDataTable(String nombre)
        {
            DataTable listaCatalogos = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("Catalogo/getbyDesc/" + nombre);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsAsync<DataTable>();
                    readJob.Wait();
                    listaCatalogos = readJob.Result;
                }
                else
                {
                    listaCatalogos = null;
                    // ModelState.AddModelError(string.Empty, "Ocurrio un error, hable con el admin");
                }
                return listaCatalogos;
            }
        }
    }
}