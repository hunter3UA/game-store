using System;
using System.Collections.Generic;
using System.Linq;
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
    public class GenreService : IGenreService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<GenreService> _logger;

        public GenreService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<GenreService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<GenreDTO> AddGenreAsync(AddGenreDTO addGenreDTO)
        {
            Genre mappedGenre = _mapper.Map<Genre>(addGenreDTO);

            Genre addedGenre = await _unitOfWork.GenreRepository.AddAsync(mappedGenre);
            await _unitOfWork.SaveAsync();

            if (addedGenre != null)
            {
                _logger.LogInformation($"Genre with Id {addedGenre.Id} has been added");
            }

            return _mapper.Map<GenreDTO>(addedGenre);
        }

        public async Task<GenreDTO> GetGenreAsync(Expression<Func<Genre, bool>> predicate)
        {
            var searchedGenre = await _unitOfWork.GenreRepository.GetAsync(predicate, g=>g.SubGenres);

            return _mapper.Map<GenreDTO>(searchedGenre);
        }

        public async Task<List<GenreDTO>> GetListOfGenresAsync()
        {
            List<Genre> allGenres = await _unitOfWork.GenreRepository.GetListAsync(g=>g.SubGenres);
            allGenres = allGenres.Where(g => g.ParentGenreId == null).ToList();

            return _mapper.Map<List<GenreDTO>>(allGenres);
        }

        public async Task<bool> RemoveGenreAsync(int id)
        {
            bool isDeletedGenre = await _unitOfWork.GenreRepository.RemoveAsync(g => g.Id == id);
            await _unitOfWork.SaveAsync();

            if (isDeletedGenre)
            {
                _logger.LogInformation($"Genre with Id: {id} has been deleted");
            }
            else
            {
                _logger.LogInformation($"Genre has not been deleted");
            }

            return isDeletedGenre;
        }
    }
}
