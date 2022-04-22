using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GameStore.BLL.DTO;
using GameStore.DAL.Entities;

namespace GameStore.BLL.Services.Abstract
{
    public interface IGameService
    {
        Task<GameDTO> AddGameAsync(AddGameDTO gameToAddDTO);
        
        Task<List<GameDTO>> GetListOfGamesAsync();

        Task<GameDTO> GetGameAsync(Expression<Func<Game, bool>> predicate);

        Task<bool> RemoveGameAsync(string key);

        Task<GameDTO> UpdateGameAsync(UpdateGameDTO updateGameDTO); 
    }
}
