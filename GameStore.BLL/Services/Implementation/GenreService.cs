using AutoMapper;
using GameStore.BLL.DTO;
using GameStore.BLL.Mapper;
using GameStore.BLL.Services.Abstract;
using GameStore.DAL.Entities;
using GameStore.DAL.UoW;
using GameStore.DAL.UoW.Abstract;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GameStore.BLL.Services.Implementation
{
    public class GenreService : IGenreService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<GenreService> _logger;

        public GenreService(IUnitOfWork unitOfWork, IMapper mapper,ILogger<GenreService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<GenreDTO> AddGenreAsync(AddGenreDTO addGenreDTO)
        {
            Genre genreToAdd = _mapper.Map<Genre>(addGenreDTO);
            Genre addedGenre = await _unitOfWork.GenreRepository.AddGenreAsync(genreToAdd);           
            await _unitOfWork.SaveAsync();
            if (addedGenre != null)
                _logger.LogInformation($"Genre with Id {addedGenre.Id} has been added");

            return _mapper.Map<GenreDTO>(addedGenre);
        }

        public async Task<GenreDTO> GetGenreAsync(Expression<Func<Genre, bool>> predicate)
        {
            var genreToSearch = await _unitOfWork.GenreRepository.GetGenreAsync(predicate);

            return _mapper.Map<GenreDTO>(genreToSearch);
        }

        public async Task<List<GenreDTO>> GetListOfGenresAsync()
        {
            List<Genre> listOfGenres = await _unitOfWork.GenreRepository.GetListOfGenresAsync();
            return _mapper.Map<List<GenreDTO>>(listOfGenres);
        }

        public async Task<bool> RemoveGenreAsync(int key)
        {
            bool isDeletedGenre = await _unitOfWork.GenreRepository.RemoveGenreAsync(key);
            await _unitOfWork.SaveAsync();
            if (isDeletedGenre)
                _logger.LogInformation($"Genre with Id: {key} has been deleted");
            else
                _logger.LogInformation($"Genre has not been deleted");

            return isDeletedGenre;

        }
    }
}
