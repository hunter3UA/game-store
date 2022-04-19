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
            var commentToSearch =  await _dbContext.Comments.Include(c => c.Answers).FirstOrDefaultAsync(predicate);

            return commentToSearch;
        }
        public async Task<List<Comment>> GetListOfCommentsAsync(Expression<Func<Comment, bool>> predicate)
        {
            var listOfComments = await _dbContext.Comments.Include(c => c.Answers).Include(c => c.Game).Where(predicate).ToListAsync();

            return listOfComments;
        }

        public async Task<bool> RemoveCommentAsync(int key)
        {
            Comment commentToRemove = await _dbContext.Comments.FirstOrDefaultAsync(c=>c.Id==key);
            if (commentToRemove != null)
            {
                commentToRemove.IsDeleted = true;
                _dbContext.Entry(commentToRemove).State = EntityState.Modified;

                return true;
            }

            return false; 
        }

        public Task<Comment> UpdateCommentAsync(Comment commentToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
