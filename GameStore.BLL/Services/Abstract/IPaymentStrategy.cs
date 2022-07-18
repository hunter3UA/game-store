﻿using GameStore.BLL.Providers;
using GameStore.DAL.Context.Abstract;
using GameStore.DAL.UoW.Abstract;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace GameStore.BLL.Services.Abstract
{
    public interface IPaymentStrategy
    {
        Task<object> PayAsync(int orderId, IUnitOfWork unitOfWork, INorthwindDbContext _northwindDbContext);
    }
}
