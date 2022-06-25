using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMusic.Models
{
    public class UserDbRepository
    {
        public string Tid { get; set; }
        public string ArtistName { get; set; }
        public string SongName { get; set; }
        public string SpotUrl { get; set; }
    }
}
