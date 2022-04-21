using GameStore.BLL.DTO;
using GameStore.DAL.Entities;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GameStore.BLL.Services.Abstract
{
    public interface ICommentService
    {
        Task<CommentDTO> AddCommentAsync(string key,AddCommentDTO addCommentDTO);

        Task<CommentDTO> GetCommentAsync(Expression<Func<Comment, bool>> predicate);

        Task<bool> RemoveCommentAsync(int id);
    }
}
