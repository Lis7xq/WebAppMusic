using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMusic.Models
{
    
    
        public class Lmodel
        {
            public Lyrics lyrics { get; set; }
        }

        public class Lyrics
        {
            public string syncType { get; set; }
            public Line[] lines { get; set; }
            public string provider { get; set; }
            public string providerLyricsId { get; set; }
            public string providerDisplayName { get; set; }
            public string syncLyricsUri { get; set; }
            public bool isDenseTypeface { get; set; }
            public object[] alternatives { get; set; }
            public string language { get; set; }
            public bool isRtlLanguage { get; set; }
            public string fullscreenAction { get; set; }
        }

        public class Line
        {
            public string startTimeMs { get; set; }
            public string words { get; set; }
            public object[] syllables { get; set; }
        }
    
}
