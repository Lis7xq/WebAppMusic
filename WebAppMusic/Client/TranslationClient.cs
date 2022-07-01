using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebAppMusic.Models;

namespace WebAppMusic.Client
{
    public class TranClient
	{



		public async Task<TRANSLATEmodelcs> GetTrans()
		{
			string beb = " ";

			foreach (var item in TEST.word)
			{
				beb += item;
			}
			TEST.word.Clear();


			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Post,
				RequestUri = new Uri("https://translo.p.rapidapi.com/api/v3/translate"),
				Headers =
	{
		{ "X-RapidAPI-Key", "ed468944ddmsha17e240ea898a13p17cb0ajsn4c83ced84247" },
		{ "X-RapidAPI-Host", "translo.p.rapidapi.com" },
	},
				Content = new FormUrlEncodedContent(new Dictionary<string, string>
	{
		{ "to", $"uk" },
		{ "text", $"{beb}" },
	}),
			};
			var response = await client.SendAsync(request);

			response.EnsureSuccessStatusCode();
			var body = await response.Content.ReadAsStringAsync();
			Console.WriteLine(body);

			var res = JsonConvert.DeserializeObject<TRANSLATEmodelcs>(body);
			return res;

		}

	}
}
