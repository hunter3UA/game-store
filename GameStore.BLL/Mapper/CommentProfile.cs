using AutoMapper;
using GameStore.BLL.DTO.Comment;
using GameStore.DAL.Entities.GameStore;

namespace GameStore.BLL.Mapper
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<AddCommentDTO, Comment>();
            CreateMap<Comment, CommentDTO>();
            CreateMap<UpdateCommentDTO, Comment>();
        }
    }
}
