using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMusic.Client;

namespace WebAppMusic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Users.LastSearch = new Dictionary<string, Models.MusicResponce>();
            Users.ListOfUsers = new Dictionary<string, List<Models.MusicResponce>>();
            try
            {
                Users.Open();
            }
            catch { Users.Save(); Users.Open(); }

            CreateHostBuilder(args).Build().Run();
            
           
           
            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        
    }
}
