using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using TaskManagerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace TaskManagerApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var webhost = CreateWebHostBuilder(args).Build();
            using (var scope = webhost.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<TaskManagerAppContext>();
                db.Database.Migrate();
            }

            await webhost.RunAsync();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
