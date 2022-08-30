using GameStore.BLL.DTO.Game;
using GameStore.BLL.Enum;
using GameStore.DAL.Entities.Games;
using GameStore.DAL.Entities.Northwind;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GameStore.BLL.Services.Abstract.Games
{
    public interface IGameFilterService
    {
        Task<List<Expression<Func<Game, bool>>>> GetFiltersForGameStore(GameFilterDTO gameFilterDTO);

        Task<List<Expression<Func<Product, bool>>>> GetFiltersForNorthwind(GameFilterDTO gameFilterDTO);

        List<Game> FilterByPlatforms(List<Game> gamesToFilter, List<int> platforms);

        Expression<Func<Game, object>> Sort(SortingType sortingType);
    }
}
