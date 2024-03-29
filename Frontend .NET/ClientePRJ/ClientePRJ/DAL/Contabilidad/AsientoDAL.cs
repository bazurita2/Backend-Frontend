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
    public class AsientoDAL
    {
        public const string chain = EndPoint.cSharpEndPoint;
        public DataTable listar()
        {

            DataTable lista = null;

            using (var client = new HttpClient())
            {


                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("Asiento");
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
        public string insertar(AsientoModel obj)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var json = JsonConvert.SerializeObject(obj, Formatting.None);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                //var stringContent = " {\"idtipocuenta\": 6,\"nombretipocuenta\": \"x\",\"descripciontipocuenta\": \"x\"  }";

                var postTask = client.PostAsync("Asiento/guardarAsiento", stringContent);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsStringAsync();
                    string identity= readJob.Result;
                    return identity;
                }
                else
                {
                    //ModelState.AddModelError(string.Empty, "Ocurrio un error, hable con el admin");
                    return "0";
                }

            }
        }
        public bool actualizar(AsientoModel obj)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var json = JsonConvert.SerializeObject(obj, Formatting.None);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                //var stringContent = " {\"idtipocuenta\": 6,\"nombretipocuenta\": \"x\",\"descripciontipocuenta\": \"x\"  }";

                var postTask = client.PutAsync("Asiento/actualizarAsiento", stringContent);
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
                var deleteTask = client.DeleteAsync("Asiento/eliminarAsiento/?id=" + id);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode) return true;
                else return false;
            }

        }
        private string transformarFecha(DateTime mifecha)
        {
            string resultado = mifecha.Year+ "%2F"+mifecha.Month+ "%2F"+mifecha.Day;
            //string resultado =mifecha.ToShortDateString();
            //2022%2F09%2F09
            return resultado;
        }
        public DataTable getByFechas(DateTime inicio, DateTime fin)
        {
            DataTable lista = null;
            string prueba=inicio.ToShortDateString();
            using (var client = new HttpClient())
            {


                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("Asiento/AsientoByFechas?inicio=" + transformarFecha(inicio)+ "&fin=" + transformarFecha(fin));
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
        public AsientoModel getById(int id)
        {
            AsientoModel obj = new AsientoModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("Asiento/AsientoById?id=" + id);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsStringAsync();
                    obj = (AsientoModel)JsonConvert.DeserializeObject<AsientoModel>(readJob.Result);
                    readJob.Wait();
                  
                }
                else
                {
                    obj = null;
                }
                return obj;
            }
        }
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