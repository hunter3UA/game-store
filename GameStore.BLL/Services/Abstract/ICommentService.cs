using GameStore.BLL.DTO;
using GameStore.DAL.Entities;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GameStore.BLL.Services.Abstract
{
    public interface ICommentService
    {
        Task<CommentDTO> AddCommentAsync(AddCommentDTO addCommentDTO);

        Task<CommentDTO> GetCommentAsync(Expression<Func<Comment, bool>> predicate);

    }
}
