using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebAppMusic.Controllers;
using WebAppMusic.Models;

namespace WebAppMusic.Client
{
    public class TranClient
    {

		public async Task<string> GetTrans()
		{
			string beb = " ";

            foreach (var item in TEST.word)
            {
				beb += item;
            }

			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri($"https://google-translate20.p.rapidapi.com/translate?text={beb}&tl=ru&sl=en"),           //https://google-translate20.p.rapidapi.com/translate
				Headers =
	{
		{ "X-RapidAPI-Key", "3f5b63bb63msh0673a778ca97167p191036jsn93fe0a392291" },
		{ "X-RapidAPI-Host", "google-translate20.p.rapidapi.com" },
	},
	//			Content = new FormUrlEncodedContent(new Dictionary<string, string>
	//{
	//	{ "text", $"{beb}" },
	//	{ "tl", "ru" },
	//	{ "sl", "en" },
	//}),
			};
			var response = await client.SendAsync(request);

			

			response.EnsureSuccessStatusCode();
			var body = await response.Content.ReadAsStringAsync();
			//Console.WriteLine(body);

			var res5 = JsonConvert.DeserializeObject<TranModel>(body);

			

			return body;

		}

	}
}
