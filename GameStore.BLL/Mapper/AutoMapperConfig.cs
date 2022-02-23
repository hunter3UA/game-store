using AutoMapper;
using GameStore.BLL.DTO;
using GameStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.BLL.Mapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration Configure()
        {
            MapperConfiguration config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<Game, GameDTO>();
                    cfg.CreateMap<AddGameDTO, Game>();
                    cfg.CreateMap<Game, AddGameDTO>();
                    cfg.CreateMap<PlatformType, PlatformDTO>();
                    cfg.CreateMap<AddCommentDTO,Comment>();
                    cfg.CreateMap<Comment, CommentDTO>();
                    cfg.CreateMap<Genre, GenreDTO>();
                });
            return config;
        }
    }
}
