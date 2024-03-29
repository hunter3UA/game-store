﻿using GameStore.BLL.DTO.Game;
using GameStore.BLL.Enum;
using GameStore.DAL.Entities.Games;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GameStore.BLL.Services.Abstract.Games
{
    public interface IGameFilterService
    {
        Task<List<Expression<Func<Game, bool>>>> GetFiltersForGameStore(GameFilterDTO gameFilterDTO);

        List<Game> FilterByPlatforms(List<Game> gamesToFilter, List<int> platforms);

        Expression<Func<Game, object>> Sort(SortingType sortingType);
    }
}
