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
        public readonly LyricsClient _lyricsClient;

        public readonly MusicClient _musicClient;

        private readonly ILogger<MusicController> _logger;

        public MusicController(ILogger<MusicController> logger, MusicClient musicClient, LyricsClient lyricsClient)
        {
            _logger = logger;
            _musicClient = musicClient;
            _lyricsClient = lyricsClient;
        }


        [HttpGet("Music/Author")]

        public async Task<Model> GetSearch([FromQueryAttribute] MusicParameters parameters)
        {
            MusicClient musicClient = new MusicClient();

            var music = await _musicClient.GetSearch(parameters.Name, parameters.Type, parameters.Limit);  



            Model model = musicClient.GetSearch(parameters.Name, parameters.Type, parameters.Limit).Result;





            var result = new MusicResponce
            {
                //totalCoiunt = music.tracks.totalCount,
                //Uri = music.tracks.items.FirstOrDefault().data.uri.ToString(),
                //Id = music.tracks.items.FirstOrDefault().data.id,
                //Name = music.tracks.items.FirstOrDefault().data.name,
                //Alburi = music.tracks.items.FirstOrDefault().data.albumOfTrack.uri,
                //AlbName = music.tracks.items.FirstOrDefault().data.albumOfTrack.name,
                //AlbId = music.tracks.items.FirstOrDefault().data.albumOfTrack.id,
                //SourceUrl = music.tracks.items.FirstOrDefault().data.albumOfTrack.coverArt.sources.FirstOrDefault().url,
                //width = music.tracks.items.FirstOrDefault().data.albumOfTrack.coverArt.sources.FirstOrDefault().width,
                //height = music.tracks.items.FirstOrDefault().data.albumOfTrack.coverArt.sources.FirstOrDefault().height,
                //ProfName = music.tracks.items.FirstOrDefault().data.artists.items.FirstOrDefault().profile.name,
                //totaltime = music.tracks.items.FirstOrDefault().data.duration.totalMilliseconds,
            };

            return music;
        }


        [HttpGet("Lyrics")]
        
        public async Task<Lmodel> GetLyrics() //LyricsParameters parameters
        {
            LyricsClient lyricsClient = new LyricsClient();

            var search = await _lyricsClient.GetLyrics();



            Lmodel lmodel = lyricsClient.GetLyrics().Result;

            return search;
        }

    }
}
