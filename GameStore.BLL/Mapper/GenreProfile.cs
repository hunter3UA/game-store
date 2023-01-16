using AutoMapper;
using GameStore.BLL.DTO.Genre;
using GameStore.DAL.Entities.Genres;

namespace GameStore.BLL.Mapper
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<AddGenreDTO, Genre>();
            CreateMap<Genre, GenreDTO>().ReverseMap();
            CreateMap<UpdateGenreDTO, Genre>();
        }
    }
}
