using AutoMapper;
using GameStore.BLL.DTO;
using GameStore.BLL.DTO.Comment;
using GameStore.BLL.DTO.Game;
using GameStore.BLL.DTO.Genre;
using GameStore.BLL.DTO.Order;
using GameStore.BLL.DTO.OrderDetails;
using GameStore.BLL.DTO.Platform;
using GameStore.BLL.DTO.PlatformType;
using GameStore.BLL.DTO.Publisher;
using GameStore.BLL.DTO.Shipper;
using GameStore.DAL.Entities;
using System;
using System.Linq;

namespace GameStore.BLL.Mapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Game, GameDTO>().ForMember(m => m.ObjectId, mapper => mapper.MapFrom(p => p.ObjectId.ToString()));
            CreateMap<AddGameDTO, Game>()
                .ForMember(m => m.PublishedAt, mapper => mapper.MapFrom(p => DateTime.Parse(p.PublishedAt)));
            CreateMap<Game, AddGameDTO>();
            CreateMap<UpdateGameDTO, Game>().ForMember((m) => m.Genres, mapper => mapper.Ignore()).ForMember(m => m.PublishedAt, mapper => mapper.MapFrom(p => DateTime.Parse(p.PublishedAt)));
            CreateMap<UpdateGameDTO, AddGameDTO>();

            CreateMap<AddCommentDTO, Comment>();
            CreateMap<Comment, CommentDTO>();
            CreateMap<UpdateCommentDTO, Comment>();

            CreateMap<PlatformType, PlatformTypeDTO>();
            CreateMap<AddPlatformTypeDTO, PlatformType>();
            CreateMap<UpdatePlatformTypeDTO, PlatformType>();

            CreateMap<AddGenreDTO, Genre>();
            CreateMap<Genre, GenreDTO>().ReverseMap();
            CreateMap<UpdateGenreDTO, Genre>();

            CreateMap<AddPublisherDTO, Publisher>();
            CreateMap<Publisher, PublisherDTO>().ForMember(p => p.ObjectId, mapper => mapper.MapFrom(p => p.ObjectId.ToString()));
            CreateMap<UpdatePublisherDTO, Publisher>();

            CreateMap<AddOrderDetailsDTO, OrderDetails>();
            CreateMap<OrderDetails, OrderDetailsDTO>();

            CreateMap<Order, OrderDTO>();
            CreateMap<UpdateOrderDTO, Order>();

            CreateMap<Shipper, ShipperDTO>();
        }
    }
}
