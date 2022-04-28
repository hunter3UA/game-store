using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GameStore.BLL.DTO;
using GameStore.DAL.Entities;

namespace GameStore.BLL.Services.Abstract
{
    public interface ICommentService
    {
        Task<CommentDTO> AddCommentAsync(string key, AddCommentDTO addCommentDTO);

        Task<List<CommentDTO>> GetListOfCommentsAsync(Expression<Func<Comment, bool>> predicate);

        Task<bool> RemoveCommentAsync(int id);
    }
}
