using AutoMapper;
using GameStore.BLL.DTO.Game;
using GameStore.BLL.DTO.Genre;
using GameStore.BLL.DTO.Platform;
using GameStore.BLL.DTO.Publisher;
using GameStore.DAL.Entities.Games;
using GameStore.DAL.Entities.Genres;
using GameStore.DAL.Entities.Platforms;
using GameStore.DAL.Entities.Publishers;

namespace GameStore.BLL.Mapper
{
    public class TranslationsProfile : Profile
    {
        public TranslationsProfile()
        {

            CreateMap<GameTranslateDTO, GameTranslate>().ReverseMap();
            CreateMap<GenreTranslateDTO, GenreTranslate>().ReverseMap();
            CreateMap<PlatformTypeTranslateDTO, PlatformTypeTranslate>().ReverseMap();
            CreateMap<PublisherTranslateDTO, PublisherTranslate>().ReverseMap();
        }
    }
}
