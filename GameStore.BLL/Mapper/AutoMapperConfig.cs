using AutoMapper;
using GameStore.BLL.DTO;
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
            CreateMap<PlatformType, PlatformTypeDTO>();
            CreateMap<AddCommentDTO, Comment>();
            CreateMap<Comment, CommentDTO>();
            CreateMap<Genre, GenreDTO>();
            CreateMap<UpdateGameDTO, Game>();
            CreateMap<AddPlatformTypeDTO, PlatformType>();
            CreateMap<AddGenreDTO, Genre>();
        }
    }
}
