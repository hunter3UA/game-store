using GameStore.DAL.Models;
using GameStore.DAL.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.DAL.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly StoreDbContext _dbContext;

        public CommentRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Comment> AddAsync(Comment commentToAdd)
        {
            await _dbContext.Comments.AddAsync(commentToAdd);
            return commentToAdd;
        }
        public async Task<Comment> GetAsync(Expression<Func<Comment, bool>> predicate)
        {
            return await _dbContext.Comments.FirstOrDefaultAsync(predicate);
        }
        public async Task<List<Comment>> GetListAsync(Expression<Func<Comment, bool>> predicate)
        {
            return await _dbContext.Comments.Where(predicate).ToListAsync();
        }

        public async Task<bool> RemoveAsync(Expression<Func<Comment, bool>> predicate)
        {
            Comment commentToRemove = await _dbContext.Comments.FirstOrDefaultAsync(predicate);
            if (commentToRemove != null)
            {
                _dbContext.Comments.Remove(commentToRemove);
                return true;
            }
            else { return false; }
        }

    }
}
