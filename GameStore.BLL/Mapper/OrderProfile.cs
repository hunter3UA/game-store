using AutoMapper;
using GameStore.BLL.DTO.Order;
using GameStore.DAL.Entities.GameStore;

namespace GameStore.BLL.Mapper
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDTO>();
            CreateMap<UpdateOrderDTO, Order>().ForMember(o => o.OrderDetails, mapper => mapper.Ignore());
            CreateMap<DAL.Entities.Northwind.Order, Order>().ReverseMap();
        }
    }
}
