using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebAppMusic.Client
{
    public class SONGS
    {

        public SONGS()
        {
            ListOfSongs = new List<string>();
        }

        public static List<string> ListOfSongs { get; set; }

        public static void Save()
        {
            string Js = JsonSerializer.Serialize(ListOfSongs);
            File.WriteAllText("songs.json", Js);
        }
        public static void Open()
        {
            var Js = File.ReadAllText("songs.json");
            ListOfSongs = JsonSerializer.Deserialize<List<string>>(Js);
        }


    }
}
