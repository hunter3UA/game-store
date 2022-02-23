using GameStore.DAL.Models;
using GameStore.DAL.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GameStore.DAL.Repositories
{
    public class GameRepository:IGameRepository
    {
        private readonly StoreDbContext _dbContext;
        public GameRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Game> AddAsync(Game gameToAdd)
        {
            await _dbContext.Games.AddAsync(gameToAdd);
            return gameToAdd;
        }

        public async Task<List<Game>> GetListAsync()
        {
            return await _dbContext.Games.Include(g=>g.Genres).Include(g=>g.PlatformTypes).ToListAsync();
        }

        public async Task<Game> GetAsync(Expression<Func<Game, bool>> predicate)
        {
            return await _dbContext.Games.Include(g => g.Genres).Include(g => g.PlatformTypes).FirstOrDefaultAsync(predicate);
        }
   
        public async Task<bool> RemoveAsync(Expression<Func<Game, bool>> predicate)
        {
            Game gameToRemove= await _dbContext.Games.FirstOrDefaultAsync(predicate);
            if (gameToRemove != null)
            {
                gameToRemove.IsDeleted = true;
                return true;
            }
            return false;
        }
    }
}
