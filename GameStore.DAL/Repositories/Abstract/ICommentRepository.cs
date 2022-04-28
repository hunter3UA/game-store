using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using System.Threading.Tasks;
using GameStore.DAL.Entities;

namespace GameStore.DAL.Repositories.Abstract
{
    public interface ICommentRepository
    {
        Task<Comment> AddCommentAsync(Comment commentToAdd);

        Task<Comment> GetCommentAsync(Expression<Func<Comment, bool>> predicate);

        Task<List<Comment>> GetListOfCommentsAsync(Expression<Func<Comment, bool>> predicate);

        Task<bool> RemoveCommentAsync(int id);
    }
}
