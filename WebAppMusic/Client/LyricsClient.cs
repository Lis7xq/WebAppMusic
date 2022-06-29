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
        { "X-RapidAPI-Key", "ed468944ddmsha17e240ea898a13p17cb0ajsn4c83ced84247" },
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
