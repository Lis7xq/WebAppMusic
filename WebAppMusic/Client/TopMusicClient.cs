using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebAppMusic.Models;

namespace WebAppMusic.Client
{
    public class TopMusicClient
    {
		public async Task<Tmodel> GetTop(string Artist)
		{

			HttpClient client3 = new HttpClient();
			HttpRequestMessage request3 = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri($"https://theaudiodb.p.rapidapi.com/track-top10.php?s={Artist}"),
				Headers =
	{
		{ "X-RapidAPI-Host", "theaudiodb.p.rapidapi.com" },
		{ "X-RapidAPI-Key", "3f5b63bb63msh0673a778ca97167p191036jsn93fe0a392291" },
	},
			};
			var response3 = await client3.SendAsync(request3);

			response3.EnsureSuccessStatusCode();
			var body3 = await response3.Content.ReadAsStringAsync();
			Console.WriteLine(body3);

			var res3 = JsonConvert.DeserializeObject<Tmodel>(body3);

			return res3;
		}
	}
}
