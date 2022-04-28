using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GameStore.DAL.Entities;

namespace GameStore.DAL.Repositories.Abstract
{
    public interface IGenreRepository
    {
        Task<Genre> AddGenreAsync(Genre genreToAdd);

        Task<Genre> GetGenreAsync(Expression<Func<Genre, bool>> predicate);

        Task<List<Genre>> GetListOfGenresAsync(Expression<Func<Genre, bool>> predicate);

        Task<List<Genre>> GetListOfGenresAsync();

        Task<Genre> UpdateGenreAsync(Genre genreToUpdate);

        Task<bool> RemoveGenreAsync(int id);
    }
}
