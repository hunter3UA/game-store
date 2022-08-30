using AutoMapper;
using GameStore.BLL.DTO.Publisher;
using GameStore.DAL.Entities.Northwind;
using GameStore.DAL.Entities.Publishers;

namespace GameStore.BLL.Mapper
{
    public class PublisherProfile : Profile
    {
        public PublisherProfile()
        {
            CreateMap<AddPublisherDTO, Publisher>();
            CreateMap<Publisher, PublisherDTO>();
            CreateMap<UpdatePublisherDTO, Publisher>();
            CreateMap<Supplier,Publisher>().ReverseMap();
        }
    }
}
