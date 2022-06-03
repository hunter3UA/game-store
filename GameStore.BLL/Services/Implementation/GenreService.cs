using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GameStore.BLL.DTO.Genre;
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

            _logger.LogInformation($"Genre with Id {addedGenre.Id} has been added");

            return _mapper.Map<GenreDTO>(addedGenre);
        }

        public async Task<GenreDTO> GetGenreAsync(int id)
        {
            var searchedGenre = await _unitOfWork.GenreRepository.GetAsync(genre => genre.Id == id, g => g.SubGenres);

            return searchedGenre != null ? _mapper.Map<GenreDTO>(searchedGenre) : throw new KeyNotFoundException();
        }

        public async Task<List<GenreDTO>> GetListOfGenresAsync()
        {
            List<Genre> allGenres = await _unitOfWork.GenreRepository.GetListAsync(g => g.SubGenres);

            return _mapper.Map<List<GenreDTO>>(allGenres);
        }

        public async Task<bool> RemoveGenreAsync(int id)
        {
            var genreById = await _unitOfWork.GenreRepository.GetAsync(g => g.Id == id, subG => subG.SubGenres);

            if (genreById.SubGenres != null)
            {
                foreach (var genre in genreById.SubGenres)
                    genre.ParentGenreId = genreById.ParentGenreId;              
            }

            bool isDeletedGenre = await _unitOfWork.GenreRepository.RemoveAsync(g => g.Id == id);
            await _unitOfWork.SaveAsync();

            if (isDeletedGenre)
                _logger.LogInformation($"Genre with Id: {id} has been deleted");
            else
                throw new ArgumentException();

            return isDeletedGenre;
        }

        public async Task<GenreDTO> UpdateGenreAsync(UpdateGenreDTO updateGenreDTO)
        {
            Genre mappedGenre = _mapper.Map<Genre>(updateGenreDTO);

            Genre updatedGenre = await _unitOfWork.GenreRepository.UpdateAsync(mappedGenre);
            await _unitOfWork.SaveAsync();

            if (updatedGenre != null)
                _logger.LogInformation($"Genre with id {updatedGenre.Id} has been updated");
            else
                throw new ArgumentException();

            return _mapper.Map<GenreDTO>(updatedGenre);
        }
    }
}