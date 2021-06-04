using LessonWebProject.Common;
using LessonWebProject.Data;
using LessonWebProject.Data.Implementations.Repository;
using LessonWebProject.Data.Interfaces.Repository;
using LessonWebProject.DataUser;
using LessonWebProject.EmailSender;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LessonWebProject.EmailSenderWorkerService
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
                    services.AddDbContext<UserDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
                    services.AddDbContext<EFContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
                    services.AddTransient<IFoundAdsRepository, EFFoundAdsRepository>();
                    services.AddTransient<SenderService>();
                    services.AddHostedService<Worker>();
                });
    }
}
