using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMusic.Models
{
    public class MusicResponce
    {
        public List <Item> items;
        public int totalCoiunt { get; set; }
        public string Uri { get; set; }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Alburi { get; set; }
        public string AlbName { get; set; }
        public string AlbId { get; set; }

        public string SourceUrl { get; set; }
        public int width { get; set; }
        public int height { get; set; }


        public string ProfName { get; set; }
        public int totaltime { get; set; }
        

    }
}
