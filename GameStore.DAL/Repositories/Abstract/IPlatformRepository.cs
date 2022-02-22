using GameStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.DAL.Repositories.Abstract
{
    public interface IPlatformRepository
    {
        Task<PlatformType> GetAsync(Expression<Func<PlatformType, bool>> predicate);
        Task<List<PlatformType>> GetListAsync();

    }
}
