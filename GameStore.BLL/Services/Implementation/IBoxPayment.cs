using GameStore.BLL.Services.Abstract;
using GameStore.DAL.Entities;
using GameStore.DAL.UoW.Abstract;
using System;
using System.Threading.Tasks;

namespace GameStore.BLL.Services.Implementation
{
    public class IBoxPayment : IPaymentStrategy
    {
 

        public Task<object> PayAsync(int orderId, IUnitOfWork unitOfWork)
        {
            throw new NotImplementedException();
        }
    }
}
