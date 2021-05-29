using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LessonWebProject.EmailSenderWorkerService
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
                var myScopedService = scope.ServiceProvider.GetRequiredService<EmailSender.SenderService>();
                while (!stoppingToken.IsCancellationRequested)
                {
                    myScopedService.DoSending();
                    await Task.Delay(10000, stoppingToken);
                }
            }
        }
    }
}
