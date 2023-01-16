using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GameStore.BLL.DTO.Comment;
using GameStore.BLL.Enums;
using GameStore.BLL.Services.Abstract;
using GameStore.DAL.Entities.GameStore;
using GameStore.DAL.UoW.Abstract;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;

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

        public async Task<List<CommentDTO>> GetListOfCommentsAsync(string gameKey)
        {
            var commentsByGameKey = await _unitOfWork.CommentRepository.GetRangeAsync(g => g.Game.Key == gameKey, c => c.Answers);
            commentsByGameKey = commentsByGameKey.Where(c => c.ParentCommentId == null).ToList();

            return _mapper.Map<List<CommentDTO>>(commentsByGameKey);
        }

        public async Task<CommentDTO> UpdateCommentAsync(UpdateCommentDTO updateCommentDTO)
        {
            Comment commentById = await _unitOfWork.CommentRepository.GetAsync(c => c.Id == updateCommentDTO.Id && !c.IsDeleted);

            if (commentById == null)
                throw new KeyNotFoundException($"Comment with id {updateCommentDTO.Id} not found");

            var oldVersion = commentById.ToBsonDocument();
            Comment mappedComment = _mapper.Map<Comment>(updateCommentDTO);
            Comment updatedComment = await _unitOfWork.CommentRepository.UpdateAsync(mappedComment);
            await _unitOfWork.SaveAsync();

            if (updatedComment != null)
            {
                _logger.LogInformation($"Comment with Id {updatedComment.Id} has been updated");
            }
            else
                throw new ArgumentException("Comment can not be updated");

            return _mapper.Map<CommentDTO>(updatedComment);
        }

        public async Task<bool> RemoveCommentAsync(int id)
        {
            bool isRemovedComment = await _unitOfWork.CommentRepository.RemoveAsync(c => c.Id == id);
            await _unitOfWork.SaveAsync();

            if (isRemovedComment)
            {
                _logger.LogInformation($"Comment with Id {id} has been deleted");
            }
            else
                throw new ArgumentException("Comment can not deleted");

            return isRemovedComment;
        }
    }
}
