using LessonWebProject.Crawler;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LessonWebProject.CrawlerWorkerService
{
    public class Worker : BackgroundService
    {
        private readonly IServiceScopeFactory _services;
        public Worker(IServiceScopeFactory services)
        {
            _services = services;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = _services.CreateScope())
            {
                var myScopedService = scope.ServiceProvider.GetRequiredService<CrawlerService>();
                while (!stoppingToken.IsCancellationRequested)
                {
                    myScopedService.DoSearching();
                    await Task.Delay(3000, stoppingToken);
                }
            }
        }
    }
}
