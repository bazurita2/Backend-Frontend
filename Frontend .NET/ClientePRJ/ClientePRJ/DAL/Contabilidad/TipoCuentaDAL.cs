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
using ClientePRJ.Models.Contabilidad;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ClientePRJ.DAL.Contabilidad
{
    public class TipoCuentaDAL
    {
        public const string chain = EndPoint.cSharpEndPoint;
        public DataTable listar()
        {

            DataTable lista = null;

            using (var client = new HttpClient())
            {


                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("TipoCuenta");
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
                    lista = autores;

                }
                else
                {
                    lista = null;
                    //ModelState.AddModelError(string.Empty, "Ocurrio un error, hable con el admin");
                }
                return lista;
            }

        }
        //public bool insertar(TipoCuentaModel obj)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri(chain);
        //        var postTask = client.pos<TipoCuentaModel>("tipocuenta", obj);
        //        postTask.Wait();

        //        var result = postTask.Result;
        //        if (result.IsSuccessStatusCode) return true;
        //        else return false;

        //    }
        //}
        public bool insertar(TipoCuentaModel obj)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var json = JsonConvert.SerializeObject(obj, Formatting.None);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                //var stringContent = " {\"idtipocuenta\": 6,\"nombretipocuenta\": \"x\",\"descripciontipocuenta\": \"x\"  }";

                var postTask = client.PostAsync("TipoCuenta/guardarTipocuenta", stringContent);
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
        public bool actualizar(TipoCuentaModel obj)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var json = JsonConvert.SerializeObject(obj, Formatting.None);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                //var stringContent = " {\"idtipocuenta\": 6,\"nombretipocuenta\": \"x\",\"descripciontipocuenta\": \"x\"  }";

                var postTask = client.PutAsync("TipoCuenta/actualizarTipocuenta", stringContent);
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
        public bool eliminar(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var deleteTask = client.DeleteAsync("TipoCuenta/eliminarTipocuenta/?id=" + id);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode) return true;
                else return false;
            }

        }
        public DataTable getByNombreDataTable(String nombre)
        {
            DataTable lista = null;

            using (var client = new HttpClient())
            {


                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("TipoCuenta/TipocuentaByNombre?nombre=" + nombre);
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
                    lista = autores;

                }
                else
                {
                    lista = null;
                    //ModelState.AddModelError(string.Empty, "Ocurrio un error, hable con el admin");
                }
                return lista;
            }
        }
        //public TipoCuentaModel getById(String id)
        //{
        //    TipoCuentaModel activo = new TipoCuentaModel();
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri(chain);
        //        var responseTask = client.GetAsync("tipocuenta/" + id);
        //        responseTask.Wait();

        //        var result = responseTask.Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            var readJob = result.Content.ReadAsAsync<TipoCuentaModel>();
        //            readJob.Wait();
        //            activo = readJob.Result;
        //        }
        //        else
        //        {
        //            activo = null;
        //        }
        //        return activo;
        //    }
        //}
        //public DataTable getByIdDataTable(String id)
        //{
        //    DataTable listaActivos = null;
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri(chain);
        //        var responseTask = client.GetAsync("tipocuenta/" + id);
        //        responseTask.Wait();

        //        var result = responseTask.Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            var readJob = result.Content.ReadAsAsync<DataTable>();
        //            readJob.Wait();
        //            listaActivos = readJob.Result;
        //        }
        //        else
        //        {
        //            listaActivos = null;
        //        }
        //        return listaActivos;
        //    }
        //}

    }
}