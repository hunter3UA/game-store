using GameStore.DAL.Entities.GameStore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.DAL.Repositories.Abstract
{
    public interface IUserRepository
    {
        Task<User> AddAsync(User userToAdd);

        Task<User> GetAsync(Expression<Func<User, bool>> expression);

        Task<List<User>> GetListAsync();
    }
}
