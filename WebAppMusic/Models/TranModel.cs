using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMusic.Models
{
    public class TranModel
    {

        public class Model
        {
            public int code { get; set; }
            public Data data { get; set; }
            public string message { get; set; }
        }

        public class Data
        {
            public string translation { get; set; }
            public string pronunciation { get; set; }
            public Pair[] pairs { get; set; }
            public Source source { get; set; }
        }

        public class Source
        {
            public Language language { get; set; }
            public Text text { get; set; }
        }

        public class Language
        {
            public bool didYouMean { get; set; }
            public string iso { get; set; }
        }

        public class Text
        {
            public bool autoCorrected { get; set; }
            public string value { get; set; }
            public bool didYouMean { get; set; }
        }

        public class Pair
        {
            public string s { get; set; }
            public string t { get; set; }
        }


    }
}
