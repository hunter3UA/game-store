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
    public class GenreRepository : IGenreRepository
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
            var listOfGenres =  await _dbContext.Genres.Where(predicate).ToListAsync();

            return listOfGenres;
        }

        public async Task<List<Genre>> GetListOfGenresAsync()
        {
            var listOfGenres =  await _dbContext.Genres.ToListAsync();

            return listOfGenres;
        }

        public async Task<Genre> GetGenreAsync(Expression<Func<Genre, bool>> predicate)
        {
            var genreToSearch =  await _dbContext.Genres.Include(g=>g.SubGenres).FirstOrDefaultAsync(predicate);

            return genreToSearch;
        }

        public async Task<bool> RemoveGenreAsync(int id)
        {
            var genreToRemove = await _dbContext.Genres.FirstOrDefaultAsync(g => g.Id == id);
            if (genreToRemove != null)
            {
                genreToRemove.IsDeleted = true;
                _dbContext.Entry(genreToRemove).State = EntityState.Modified;

                return true;
            }

            return false;
        }

        public async Task<Genre> UpdateGenreAsync(Genre genreToUpdate)
        {
            var genre = await _dbContext.Genres.FindAsync(genreToUpdate.Id);
            if(genre != null)
            {
                _dbContext.Entry(genre).CurrentValues.SetValues(genreToUpdate);
                _dbContext.Entry(genre).State = EntityState.Modified;   
            }

            return genre;
        }
    }
}
