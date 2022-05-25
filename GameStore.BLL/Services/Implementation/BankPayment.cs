using GameStore.BLL.Services.Abstract;
using GameStore.DAL.Entities;
using GameStore.DAL.UoW.Abstract;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.BLL.Services.Implementation
{
    public class BankPayment : IPaymentStrategy
    {
        private IUnitOfWork _unitOfWork;

        public async Task<object> PayAsync(int orderId,IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            Order orderToPay = await Initialize(orderId);

            if(orderToPay==null)
            {
                throw new NullReferenceException("Order for payment can not be null");
            }

            string filePath =  await CreateInvoiceFileAsync(orderToPay);
       
            return filePath;
        }

        private async Task<Order> Initialize(int orderId)
        {
            Order orderToPay = await _unitOfWork.OrderRepository.GetAsync(o => o.Id == orderId, od => od.OrderDetails);
            foreach (var item in orderToPay.OrderDetails)
            {
                item.Game = await _unitOfWork.GameRepository.GetAsync(g => g.Id == item.GameId);
            }

            return orderToPay;
        }

        private async Task<string> CreateInvoiceFileAsync(Order orderToPay)
        {
            string path = Directory.GetCurrentDirectory()+"\\Invoices";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string name = $"{orderToPay.Id}{DateTime.Now.Ticks}.txt";
            string fullPath = Path.Combine(path, name);

            decimal total = orderToPay.OrderDetails.Sum(o => o.Price * o.Quantity);

            using (StreamWriter writer = new StreamWriter(fullPath, false))
            {
                await writer.WriteLineAsync($"Order #{orderToPay.Id}\nGames:");
                
                foreach(var item in orderToPay.OrderDetails)
                {
                    await writer.WriteLineAsync($"Game: {item.Game.Name} - Quantity: {item.Quantity} - Price: {item.Price};");
                }

                await writer.WriteLineAsync($"Total sum: {total}");
            }

            return fullPath;
        }
    }
}
