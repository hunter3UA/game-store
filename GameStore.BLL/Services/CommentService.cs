using AutoMapper;
using GameStore.BLL.DTO;
using GameStore.BLL.Mapper;
using GameStore.BLL.Services.Abstract;
using GameStore.DAL.Models;
using GameStore.DAL.UoW;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.BLL.Services
{
    public class CommentService:ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CommentService(IUnitOfWork unitOfWokr)
        {
            _unitOfWork = unitOfWokr;
            _mapper=AutoMapperConfig.Configure().CreateMapper();
        }

        public async Task<CommentDTO> AddAsync(AddCommentDTO addCommentDTO)
        {
            try
            {
                if(addCommentDTO != null)
                {
                    Comment commentToAdd= _mapper.Map<Comment>(addCommentDTO);
                    await _unitOfWork.CommentRepository.AddAsync(commentToAdd);
                    await _unitOfWork.SaveAsync();
                    return _mapper.Map<CommentDTO>(commentToAdd);
                }
                return new CommentDTO();
            }
            catch
            {
                return new CommentDTO();
            }


        }
        public async Task<CommentDTO> GetAsync(Expression<Func<Comment,bool>> predicate)
        {
            Comment commentToSearch = await _unitOfWork.CommentRepository.GetAsync(predicate);
            return commentToSearch != null ? _mapper.Map<CommentDTO>(commentToSearch) : new CommentDTO();
        }
    }
}
