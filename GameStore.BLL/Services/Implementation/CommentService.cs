using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using GameStore.BLL.DTO;
using GameStore.BLL.DTO.Comment;
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
            Comment mappedComment = _mapper.Map<Comment>(addCommentDTO);

            mappedComment.Game = await _unitOfWork.GameRepository.GetAsync(g => g.Key == key);
            Comment addedComment = await _unitOfWork.CommentRepository.AddAsync(mappedComment);
            await _unitOfWork.SaveAsync();

            _logger.LogInformation($"New comment has been added with Id {addedComment.GameId}");

            return _mapper.Map<CommentDTO>(addedComment);
        }

        public async Task<List<CommentDTO>> GetListOfCommentsAsync(Expression<Func<Comment, bool>> predicate)
        {
            var commentsByGameKey = await _unitOfWork.CommentRepository.GetRangeAsync(predicate,c=>c.Answers );

            return _mapper.Map<List<CommentDTO>>(commentsByGameKey);
        }

        public async Task<bool> RemoveCommentAsync(int id)
        {
            bool isRemovedComment = await _unitOfWork.CommentRepository.RemoveAsync(c => c.Id == id);
            await _unitOfWork.SaveAsync();

            if (isRemovedComment)
            {
                _logger.LogInformation($"Comment with Id {id} has been deleted");
            }

            return isRemovedComment;
        }
    }
}
