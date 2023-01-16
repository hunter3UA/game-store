using AutoMapper;
using GameStore.BLL.DTO.OrderDetails;
using GameStore.DAL.Entities.GameStore;

namespace GameStore.BLL.Mapper
{
    public class OrderDetailsProfile : Profile
    {
        public OrderDetailsProfile()
        {
            CreateMap<AddOrderDetailsDTO, OrderDetails>();
            CreateMap<OrderDetails, OrderDetailsDTO>();
            CreateMap<OrderDetailsDTO, OrderDetails>().ForMember(od => od.Game, mapper => mapper.Ignore());
        }
    }
}
