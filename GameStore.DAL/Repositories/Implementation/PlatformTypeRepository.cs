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

        public async Task<PlatformType> AddPlatformAsync(PlatformType platformToAdd)
        {
            var addedPlatform =  await _dbContext.PlatformTypes.AddAsync(platformToAdd);

            return addedPlatform.Entity;

        }

        public async Task<PlatformType> GetPlatformTypeAsync(Expression<Func<PlatformType, bool>> predicate)
        {
            var platformToSearch = await _dbContext.PlatformTypes.FirstOrDefaultAsync(predicate);

            return platformToSearch;
        }

        public async Task<List<PlatformType>> GetListOfPlatformTypesAsync()
        {
            var listOfPlatforms = await _dbContext.PlatformTypes.ToListAsync();

            return listOfPlatforms;
        }

        public async Task<List<PlatformType>> GetListOfPlatformTypesAsync(Expression<Func<PlatformType, bool>> predicate)
        {
            var listOfPlatforms = await _dbContext.PlatformTypes.Where(predicate).ToListAsync(); 

            return listOfPlatforms;
        }

        public async Task<bool> RemovePlatformAsync(int key)
        {
            PlatformType platformToDelete = await _dbContext.PlatformTypes.FirstOrDefaultAsync(p=>p.Id == key);
            if(platformToDelete != null)
            {
                platformToDelete.IsDeleted = true;
                _dbContext.Entry(platformToDelete).State = EntityState.Modified;

                return true;
            }

            return false;
        }

        public Task<PlatformType> UpdatePlatformAsync(PlatformType platformToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
