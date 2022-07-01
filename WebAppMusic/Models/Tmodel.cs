using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMusic.Models
{
   
        public class Tmodel
        {
            public Track[] track { get; set; }
        }

        public class Track
        {
        public string idTrack { get; set; }
        public string idAlbum { get; set; }
        public string idArtist { get; set; }
        public string idLyric { get; set; }
        public object idIMVDB { get; set; }
        public string strTrack { get; set; }
        public string strAlbum { get; set; }
        public string strArtist { get; set; }
        public object strArtistAlternate { get; set; }
        public object intCD { get; set; }
        public string intDuration { get; set; }
        public string strGenre { get; set; }
        public string strMood { get; set; }
        public string strStyle { get; set; }
        public string strTheme { get; set; }
        public string strDescriptionEN { get; set; }
        public object strDescriptionDE { get; set; }
        public object strDescriptionFR { get; set; }
        public object strDescriptionCN { get; set; }
        public object strDescriptionIT { get; set; }
        public object strDescriptionJP { get; set; }
        public object strDescriptionRU { get; set; }
        public object strDescriptionES { get; set; }
        public object strDescriptionPT { get; set; }
        public object strDescriptionSE { get; set; }
        public object strDescriptionNL { get; set; }
        public object strDescriptionHU { get; set; }
        public object strDescriptionNO { get; set; }
        public object strDescriptionIL { get; set; }
        public object strDescriptionPL { get; set; }
        public string strTrackThumb { get; set; }
        public object strTrack3DCase { get; set; }
        public string strTrackLyrics { get; set; }
        public string strMusicVid { get; set; }
        public string strMusicVidDirector { get; set; }
        public string strMusicVidCompany { get; set; }
        public object strMusicVidScreen1 { get; set; }
        public object strMusicVidScreen2 { get; set; }
        public object strMusicVidScreen3 { get; set; }
        public string intMusicVidViews { get; set; }
        public string intMusicVidLikes { get; set; }
        public string intMusicVidDislikes { get; set; }
        public string intMusicVidFavorites { get; set; }
        public string intMusicVidComments { get; set; }
        public string intTrackNumber { get; set; }
        public string intLoved { get; set; }
        public string intScore { get; set; }
        public string intScoreVotes { get; set; }
        public string intTotalListeners { get; set; }
        public string intTotalPlays { get; set; }
        public string strMusicBrainzID { get; set; }
        public string strMusicBrainzAlbumID { get; set; }
        public string strMusicBrainzArtistID { get; set; }
        public string strLocked { get; set; }
    }
    
}
