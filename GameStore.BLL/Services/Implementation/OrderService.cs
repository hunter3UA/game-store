using System.Threading.Tasks;
using AutoMapper;
using Castle.Core.Logging;
using GameStore.BLL.DTO.Order;
using GameStore.BLL.DTO.OrderDetails;
using GameStore.BLL.Services.Abstract;
using GameStore.DAL.Entities;
using GameStore.DAL.UoW.Abstract;
using Microsoft.Extensions.Logging;

namespace GameStore.BLL.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<OrderService> _logger;

        public OrderService(IMapper mapper, IUnitOfWork unitOfWork, ILogger<OrderService> logger)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<OrderDetailsDTO> AddOrderDetailsAsync(string gameKey, int customerId)
        {
            Game gameOfDetails = await _unitOfWork.GameRepository.GetAsync(g => g.Key == gameKey);
            if (gameOfDetails.UnitsInStock <= 0)
            {
                return null;
            }

            Order orderOfCustomer = await _unitOfWork.OrderRepository.GetAsync(g => g.CustomerId == customerId);
            if (orderOfCustomer == null)
            {
                orderOfCustomer = await CreateOrder();
            }

            OrderDetails orderItemToAdd = await _unitOfWork.OrderDetailsRepository.GetAsync(od => od.OrderId == orderOfCustomer.Id && od.GameId == gameOfDetails.Id);
            if (orderItemToAdd != null)
            {
                return null;
            }

            OrderDetails addedOrderDetails = await CreateOrderDetails(orderOfCustomer.Id, gameOfDetails.Id, gameOfDetails.Price);

            return _mapper.Map<OrderDetailsDTO>(addedOrderDetails);
        }

        public async Task<OrderDetailsDTO> ChangeQuantityOfDetailsAsync(ChangeQuantityDTO changeQuantityDTO)
        {
            OrderDetails orderDetailsToUpdate = await _unitOfWork.OrderDetailsRepository.GetAsync(o => o.Id == changeQuantityDTO.OrderDetailsId, g => g.Game);
            orderDetailsToUpdate.Quantity = (short)changeQuantityDTO.Quantity;

            if (orderDetailsToUpdate.Quantity > orderDetailsToUpdate.Game.UnitsInStock || orderDetailsToUpdate.Quantity < 0)
            {
                return null;
            }

            await _unitOfWork.SaveAsync();

            return _mapper.Map<OrderDetailsDTO>(orderDetailsToUpdate);
        }

        public async Task<bool> RemoveOrderDetailsAsync(int id)
        {
            bool isDeletedOrderDetails = await _unitOfWork.OrderDetailsRepository.RemoveAsync(od => od.Id == id);
            await _unitOfWork.SaveAsync();

            return isDeletedOrderDetails;
        }

        public async Task<OrderDTO> GetOrderAsync()
        {
            Order orderByCustomer = await _unitOfWork.OrderRepository.GetAsync(o => o.CustomerId == 1, details => details.OrderDetails);
            foreach (var item in orderByCustomer.OrderDetails)
            {
                item.Game = await _unitOfWork.GameRepository.GetAsync(g => g.Id == item.GameId);
            }

            return _mapper.Map<OrderDTO>(orderByCustomer);
        }

        private async Task<Order> CreateOrder()
        {
            Order orderToAdd = new Order()
            {
                CustomerId = 1
            };

            Order addedOrder = await _unitOfWork.OrderRepository.AddAsync(orderToAdd);
            await _unitOfWork.SaveAsync();

            if (addedOrder != null)
            {
                _logger.LogInformation($"Order with id: {addedOrder.Id} has been added");
            }

            return addedOrder;
        }

        private async Task<OrderDetails> CreateOrderDetails(int orderId, int gameId, decimal price)
        {
            OrderDetails orderDetailsToAdd = new OrderDetails()
            {
                Price = price,
                OrderId = orderId,
                Quantity = 1,
                GameId = gameId,
                Discount = 0
            };

            OrderDetails addedOrderDetails = await _unitOfWork.OrderDetailsRepository.AddAsync(orderDetailsToAdd);
            await _unitOfWork.SaveAsync();

            if (addedOrderDetails != null)
            {
                _logger.LogInformation($"OrderDetails with id: {addedOrderDetails.Id} has been added");
            }

            return addedOrderDetails;
        }
    }
}
