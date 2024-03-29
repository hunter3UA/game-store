﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GameStore.BLL.Services.Abstract;
using GameStore.DAL.Entities.GameStore;
using GameStore.DAL.Enums;
using GameStore.DAL.UoW.Abstract;

namespace GameStore.BLL.Services.Implementation.PaymentServices
{
    public class BankPayment : IPaymentStrategy
    {
        private IUnitOfWork _unitOfWork;

        public async Task<object> PayAsync(int orderId, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
  
            Order orderToPay = await Initialize(orderId);
            
            byte[] fileStream = await CreateInvoiceFileAsync(orderToPay);

            orderToPay.Status = OrderStatus.Succeeded;
            await _unitOfWork.SaveAsync();

            return fileStream;
        }

        private async Task<Order> Initialize(int orderId)
        {
            Order orderToPay = await _unitOfWork.OrderRepository.GetAsync(o => o.Id == orderId && o.Status == OrderStatus.Processing, od => od.OrderDetails);

            if (orderToPay == null)
                throw new KeyNotFoundException("Order not found");

            foreach (var item in orderToPay.OrderDetails)
            {
                var gameOfDetails = await _unitOfWork.GameRepository.GetAsync(g => g.Key == item.GameKey);
                if (gameOfDetails == null)
                {
                    orderToPay.Status = OrderStatus.Canceled;
                    await _unitOfWork.SaveAsync();
                    throw new KeyNotFoundException($"Games with id {item.GameKey} not found");
                }
            }

            return orderToPay;
        }

        private async Task<byte[]> CreateInvoiceFileAsync(Order orderToPay)
        {
            decimal total = orderToPay.OrderDetails.Sum(o =>(decimal)o.Price * o.Quantity);
            MemoryStream memoryStream = new MemoryStream();
            using (StreamWriter writer = new StreamWriter(memoryStream))
            {
                await writer.WriteLineAsync($"Order #{orderToPay.Id}\nGames:");

                foreach (var item in orderToPay.OrderDetails)              
                    await writer.WriteLineAsync($"Game: {item.Game.Name} - Quantity: {item.Quantity} - Price: {item.Price};");
    
                await writer.WriteLineAsync($"Total sum: {total}");
            }

            return memoryStream.ToArray();
        }
    }
}
