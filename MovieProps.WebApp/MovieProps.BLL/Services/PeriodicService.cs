using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovieProps.BLL.Contract.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProps.BLL.Services
{
    public class PeriodicService : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScope;

        public PeriodicService(IServiceScopeFactory serviceScope)
        {
            _serviceScope = serviceScope;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = _serviceScope.CreateScope())
            {
                while (!stoppingToken.IsCancellationRequested)
                {
    
                    var _orderHandling = scope.ServiceProvider.GetService<IOrderHandling>();
                    await _orderHandling.UpdateOrderDelivery();

                    await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
                    
                }
            }
            
        }
    }
}
