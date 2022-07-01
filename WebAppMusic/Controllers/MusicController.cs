using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMusic.Client;
using WebAppMusic.Extensions;
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

        public async Task<MusicResponce> GetSearch([FromQueryAttribute] MusicParameters parameters)   //MusicResponce
        {
            MusicClient musicClient = new MusicClient();

            var music = await _musicClient.GetSearch(parameters.Name, parameters.Type, parameters.Limit);



            Model model = musicClient.GetSearch(parameters.Name, parameters.Type, parameters.Limit).Result;


            MusicResponce result = new MusicResponce();

            //List<MusicResponce> res = new List<MusicResponce>();
            //for (int i = 0; i < parameters.Limit; i++)
            //{

            if (music.tracks.items.Count != 0)
            {
                 result = new MusicResponce
                {
                    items = music.tracks.items,
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
               
            }
            else { result = null; }

            return result;





        }

        

        [HttpGet("Lyrics")]

        public async Task<LyricsResponce> GetLyrics()
        {
            LyricsClient lyricsClient = new LyricsClient();

            var search = await _lyricsClient.GetLyrics();

         
            
            Lmodel lmodel = lyricsClient.GetLyrics().Result;
            var res1 = new LyricsResponce();
            TEST.word = null;
            foreach (var item in lmodel.lyrics.lines)
            {
                res1.Words += item.words + ". ";

               TEST.word.Add(item.words + ".");
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


        public async Task<TRANSLATEmodelcs> GetTrans()
        {
            TranClient tranClient = new TranClient();

            

            var find3 = await _tranClient.GetTrans();


            

            string tranModel = find3.translated_text;

            
            return find3;


        }





        //[HttpGet("Show")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> GetFavouritebyId([FromQuery] string Tid)
        //{
        //    var result = await _dynamoDbClient.GetDataByID(Tid);

        //    if (result == null)
        //        return NotFound("it looks like this data is not in the database");

        //    var MusicResponce = new MusicResponce
        //    {
        //        Id = result.Tid,
        //        Uri = result.SpotUrl,
        //        ProfName = result.ArtistName,
        //        Name = result.SongName

        //    };
        //    return Ok(MusicResponce);
        //}

        //[HttpPost("Add")]

        //public async Task<IActionResult> AddToFavourites([FromBody] MusicResponce music)
        //{

        //    var data = new UserDbRepository
        //    {
        //        Tid = music.Id,
        //        SongName = music.Name,
        //        ArtistName = music.ProfName,
        //        SpotUrl = music.Uri
        //    };
        //   var result = await _dynamoDbClient.PostDataToOb(data);

        //    if (result == false)
        //    {
        //        return BadRequest("Error with insertion data to DB. PLS check cosnole log");
        //    }

        //    return Ok("Data has been added to DB");
        //}

        //[HttpGet("All")]

        //public async Task<IActionResult> GetAll()
        //{
        //    var responce = await _dynamoDbClient.GetAll();

        //    if (responce == null)
        //        return NotFound("No info found in DB");

        //    var result = responce
        //        .Select(x => new MusicResponce()
        //        {
        //            Id = x.Tid,
        //            Name = x.SongName,
        //            ProfName = x.ArtistName,
        //            Uri = x.SpotUrl
        //        })
        //        .ToList();
        //    return Ok(result);
        //}
        //[HttpGet]

        //public async Task<GetItemResponse> GetDataFromDb()
        //{
        //    var tableName = "song-db";

        //    var item = new GetItemRequest
        //    {
        //        TableName = tableName,
        //        Key = new Dictionary<string, AttributeValue>
        //        {
        //            {"Tid", new AttributeValue{S = "12345"}}
        //        }
        //    };

        //    var responce = await _dynamoDB.GetItemAsync(item);

        //    var result = responce.Item.ToClass<UserDbRepository>();

        //    return responce;
        //}

    }
}
