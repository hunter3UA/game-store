using GameStore.BLL.DTO.Common;
using GameStore.BLL.DTO.Game;
using GameStore.BLL.Enum;
using GameStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GameStore.BLL.Services.Abstract
{
    public interface IGameFilterService
    {
        Task<List<Expression<Func<Game, bool>>>> GetFilteredGames(GameFilterDTO gameFilterDTO);

        Expression<Func<Game, object>> Sort(SortingType sortingType);

        ItemPageDTO<GameDTO> GetGamePage(List<Game> filteredGames, GameFilterDTO gameFilterDTO);
    }
}
