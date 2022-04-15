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
    public class PlatformTypeRepository:IPlatformTypeRepository
    {
        private readonly StoreDbContext _dbContext;

        public PlatformTypeRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<PlatformType> GetPlatformTypeAsync(Expression<Func<PlatformType, bool>> predicate)
        {
            return await _dbContext.PlatformTypes.FirstOrDefaultAsync(predicate);
        }
        public async Task<List<PlatformType>> GetListOfPlatformTypesAsync()
        {
            return await _dbContext.PlatformTypes.ToListAsync();
        }
        public async Task<List<PlatformType>> GetListOfPlatformTypesAsync(Expression<Func<PlatformType, bool>> predicate)
        {
            return await _dbContext.PlatformTypes.Where(predicate).ToListAsync();
        }

    }
}
