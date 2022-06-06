using System.Collections.Generic;
using System.Threading.Tasks;
using GameStore.BLL.DTO.Comment;

namespace GameStore.BLL.Services.Abstract
{
    public interface ICommentService
    {
        Task<CommentDTO> AddCommentAsync(string key, AddCommentDTO addCommentDTO);

        Task<List<CommentDTO>> GetListOfCommentsAsync(string gameKey);

        Task<CommentDTO> UpdateCommentAsync(UpdateCommentDTO updateCommentDTO);

        Task<bool> RemoveCommentAsync(int id);
    }
}
