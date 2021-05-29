using LessonWebProject.Common;
using LessonWebProject.Data;
using LessonWebProject.Data.Repository.Implementations;
using LessonWebProject.Data.Repository.Interfaces;
using LessonWebProject.EmailSender;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessonWebProject.EmailSenderWorkerService
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
                    services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(CommonStaticParameters.ConnectionString));
                    services.AddDbContext<EFDBFoundAdContext>(options => options.UseSqlServer(CommonStaticParameters.ConnectionString));
                    services.AddTransient<IFoundAdsRepository, EFFoundAdsRepository>();
                    services.AddTransient<SenderService>();
                    services.AddHostedService<Worker>();
                });
    }
}
