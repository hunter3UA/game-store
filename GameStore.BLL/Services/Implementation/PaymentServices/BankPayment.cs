﻿using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GameStore.BLL.Services.Abstract;
using GameStore.DAL.Entities;
using GameStore.DAL.UoW.Abstract;

namespace GameStore.BLL.Services.Implementation.PaymentServices
{
    public class BankPayment : IPaymentStrategy
    {
        private IUnitOfWork _unitOfWork;
        private const string INVOICE_DIRECTORY = "\\Invoices";

        public async Task<object> PayAsync(int orderId, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            Order orderToPay = await Initialize(orderId);

            if (orderToPay == null)
            {
                throw new Exception("Order for payment can not be null");
            }

            string filePath = await CreateInvoiceFileAsync(orderToPay);

            orderToPay.Status = OrderStatus.Succeeded;
            await _unitOfWork.SaveAsync();

            return filePath;
        }

        private async Task<Order> Initialize(int orderId)
        {
            Order orderToPay = await _unitOfWork.OrderRepository.GetAsync(o => o.Id == orderId && o.Status == OrderStatus.Processing, od => od.OrderDetails);

            if (orderToPay == null)
            {
                return null;
            }

            foreach (var item in orderToPay.OrderDetails)
            {
                item.Game = await _unitOfWork.GameRepository.GetAsync(g => g.Id == item.GameId);
                if (item.Game == null)
                {
                    orderToPay.Status = OrderStatus.Canceled;
                    await _unitOfWork.SaveAsync();
                    throw new Exception("Some games have been deleted");
                }
            }

            return orderToPay;
        }

        private async Task<string> CreateInvoiceFileAsync(Order orderToPay)
        {
            string path = Directory.GetCurrentDirectory() + INVOICE_DIRECTORY;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string name = $"{orderToPay.Id}{DateTime.UtcNow.Ticks}.txt";
            string fullPath = Path.Combine(path, name);

            decimal total = orderToPay.OrderDetails.Sum(o => o.Price * o.Quantity);

            using (StreamWriter writer = new StreamWriter(fullPath, false))
            {
                await writer.WriteLineAsync($"Order #{orderToPay.Id}\nGames:");

                foreach (var item in orderToPay.OrderDetails)
                {
                    await writer.WriteLineAsync($"Game: {item.Game.Name} - Quantity: {item.Quantity} - Price: {item.Price};");
                }

                await writer.WriteLineAsync($"Total sum: {total}");
            }

            return fullPath;
        }
    }
}
