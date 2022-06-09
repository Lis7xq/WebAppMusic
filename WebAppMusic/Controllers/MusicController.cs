using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMusic.Client;
using WebAppMusic.Models;

namespace WebAppMusic.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MusicController : ControllerBase
    {
        public readonly MusicClient _musicClient;

        private readonly ILogger<MusicController> _logger;

        public MusicController(ILogger<MusicController> logger, MusicClient musicClient)
        {
            _logger = logger;
            _musicClient = musicClient;

        }



        [HttpGet]

        public async Task<Model> GetSearch([FromQueryAttribute] MusicParameters parameters)
        {
            MusicClient musicClient = new MusicClient();

            var music = await _musicClient.GetSearch(parameters.Name, parameters.Type, parameters.Limit);  



            Model model = musicClient.GetSearch(parameters.Name, parameters.Type, parameters.Limit).Result;  //   //string Name, string Type

            //var result = new MusicResponce
            //{
            //    Title = music.tracks.hits.FirstOrDefault().track.title.ToString(),
            //    //Href = music.tracks.hits.FirstOrDefault().track.share.href,
            //    //Image = music.tracks.hits.FirstOrDefault().track.share.image,
            //    //Avatar = music.tracks.hits.FirstOrDefault().track.share.avatar

            //};



            return music;
        }
        
    }
}
