using GameStore.DAL.Context;
using GameStore.DAL.Entities;
using GameStore.DAL.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.DAL.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly StoreDbContext _dbContext;

        public UserRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> AddAsync(User userToAdd)
        {
            var addedUser = await _dbContext.Users.AddAsync(userToAdd);

            return addedUser.Entity;
        }

        public async Task<User> GetAsync(Expression<Func<User,bool>> expression)
        {
            var userByExpression = await _dbContext.Users.FirstOrDefaultAsync(expression);

            return userByExpression;
        }

        public async Task<List<User>> GetListAsync()
        {
            var allUsers = await _dbContext.Users.ToListAsync();

            return allUsers;
        }
    }
}
