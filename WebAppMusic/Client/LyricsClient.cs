using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebAppMusic.Models;

namespace WebAppMusic.Client
{

    public class LyricsClient
    {
        
        public async Task<Lmodel> GetLyrics()
        {
            

            HttpClient client1 = new HttpClient();
            HttpRequestMessage request1 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://spotify23.p.rapidapi.com/track_lyrics/?id={LyricsParameters.id}"),
                Headers =
    {
        { "X-RapidAPI-Host", "spotify23.p.rapidapi.com" },
        { "X-RapidAPI-Key", "bedb9b8f8emshe70d8699a798647p1d7300jsn6b4acd41b488" },
    },
            };
            var response1 = await client1.SendAsync(request1);

            response1.EnsureSuccessStatusCode();
            var body1 = await response1.Content.ReadAsStringAsync();


            var res1 = JsonConvert.DeserializeObject<Lmodel>(body1);



            return res1;
        }

    }
}
