using LessonWebProject.Data;
using LessonWebProject.Data.Implementations.Repository;
using LessonWebProject.Data.Interfaces.Repository;
using LessonWebProject.TelegramAgentService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Primitives;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace LessonWebProject.TelegramAgentWorker
{
    public class Program
    {
        public static IConfiguration Configuration { get; private set; }
        public static void Main(string[] args)
        {
            BuildConfiguration();
            CreateHostBuilder(args).Build().Run();
        }
        private static void BuildConfiguration()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            Configuration = builder.Build();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
              Host.CreateDefaultBuilder(args)
                  .ConfigureServices((hostContext, services) =>
                  {
                      services.AddDbContext<EFContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
                      services.AddTransient<IAdsRepository, AdsRepository>();
                      services.Configure<BotConfiguration>(Configuration.GetSection("BotConfiguration"));
                      services.AddTransient<AgentService>();
                      services.AddHostedService<Worker>();
                  });
    }
}
