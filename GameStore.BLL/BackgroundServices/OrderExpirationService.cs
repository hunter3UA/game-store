using Calabonga.Microservices.BackgroundWorkers;
using GameStore.BLL.Services.Abstract;
using GameStore.DAL.Entities;
using GameStore.DAL.UoW.Abstract;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GameStore.BLL.BackgroundServices
{
    public class OrderExpirationService : ScheduledHostedServiceBase
    {

        public OrderExpirationService(IServiceScopeFactory serviceScopeFactory, ILogger<OrderExpirationService> _logger) : base(serviceScopeFactory, _logger)
        {
        }

        protected override string Schedule => "* * * * *";

        protected override string DisplayName => "OrderExpirationService";

        protected override bool IsExecuteOnServerRestart => true;

        protected override async Task ProcessInScopeAsync(IServiceProvider serviceProvider, CancellationToken token)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                IUnitOfWork unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                IOrderService orderService = scope.ServiceProvider.GetRequiredService<IOrderService>();

                IEnumerable<Order> orders = await unitOfWork.OrderRepository.GetRangeAsync(o => o.Status == OrderStatus.Processing && o.Expiration < DateTime.UtcNow);
                foreach (var item in orders)
                {
                    await orderService.CancelOrderAsync(item.Id);
                }
            }

        }
    }
}
