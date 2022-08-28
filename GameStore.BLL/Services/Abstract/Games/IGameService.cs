using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GameStore.BLL.DTO.Common;
using GameStore.BLL.DTO.Game;
using GameStore.DAL.Entities.Games;

namespace GameStore.BLL.Services.Abstract.Games
{
    public interface IGameService
    {
        Task<GameDTO> AddGameAsync(AddGameDTO gameToAddDTO);

        Task<GameDTO> GetGameAsync(string gameKey, bool isView);

        Task<bool> RemoveGameAsync(string key);

        Task<GameDTO> UpdateGameAsync(UpdateGameDTO updateGameDTO);

        Task<ItemPageDTO<GameDTO>> GetRangeOfGamesAsync(GameFilterDTO gameFilterDTO);

        Task<int> GetCountAsync();

        Task<Game> SetGameAsync(string gameKey);
    }
}
