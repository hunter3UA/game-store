using GameStore.DAL.Models;
using GameStore.DAL.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GameStore.DAL.Repositories
{
    public class PlatformRepository:IPlatformRepository
    {
        private readonly StoreDbContext _dbContext;

        public PlatformRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<PlatformType> GetAsync(Expression<Func<PlatformType,bool>> predicate)
        {
            return await _dbContext.PlatformTypes.FirstOrDefaultAsync(predicate);
        }
        public async Task<List<PlatformType>> GetListAsync()
        {
            return await _dbContext.PlatformTypes.ToListAsync();
        }
        public async Task<List<PlatformType>> GetListAsync(Expression<Func<PlatformType,bool>> predicate)
        {
            return await  _dbContext.PlatformTypes.Where(predicate).ToListAsync();
        }

    }
}
