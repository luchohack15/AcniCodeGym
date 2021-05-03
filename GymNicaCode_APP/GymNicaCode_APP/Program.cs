using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymNicaCode_Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using GymNicaCode_Dominio;

namespace GymNicaCode_APP
{
    public class Program
    {
        public static  void Main(string[] args)
        {
           var hostserver= CreateHostBuilder(args).Build();
            using (var ambiente = hostserver.Services.CreateScope())
            {
                var services = ambiente.ServiceProvider;
                try
                {
                    var userManager = services.GetRequiredService<UserManager<Usuario>>();
                    var context = services.GetRequiredService<GymNicaCodeContext>();
                    context.Database.Migrate();
                    DataPrueba.InsertarData(context, userManager).Wait();

                }
                catch (Exception e)
                {
                   
                    var logging = services.GetRequiredService<ILogger<Program>>();
                    logging.LogError(e, "Ocurrio en la migracion");
                }     
            }
            hostserver.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
