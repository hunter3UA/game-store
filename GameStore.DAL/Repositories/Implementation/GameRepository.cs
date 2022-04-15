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
    public class GameRepository:IGameRepository
    {
        private readonly StoreDbContext _dbContext;
        public GameRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Game> AddGameAsync(Game gameToAdd)
        {
            var addedGame = await _dbContext.Games.AddAsync(gameToAdd);
            return addedGame.Entity;
        }

        public async Task<List<Game>> GetListOfGamesAsync()
        {
            return await _dbContext.Games.Include(g => g.Genres).Include(g => g.PlatformTypes).ToListAsync();
        }

        public async Task<Game> GetGameAsync(Expression<Func<Game, bool>> predicate)
        {
            return await _dbContext.Games.Include(g => g.Genres).Include(g => g.PlatformTypes).FirstOrDefaultAsync(predicate);
        }

        public async Task<bool> RemoveGameAsync(int key)
        {
            Game gameToRemove = await _dbContext.Games.FirstOrDefaultAsync(g=>g.GameId==key);
            if (gameToRemove != null)
            {
                gameToRemove.IsDeleted = true;
                return true;
            }
            return false;
        }

    }
}
