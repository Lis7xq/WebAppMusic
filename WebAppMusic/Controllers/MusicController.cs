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
        public readonly TopMusicClient _topMusicClient;

        public readonly LyricsClient _lyricsClient;

        public readonly MusicClient _musicClient;

        private readonly ILogger<MusicController> _logger;

        public MusicController(ILogger<MusicController> logger, MusicClient musicClient, LyricsClient lyricsClient, TopMusicClient topMusicClient)
        {
            _logger = logger;
            _musicClient = musicClient;
            _lyricsClient = lyricsClient;
            _topMusicClient = topMusicClient;
        }


        [HttpGet("Music/Author")]

        public async Task<MusicResponce> GetSearch([FromQueryAttribute] MusicParameters parameters)
        {
            MusicClient musicClient = new MusicClient();

            var music = await _musicClient.GetSearch(parameters.Name, parameters.Type, parameters.Limit);



            Model model = musicClient.GetSearch(parameters.Name, parameters.Type, parameters.Limit).Result;





            var result = new MusicResponce
            {
                totalCoiunt = music.tracks.totalCount,
                Uri = music.tracks.items.FirstOrDefault().data.uri,
                Id = music.tracks.items.FirstOrDefault().data.id,
                Name = music.tracks.items.FirstOrDefault().data.name,
                Alburi = music.tracks.items.FirstOrDefault().data.albumOfTrack.uri,
                AlbName = music.tracks.items.FirstOrDefault().data.albumOfTrack.name,
                AlbId = music.tracks.items.FirstOrDefault().data.albumOfTrack.id,
                SourceUrl = music.tracks.items.FirstOrDefault().data.albumOfTrack.coverArt.sources.FirstOrDefault().url,
                width = music.tracks.items.FirstOrDefault().data.albumOfTrack.coverArt.sources.FirstOrDefault().width,
                height = music.tracks.items.FirstOrDefault().data.albumOfTrack.coverArt.sources.FirstOrDefault().height,
                ProfName = music.tracks.items.FirstOrDefault().data.artists.items.FirstOrDefault().profile.name,
                totaltime = music.tracks.items.FirstOrDefault().data.duration.totalMilliseconds,
            };

            return result;
        }


        [HttpGet("Lyrics")]

        public async Task<LyricsResponce> GetLyrics() //LyricsParameters parameters
        {
            LyricsClient lyricsClient = new LyricsClient();

            var search = await _lyricsClient.GetLyrics();



            Lmodel lmodel = lyricsClient.GetLyrics().Result;
            var res1 = new LyricsResponce();

            foreach (var item in lmodel.lyrics.lines)
            {
                res1.Words += item.words + ". ";

            }


            return res1;
        }

        [HttpGet("Top10")]


        public async Task<TopResponce> GetTop([FromQueryAttribute] TopParameters parameters) //LyricsParameters parameters
        {
            

            TopMusicClient topMusicClient = new TopMusicClient();

            var find = await _topMusicClient.GetTop(parameters.Artist);


            Tmodel tmodel = _topMusicClient.GetTop(parameters.Artist).Result;

            //var res1 = new LyricsResponce();

            var result3 = new TopResponce
            {
                Track = tmodel.track.FirstOrDefault().strTrack,
                Album = tmodel.track.FirstOrDefault().strAlbum,
                Artist = tmodel.track.FirstOrDefault().strArtist,
                Genre = tmodel.track.FirstOrDefault().strGenre,
                Mood = tmodel.track.FirstOrDefault().strMood,
                Style = tmodel.track.FirstOrDefault().strStyle,
                Description = tmodel.track.FirstOrDefault().strDescriptionEN,
                ImgLink = tmodel.track.FirstOrDefault().strTrackThumb,
                MusicVid = tmodel.track.FirstOrDefault().intMusicVidViews,
                MusicLikes = tmodel.track.FirstOrDefault().intMusicVidLikes
            };

            return result3;


           
        }
    }
}
