using GameStore.BLL.DTO;
using GameStore.DAL.Models;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GameStore.BLL.Services.Abstract
{
    public interface ICommentService
    {
        Task<CommentDTO> AddAsync(AddCommentDTO addCommentDTO);
        Task<CommentDTO> GetAsync(Expression<Func<Comment, bool>> predicate);
        
    
    }
}
