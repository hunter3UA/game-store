using AutoMapper;
using GameStore.BLL.DTO;
using GameStore.BLL.DTO.Auth;
using GameStore.BLL.DTO.Comment;
using GameStore.BLL.DTO.Game;
using GameStore.BLL.DTO.Genre;
using GameStore.BLL.DTO.Order;
using GameStore.BLL.DTO.OrderDetails;
using GameStore.BLL.DTO.Platform;
using GameStore.BLL.DTO.PlatformType;
using GameStore.BLL.DTO.Publisher;
using GameStore.BLL.DTO.Shipper;
using GameStore.BLL.DTO.User;
using GameStore.DAL.Entities.Games;
using GameStore.DAL.Entities.GameStore;
using GameStore.DAL.Entities.Genres;
using GameStore.DAL.Entities.Platforms;
using GameStore.DAL.Entities.Publishers;
using System;
using System.Linq;

namespace GameStore.BLL.Mapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Game, GameDTO>();
            CreateMap<AddGameDTO, Game>()
                .ForMember(m => m.PublishedAt, mapper => mapper.MapFrom(p => DateTime.Parse(p.PublishedAt))).ReverseMap();
            CreateMap<Game, AddGameDTO>();
            CreateMap<UpdateGameDTO, Game>()
                .ForMember((m) => m.Genres, mapper => mapper.Ignore())
                .ForMember(m => m.PublishedAt, mapper => mapper.MapFrom(p => DateTime.Parse(p.PublishedAt)))
                .ForMember(m => m.Key, mapper => mapper.MapFrom(g => g.NewGameKey));
            CreateMap<UpdateGameDTO, AddGameDTO>().ForMember(m => m.Key, mapper => mapper.MapFrom(m => m.NewGameKey));

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
            CreateMap<Publisher, PublisherDTO>();
            CreateMap<UpdatePublisherDTO, Publisher>();

            CreateMap<AddOrderDetailsDTO, OrderDetails>();
            CreateMap<OrderDetails, OrderDetailsDTO>();
            CreateMap<OrderDetailsDTO, OrderDetails>().ForMember(od => od.Game, mapper => mapper.Ignore());

            CreateMap<Order, OrderDTO>();
            CreateMap<UpdateOrderDTO, Order>().ForMember(o => o.OrderDetails, mapper => mapper.Ignore());

            CreateMap<Shipper, ShipperDTO>();

            CreateMap<RegisterDTO, User>();
            CreateMap<User, UserDTO>();

            CreateMap<GameTranslateDTO, GameTranslate>().ReverseMap();
            CreateMap<GenreTranslateDTO, GenreTranslate>().ReverseMap();
            CreateMap<PlatformTypeTranslateDTO, PlatformTypeTranslate>().ReverseMap();
            CreateMap<PublisherTranslateDTO, PublisherTranslate>().ReverseMap();
        }
    }
}
