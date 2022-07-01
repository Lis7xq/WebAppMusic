using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMusic.Models
{
   
        public class Amodel
        {
            public Artist[] artists { get; set; }
        }

        public class Artist
        {
            //public string idArtist { get; set; }
            public string strArtist { get; set; }
            public object strArtistStripped { get; set; }
            //public string strArtistAlternate { get; set; }
            public string strLabel { get; set; }
            //public string idLabel { get; set; }
            public string intFormedYear { get; set; }
            public string intBornYear { get; set; }
            public object intDiedYear { get; set; }
            //public object strDisbanded { get; set; }
            public string strStyle { get; set; }
            public string strGenre { get; set; }
            public string strMood { get; set; }
            public string strWebsite { get; set; }
            public string strFacebook { get; set; }
            public string strTwitter { get; set; }
            public string strBiographyEN { get; set; }
            //public string strBiographyDE { get; set; }
            //public string strBiographyFR { get; set; }
            //public string strBiographyCN { get; set; }
            //public string strBiographyIT { get; set; }
            //public string strBiographyJP { get; set; }
            //public string strBiographyRU { get; set; }
            //public string strBiographyES { get; set; }
            //public string strBiographyPT { get; set; }
            //public string strBiographySE { get; set; }
            //public string strBiographyNL { get; set; }
            //public string strBiographyHU { get; set; }
            //public string strBiographyNO { get; set; }
            //public string strBiographyIL { get; set; }
            //public string strBiographyPL { get; set; }
            public string strGender { get; set; }
            public string intMembers { get; set; }
            public string strCountry { get; set; }
            //public string strCountryCode { get; set; }
            //public string strArtistThumb { get; set; }
            public string strArtistLogo { get; set; }
            //public string strArtistCutout { get; set; }
            //public string strArtistClearart { get; set; }
            //public string strArtistWideThumb { get; set; }
            //public string strArtistFanart { get; set; }
            //public string strArtistFanart2 { get; set; }
            //public string strArtistFanart3 { get; set; }
            //public string strArtistFanart4 { get; set; }
            public string strArtistBanner { get; set; }
            //public string strMusicBrainzID { get; set; }
            //public object strISNIcode { get; set; }
            //public string strLastFMChart { get; set; }
            //public string intCharted { get; set; }
            //public string strLocked { get; set; }
        }

}

