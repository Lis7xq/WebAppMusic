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
        public readonly TranClient _tranClient;

        public readonly AuthorClient _authorClient;

        public readonly TopMusicClient _topMusicClient;

        public readonly LyricsClient _lyricsClient;

        public readonly MusicClient _musicClient;

        private readonly ILogger<MusicController> _logger;

        public MusicController(ILogger<MusicController> logger, MusicClient musicClient, LyricsClient lyricsClient, TopMusicClient topMusicClient, AuthorClient authorClient, TranClient tranClient)
        {
            _logger = logger;
            _musicClient = musicClient;
            _lyricsClient = lyricsClient;
            _topMusicClient = topMusicClient;
            _authorClient = authorClient;
            _tranClient = tranClient;
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

        public async Task<LyricsResponce> GetLyrics()
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


        public async Task<Tmodel> GetTop([FromQueryAttribute] TopParameters parameters)
        {


            TopMusicClient topMusicClient = new TopMusicClient();

            var find = await _topMusicClient.GetTop(parameters.Artist);


            Tmodel tmodel = _topMusicClient.GetTop(parameters.Artist).Result;



            return tmodel;



        }

        [HttpGet("Bio")]


        public async Task<Amodel> GetBio([FromQueryAttribute] AuthorParameters parameters)
        {


            AuthorClient authorClient = new AuthorClient();

            var find1 = await _authorClient.GetBio(parameters.Author);


            Amodel amodel = _authorClient.GetBio(parameters.Author).Result;



            return amodel;



        }


        [HttpPost("Translate")]


        public async Task<TranModel> GetTrans()
        {
            TranClient tranClient = new TranClient();



            var find3 = await _tranClient.GetTrans();


            TranModel tranModel = _tranClient.GetTrans().Result;




            return tranModel;


        }

        [HttpPost("List OF Songs")]

        public void AddtoList(string name)
        {
            

            SONGS.ListOfSongs.Add(name);
            SONGS.Save();
        }

        [HttpGet]

        public List<string> ShowList()
        {
            return SONGS.ListOfSongs;
        }
    }
}
