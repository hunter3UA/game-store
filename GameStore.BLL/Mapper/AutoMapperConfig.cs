using AutoMapper;
using GameStore.BLL.DTO;
using GameStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.BLL.Mapper
{
    public class AutoMapperConfig:Profile
    {

        public AutoMapperConfig()
        {
            CreateMap<Game, GameDTO>();
            CreateMap<AddGameDTO, Game>();
            CreateMap<Game, AddGameDTO>();
            CreateMap<PlatformType, PlatformDTO>();
            CreateMap<AddCommentDTO, Comment>();
            CreateMap<Comment, CommentDTO>();
            CreateMap<Genre, GenreDTO>();
            CreateMap<UpdateGameDTO, Game>();
        }

        
    }
}
