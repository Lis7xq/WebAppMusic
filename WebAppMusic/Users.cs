using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WebAppMusic.Models;

namespace WebAppMusic
{
    public class Users
    {
        public Users()
        {
            ListOfUsers = new Dictionary<string, List<MusicResponce>>();
            LastSearch = new Dictionary<string, MusicResponce>();
        }



        public static Dictionary<string,List<MusicResponce>> ListOfUsers { get; set; }
        public static Dictionary<string, MusicResponce> LastSearch { get; set; }

        public static void Save()
        {
            string Js = JsonSerializer.Serialize(ListOfUsers);
            File.WriteAllText("user.json", Js);
        }
        public static void Open()
        {
            var Js = File.ReadAllText("user.json");
            ListOfUsers = JsonSerializer.Deserialize<Dictionary<string, List<MusicResponce>>>(Js);
        }


    }


}
