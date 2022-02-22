using GameStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GameStore.DAL.Repositories.Abstract
{
    public interface IGameRepository
    {
        Task<Game> AddAsync(Game gameToAdd);
        Task<Game> GetAsync(Expression<Func<Game, bool>> predicate);
        Task<List<Game>> GetListAsync();
    }
}
