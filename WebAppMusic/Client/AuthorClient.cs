using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebAppMusic.Models;

namespace WebAppMusic.Client
{
    public class AuthorClient
    {
		public async Task<Amodel> GetBio(string Author)
		{

			HttpClient client = new HttpClient();
			HttpRequestMessage request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri($"https://theaudiodb.p.rapidapi.com/search.php?s={Author}"),
				Headers =
	{
		{ "X-RapidAPI-Host", "theaudiodb.p.rapidapi.com" },
		{ "X-RapidAPI-Key", "3f5b63bb63msh0673a778ca97167p191036jsn93fe0a392291" },
	},
			};
			var response = await client.SendAsync(request);

			response.EnsureSuccessStatusCode();
			var body = await response.Content.ReadAsStringAsync();
			Console.WriteLine(body);

			var res = JsonConvert.DeserializeObject<Amodel>(body);

			return res;
		}
	}
}
