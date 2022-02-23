using GameStore.BLL.DTO;
using GameStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.BLL.Services.Abstract
{
    public interface IGameService
    {
        Task<GameDTO> AddAsync(AddGameDTO gameToAddDTO);
        Task<List<GameDTO>> GetLisAsync();
        Task<GameDTO> GetAsync(Expression<Func<Game, bool>> predicate);
        Task<bool> RemoveAsync(Expression<Func<Game, bool>> predicate);
        Task<GameDTO> UpdateAsync(UpdateGameDTO updateGameDTO);
    }
}
