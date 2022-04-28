using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GameStore.DAL.Entities;

namespace GameStore.DAL.Repositories.Abstract
{
    public interface IGameRepository
    {
        Task<Game> AddGameAsync(Game gameToAdd);

        Task<Game> GetGameAsync(Expression<Func<Game, bool>> predicate);

        Task<Game> UpdateGameAsync(Game gameToUpdate);

        Task<List<Game>> GetListOfGamesAsync();

        Task<bool> RemoveGameAsync(string key);
    }
}
