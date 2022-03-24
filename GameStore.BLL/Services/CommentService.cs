using AutoMapper;
using GameStore.BLL.DTO;
using GameStore.BLL.Mapper;
using GameStore.BLL.Services.Abstract;
using GameStore.DAL.Models;
using GameStore.DAL.UoW;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.BLL.Services
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CommentService> _logger;

        public CommentService(IUnitOfWork unitOfWokr, ILogger<CommentService> logger)
        {
            _unitOfWork = unitOfWokr;
            _mapper = AutoMapperConfig.Configure().CreateMapper();
            _logger = logger;
        }

        public async Task<CommentDTO> AddCommentAsync(AddCommentDTO addCommentDTO)
        {
            try
            {
                if (addCommentDTO == null)
                    throw new ArgumentNullException("AddCommentDTO can not be null");
                Comment commentToAdd = _mapper.Map<Comment>(addCommentDTO);
                await _unitOfWork.CommentRepository.AddAsync(commentToAdd);
                await _unitOfWork.SaveAsync();
                _logger.LogInformation($"New comment has been added with Id {commentToAdd.GameId}");
                return _mapper.Map<CommentDTO>(commentToAdd);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}, \n {ex.StackTrace}");
                return new CommentDTO();
            }


        }

    

        public async Task<CommentDTO> GetAsync(Expression<Func<Comment, bool>> predicate)
        {
            Comment commentToSearch = await _unitOfWork.CommentRepository.GetAsync(predicate);
            return commentToSearch != null ? _mapper.Map<CommentDTO>(commentToSearch) : new CommentDTO();
        }
    }
}
