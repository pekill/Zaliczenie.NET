using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zaliczenie.Models;

namespace Zaliczenie.View
{
    public class Movies
    {
        private RestClient client;

        public Movies()
        {
            client = new RestClient("https://imdb8.p.rapidapi.com/");
            client.AddDefaultHeader("X-RapidAPI-Key", "d96f87cdecmsha2382a79532291bp1a5769jsn0f7e709fd5d8");
            client.AddDefaultHeader("X-RapidAPI-Host", "imdb8.p.rapidapi.com");
        }

        public async Task<AutoCompleteResult> GetMoviesAsync(string query)
        {
            var request = new RestRequest($"auto-complete?q={query}", Method.Get);
            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<AutoCompleteResult>(response.Content);
            }
            else
            {
                throw new Exception($"Błąd API: {response.StatusCode} - {response.Content}");
            }
        }
    }
}