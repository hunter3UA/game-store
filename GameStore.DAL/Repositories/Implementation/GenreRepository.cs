using GameStore.DAL.Context;
using GameStore.DAL.Entities;
using GameStore.DAL.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.DAL.Repositories.Implementation
{
    public class GenreRepository:IGenreRepository
    {
        private readonly StoreDbContext _dbContext;

        public GenreRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Genre> AddGenreAsync(Genre newGenre)
        {
            var addedGenre = await _dbContext.Genres.AddAsync(newGenre);
            return addedGenre.Entity;
            
        }
        public async Task<List<Genre>> GetListOfGenresAsync(Expression<Func<Genre, bool>> predicate)
        {
            return await _dbContext.Genres.Where(predicate).ToListAsync();
        }

        public async Task<List<Genre>> GetListOfGenresAsync()
        {
            return await _dbContext.Genres.ToListAsync();
        }
        public async Task<Genre> GetGenreAsync(Expression<Func<Genre, bool>> predicate)
        {
            return await _dbContext.Genres.FirstOrDefaultAsync(predicate);
        }

    }
}
