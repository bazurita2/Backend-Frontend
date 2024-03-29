using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientePRJ.DAL.Mantenimiento
{
    public class MushupDAL
    {
        /*
        public string url = "https://rickandmortyapi.com/api/";

        public DataTable listarCaracteres()
        {
            DataTable listaCaracteres = new DataTable();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                var responseTask = client.GetAsync("character");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsStringAsync();

                    var characters = JsonConvert.DeserializeObject<MushupModel>(readJob);
                    readJob.Wait();
                    listaActivos = readJob.Result;

                }
                else
                {
                    listaActivos = null;
                }
                return listaActivos;
            }
        */
    }
}