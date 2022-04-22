using GameStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GameStore.DAL.Repositories.Abstract
{
    public interface IPlatformTypeRepository
    {
        Task<PlatformType> AddPlatformAsync(PlatformType platformType); 

        Task<PlatformType> GetPlatformTypeAsync(Expression<Func<PlatformType, bool>> predicate);

        Task<List<PlatformType>> GetListOfPlatformTypesAsync();

        Task<List<PlatformType>> GetListOfPlatformTypesAsync(Expression<Func<PlatformType, bool>> predicate);

        Task<bool> RemovePlatformAsync(int id);
    }
}
