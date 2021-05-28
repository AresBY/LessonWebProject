using Common;
using LessonWebProject.Crawler;
using LessonWebProject.Data;
using LessonWebProject.Data.Repository.Implementations;
using LessonWebProject.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessonWebProject.CrawlerWorkerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddDbContext<EFDBUserTaskContext>(options => options.UseSqlServer(Parameters.ConnectionString));
                    services.AddDbContext<EFDBFoundAdContext>(options => options.UseSqlServer(Parameters.ConnectionString));
                    services.AddTransient<IUserTaskRepository, EFUserTaskRepository>();
                    services.AddTransient<IFoundAdsRepository, EFFoundAdsRepository>();
                    services.AddTransient<CrawlerService>();
                    services.AddHostedService<Worker>();
                });
    }
}


