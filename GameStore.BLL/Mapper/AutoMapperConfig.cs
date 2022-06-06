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
using GameStore.DAL.Entities;

namespace GameStore.BLL.Mapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Game, GameDTO>();
            CreateMap<AddGameDTO, Game>();
            CreateMap<Game, AddGameDTO>();
            CreateMap<UpdateGameDTO, Game>().ForMember((m) => m.Genres, mapper => mapper.Ignore());

            CreateMap<AddCommentDTO, Comment>();
            CreateMap<Comment, CommentDTO>();
            CreateMap<UpdateCommentDTO, Comment>();

            CreateMap<PlatformType, PlatformTypeDTO>();
            CreateMap<AddPlatformTypeDTO, PlatformType>();
            CreateMap<UpdatePlatformTypeDTO, PlatformType>();

            CreateMap<AddGenreDTO, Genre>();
            CreateMap<Genre, GenreDTO>();
            CreateMap<UpdateGenreDTO, Genre>();

            CreateMap<AddPublisherDTO, Publisher>();
            CreateMap<Publisher, PublisherDTO>();
            CreateMap<UpdatePublisherDTO, Publisher>();

            CreateMap<AddOrderDetailsDTO, OrderDetails>();
            CreateMap<OrderDetails, OrderDetailsDTO>();

            CreateMap<Order, OrderDTO>();
        }
    }
}
