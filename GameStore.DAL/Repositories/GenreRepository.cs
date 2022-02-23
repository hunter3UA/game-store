using GameStore.DAL.Models;
using GameStore.DAL.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.DAL.Repositories
{
    public class GenreRepository:IGenreRepository
    {
        private readonly StoreDbContext _dbContext;

        public GenreRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Genre> AddAsync(Genre newGenre)
        {
            await _dbContext.Genres.AddAsync(newGenre);
            return newGenre;
        }
        public async Task<List<Genre>> GetListAsync(Expression<Func<Genre, bool>> predicate)
        {
            return await _dbContext.Genres.Where(predicate).ToListAsync();
        }
       
        public async Task<List<Genre>> GetListAsync()
        {
            return await _dbContext.Genres.ToListAsync();
        }
        public async Task<Genre> GetAsync(Expression<Func<Genre, bool>> predicate)
        {
            return await _dbContext.Genres.FirstOrDefaultAsync(predicate);
        }
    }
}
