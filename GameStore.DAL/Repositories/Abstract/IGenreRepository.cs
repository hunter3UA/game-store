using GameStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GameStore.DAL.Repositories.Abstract
{
    public interface IGenreRepository
    {
        Task<Genre> GetAsync(Expression<Func<Genre, bool>> predicate);
        Task<List<Genre>> GetListAsync(Expression<Func<Genre, bool>> predicate);
    }
}
