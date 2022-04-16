using GameStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.DAL.Repositories.Abstract
{
    public interface IGenreRepository
    {
        Task<Genre> AddGenreAsync(Genre genreToAdd);
        Task<Genre> GetGenreAsync(Expression<Func<Genre, bool>> predicate);
        Task<List<Genre>> GetListOfGenresAsync(Expression<Func<Genre, bool>> predicate);
        Task<List<Genre>> GetListOfGenresAsync();
        Task<bool> RemoveGenreAsync(int key);

    }
}
