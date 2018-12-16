using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using Newtonsoft.Json;

using VideoGameMusicApp.Helpers;
using VideoGameMusicApp.Models;

namespace VideoGameMusicApp.Services
{
    public static class ServicioCanciones
    {
        private static readonly HttpClient cliente = CrearHttpClient();

        private static HttpClient CrearHttpClient()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constantes.AzureFunctionsEndpoint);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return httpClient;
        }

        public async static Task<List<Cancion>> ObtenerCanciones()
        {
            try
            {
                var response = await cliente.GetAsync(Constantes.ObtenerCancionesUrl);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Cancion>>(json);
                }
            }
            catch (Exception ex)
            {
            }

            return new List<Cancion>();
        }
    }
}