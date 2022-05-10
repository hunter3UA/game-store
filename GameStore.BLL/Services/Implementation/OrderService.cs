using AutoMapper;
using GameStore.BLL.DTO.Order;
using GameStore.BLL.DTO.OrderDetails;
using GameStore.BLL.Services.Abstract;
using GameStore.DAL.Entities;
using GameStore.DAL.UoW.Abstract;
using System.Threading.Tasks;

namespace GameStore.BLL.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<OrderDetailsDTO> AddOrderDetailsAsync(string gameKey, AddOrderDetailsDTO addOrderDetailsDTO)
        {
            Game gameOfDetails = await _unitOfWork.GameRepository.GetAsync(g => g.Key == gameKey);
            if (gameOfDetails.UnitsInStock <= 0)
                return null;

            Order orderOfCustomer = await _unitOfWork.OrderRepository.GetAsync(g => g.CustomerId == addOrderDetailsDTO.CustomerId);
            if (orderOfCustomer == null)
            {
                orderOfCustomer = new Order { CustomerId = 1 };
                orderOfCustomer = await _unitOfWork.OrderRepository.AddAsync(orderOfCustomer);
            }
            OrderDetails mappedDetails = _mapper.Map<OrderDetails>(addOrderDetailsDTO);
            mappedDetails.GameId = gameOfDetails.Id;
            mappedDetails.Discount = 0;
            mappedDetails.OrderId = orderOfCustomer.Id;

            var addedDetails = await _unitOfWork.OrderDetailsRepository.AddAsync(mappedDetails);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<OrderDetailsDTO>(addedDetails);
        }

        public async Task<OrderDetailsDTO> ChangeQuantityOfDetails(ChangeQuantityDTO changeQuantityDTO)
        {
            OrderDetails orderDetailsToUpdate = await _unitOfWork.OrderDetailsRepository.GetAsync(o => o.Id == changeQuantityDTO.OrderDetailsId,g=>g.Game);
            orderDetailsToUpdate.Quantity += changeQuantityDTO.Quantity;

            if (orderDetailsToUpdate.Quantity > orderDetailsToUpdate.Game.UnitsInStock) 
            {
                return null;
            }
            await _unitOfWork.SaveAsync();

            return _mapper.Map<OrderDetailsDTO>(orderDetailsToUpdate);
        }

        public async Task<OrderDTO> GetOrderAsync()
        {
            Order orderByCustomer = await _unitOfWork.OrderRepository.GetAsync(o => o.CustomerId == 1, details=>details.OrderDetails);

            return _mapper.Map<OrderDTO>(orderByCustomer);
        }
    }
}
