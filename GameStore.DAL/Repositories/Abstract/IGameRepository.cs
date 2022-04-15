using GameStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.DAL.Repositories.Abstract
{
    public interface IGameRepository
    {
        Task<Game> AddGameAsync(Game gameToAdd);
        Task<Game> GetGameAsync(Expression<Func<Game, bool>> predicate);
        Task<List<Game>> GetListOfGamesAsync();
        Task<bool> RemoveGameAsync(int key);

    }
}
