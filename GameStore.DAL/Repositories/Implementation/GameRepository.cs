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
    public class GameRepository : IGameRepository
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
            var listOfGames = await _dbContext.Games.Include(g => g.Genres).Include(g => g.PlatformTypes).ToListAsync();

            return listOfGames;
        }

        public async Task<Game> UpdateGame(Game gameToUpdate)
        {
            var game = await _dbContext.Games.FindAsync(gameToUpdate.Id);
            if (game != null)
            {
                _dbContext.Entry(game).CurrentValues.SetValues(gameToUpdate);
                _dbContext.Entry(game).State = EntityState.Modified;
            }
            return gameToUpdate;
        }

        public async Task<Game> GetGameAsync(Expression<Func<Game, bool>> predicate)
        {
            var gameToSearch = await _dbContext.Games.Include(g => g.Genres).Include(g => g.PlatformTypes).FirstOrDefaultAsync(predicate);

            return gameToSearch;
        }

        public async Task<bool> RemoveGameAsync(int key)
        {
            Game gameToRemove = await _dbContext.Games.FirstOrDefaultAsync(g => g.Id == key);
            if (gameToRemove != null)
            {
                gameToRemove.IsDeleted = true;
                _dbContext.Entry(gameToRemove).State = EntityState.Modified;

                return true;
            }

            return false;
        }

        public Task<Game> UpdateGameAsync(Game gameToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
