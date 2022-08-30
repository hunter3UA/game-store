using AutoMapper;
using GameStore.BLL.DTO.Game;
using GameStore.DAL.Entities.Games;
using GameStore.DAL.Entities.Northwind;
using System;

namespace GameStore.BLL.Mapper
{
    public class GameProfile:Profile
    {
        public GameProfile()
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
            CreateMap<Product, Game>().ReverseMap();
        }
    }
}
