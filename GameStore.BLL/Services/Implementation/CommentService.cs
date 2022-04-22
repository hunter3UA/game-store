using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using GameStore.BLL.DTO;
using GameStore.BLL.Services.Abstract;
using GameStore.DAL.Entities;
using GameStore.DAL.UoW.Abstract;
using Microsoft.Extensions.Logging;

namespace GameStore.BLL.Services.Implementation
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CommentService> _logger;

        public CommentService(IUnitOfWork unitOfWokr, ILogger<CommentService> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWokr;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CommentDTO> AddCommentAsync(string key, AddCommentDTO addCommentDTO)
        {
            Comment commentToAdd = _mapper.Map<Comment>(addCommentDTO);
            commentToAdd.Game = await _unitOfWork.GameRepository.GetGameAsync(g => g.Key == key);
            commentToAdd = await _unitOfWork.CommentRepository.AddCommentAsync(commentToAdd);
            await _unitOfWork.SaveAsync();
            _logger.LogInformation($"New comment has been added with Id {commentToAdd.GameId}");

            return _mapper.Map<CommentDTO>(commentToAdd);
        }

        public async Task<CommentDTO> GetCommentAsync(Expression<Func<Comment, bool>> predicate)
        {
            Comment commentToSearch = await _unitOfWork.CommentRepository.GetCommentAsync(predicate);

            return _mapper.Map<CommentDTO>(commentToSearch);
        }

        public async Task<bool> RemoveCommentAsync(int id)
        {
            bool isRemovedComment = await _unitOfWork.CommentRepository.RemoveCommentAsync(id);
            await _unitOfWork.SaveAsync();
            if (isRemovedComment)
            {
                _logger.LogInformation($"Comment with Id {id} has been deleted");
            }
     
            return isRemovedComment;
        }
    }
}
