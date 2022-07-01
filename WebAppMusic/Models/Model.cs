using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMusic.Models
{


    public class Model
    {
        public string query { get; set; }
        public Tracks tracks { get; set; }
    }

    public class Tracks
    {
        public int totalCount { get; set; }
        public List<Item> items { get; set; }
        public Paginginfo pagingInfo { get; set; }
    }

    public class Paginginfo
    {
        public int nextOffset { get; set; }
        public int limit { get; set; }
    }

    public class Item
    {
        public Data data { get; set; }
    }

    public class Data
    {
        public string uri { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public Albumoftrack albumOfTrack { get; set; }
        public Artists artists { get; set; }
        public Contentrating contentRating { get; set; }
        public Duration duration { get; set; }
        public Playability playability { get; set; }
    }

    public class Albumoftrack
        {
            public string uri { get; set; }
            public string name { get; set; }
            public Coverart coverArt { get; set; }
            public string id { get; set; }
            public Sharinginfo sharingInfo { get; set; }
         }

        public class Coverart
        {
            public Source[] sources { get; set; }
        }

        public class Source
        {
            public string url { get; set; }
            public int width { get; set; }
            public int height { get; set; }
        }

    public class Sharinginfo
    {
        public string shareUrl { get; set; }
    }

    public class Artists
        {
            public Item1[] items { get; set; }
        }

        public class Item1
        {
            public string uri { get; set; }
            public Profile profile { get; set; }
        }

        public class Profile
        {
            public string name { get; set; }
        }

    public class Contentrating
    {
        public string label { get; set; }
    }

    public class Duration
    {
        public int totalMilliseconds { get; set; }
    }

    public class Playability
    {
        public bool playable { get; set; }
    }




}
