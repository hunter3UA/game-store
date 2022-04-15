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
    public class CommentRepository:ICommentRepository
    {
        private readonly StoreDbContext _dbContext;

        public CommentRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Comment> AddCommentAsync(Comment commentToAdd)
        {
            var addedComment = await _dbContext.Comments.AddAsync(commentToAdd);
            return addedComment.Entity;
        }
        public async Task<Comment> GetCommentAsync(Expression<Func<Comment, bool>> predicate)
        {
            return await _dbContext.Comments.Include(c => c.Answers).FirstOrDefaultAsync(predicate);
        }
        public async Task<List<Comment>> GetListOfCommentsAsync(Expression<Func<Comment, bool>> predicate)
        {
            return await _dbContext.Comments.Include(c => c.Answers).Include(c => c.Game).Where(predicate).ToListAsync();
        }

        public async Task<bool> RemoveCommentAsync(Expression<Func<Comment, bool>> predicate)
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
