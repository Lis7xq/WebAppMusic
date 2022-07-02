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
		{ "X-RapidAPI-Key", "bedb9b8f8emshe70d8699a798647p1d7300jsn6b4acd41b488" },                               //c6d7cd47e7mshf4ad89444032254p18ba09jsn8b861e188fe5
	},
			};
			var response = await client.SendAsync(request);

			response.EnsureSuccessStatusCode();
			var body = await response.Content.ReadAsStringAsync();


			var res = JsonConvert.DeserializeObject<Model>(body);


            if (res.tracks.items.Count == 0)
            {
				//res.tracks = "";
            }
            else { LyricsParameters.id = res.tracks.items.FirstOrDefault().data.id; }
            
				
			
            
				
			
			



			

			return res;
		}

		

	}

	
}
