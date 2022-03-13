using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using ConsumoApi.Models;
using System.Text;

namespace ConsumoApi
{
    class Program
    {
        static void Main(string[] args)
        {
            CriarPosts();
            ListarPosts();

        }

        public async static void ListarPosts()
        {

            string urlApi = "https://jsonplaceholder.typicode.com/posts";

            try
            {
                HttpClient cliente = new HttpClient();
                var resposta = await cliente.GetAsync(urlApi);

                var content = await resposta.Content.ReadAsStringAsync();
                var retorno = JsonConvert.DeserializeObject<Post[]>(content);  //transformando json em formato .net

                foreach (var item in retorno)
                {
                    Console.WriteLine(item);
                }



            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async static void CriarPosts()
        {
            string urlApi = "https://jsonplaceholder.typicode.com/posts";

            try
            {
                HttpClient cliente = new HttpClient();
                var post = new Post();

                string jsonObjeto = JsonConvert.SerializeObject(post); // Convertendo em json
                var content = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");

                var resposta = await cliente.PostAsync(urlApi, content);

                if (resposta.IsSuccessStatusCode)
                {
                    var retorno = resposta.Content.ReadAsStringAsync();

                    var postCriado = JsonConvert.DeserializeObject<Post>(retorno.Result);
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }




    }
}
