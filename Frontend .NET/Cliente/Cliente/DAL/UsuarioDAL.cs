using Cliente.Constants;
using Cliente.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Cliente.DAL
{
    public class UsuarioDAL
    {
        public string chain = Constant.URL;
        public IEnumerable<UsuarioModel> listarUsuarios()
        {
            IEnumerable<UsuarioModel> listaUsuarios = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(chain);
                var responseTask = client.GetAsync("usuario");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsAsync<List<UsuarioModel>>();
                    readJob.Wait();
                    listaUsuarios = readJob.Result;
                }
                else
                {
                    listaUsuarios = null;
                }
                return listaUsuarios;
            }

        }
    }
}