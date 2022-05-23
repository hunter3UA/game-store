using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GameStore.BLL.DTO;
using GameStore.BLL.DTO.Comment;
using GameStore.DAL.Entities;

namespace GameStore.BLL.Services.Abstract
{
    public interface ICommentService
    {
        Task<CommentDTO> AddCommentAsync(string key, AddCommentDTO addCommentDTO);

        Task<List<CommentDTO>> GetListOfCommentsAsync(string gameKey);

        Task<bool> RemoveCommentAsync(int id);
    }
}
