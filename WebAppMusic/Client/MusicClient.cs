using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebAppMusic.Models;

namespace WebAppMusic.Client
{
    public class MusicClient
    {
		

		public async Task<Model> GetSearch(string Name, string Type, int Limit)  //albums,artists,episodes,genres,playlists,podcasts,tracks,users
		{

			HttpClient client = new HttpClient();
			HttpRequestMessage request = new HttpRequestMessage
			{                                                                                                                
				Method = HttpMethod.Get,
				RequestUri = new Uri($"https://spotify23.p.rapidapi.com/search/?q={Name}&type={Type}&offset=0&limit={Limit}&numberOfTopResults=5"), 
				Headers =
	{
		{ "X-RapidAPI-Host", "spotify23.p.rapidapi.com" },                                                            
		{ "X-RapidAPI-Key", "3f5b63bb63msh0673a778ca97167p191036jsn93fe0a392291" },                               
	},
			};
			var response = await client.SendAsync(request);

			response.EnsureSuccessStatusCode();
			var body = await response.Content.ReadAsStringAsync();


			var res = JsonConvert.DeserializeObject<Model>(body);

			return res;
		}

		

	}
}
