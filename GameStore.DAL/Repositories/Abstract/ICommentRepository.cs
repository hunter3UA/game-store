using GameStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GameStore.DAL.Repositories.Abstract
{
    public interface ICommentRepository
    {
        Task<Comment> AddAsync(Comment commentToAdd);
        Task<Comment> GetAsync(Expression<Func<Comment, bool>> predicate);
        Task<List<Comment>> GetListAsync(Expression<Func<Comment, bool>> predicate);
        Task<bool> RemoveAsync(Expression<Func<Comment, bool>> predicate);
    }
}
