using GameStore.BLL.DTO.Game;
using GameStore.BLL.Enum;
using GameStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GameStore.BLL.Services.Abstract.Games
{
    public interface IGameFilterService
    {
        Task<List<Expression<Func<Game, bool>>>> GetFiltersForGameStore(GameFilterDTO gameFilterDTO);

        Task<List<Expression<Func<Game, bool>>>> GetFiltersForNorthwind(GameFilterDTO gameFilterDTO);

        Expression<Func<Game, object>> Sort(SortingType sortingType);
    }
}
