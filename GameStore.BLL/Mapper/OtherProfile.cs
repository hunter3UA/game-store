using AutoMapper;
using GameStore.BLL.DTO.Shipper;
using GameStore.DAL.Entities.Northwind;

namespace GameStore.BLL.Mapper
{
    public class OtherProfile : Profile
    {
        public OtherProfile()
        {
            CreateMap<Shipper, ShipperDTO>();
        }
    }
}
