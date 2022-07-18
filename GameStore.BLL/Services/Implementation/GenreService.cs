using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GameStore.BLL.DTO.Genre;
using GameStore.BLL.Enums;
using GameStore.BLL.Providers;
using GameStore.BLL.Services.Abstract;
using GameStore.DAL.Context.Abstract;
using GameStore.DAL.Entities;
using GameStore.DAL.UoW.Abstract;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;

namespace GameStore.BLL.Services.Implementation
{
    public class GenreService : IGenreService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<GenreService> _logger;
        private readonly INorthwindDbContext _northwindDbContext;
        private readonly IMongoLoggerProvider _mongoLogger;

        public GenreService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<GenreService> logger, INorthwindDbContext northwindDbContext, IMongoLoggerProvider mongoLogger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _northwindDbContext = northwindDbContext;
            _mongoLogger = mongoLogger;
        }

        public async Task<GenreDTO> AddGenreAsync(AddGenreDTO addGenreDTO)
        {
            Genre mappedGenre = _mapper.Map<Genre>(addGenreDTO);

            Genre addedGenre = await _unitOfWork.GenreRepository.AddAsync(mappedGenre);
            await _unitOfWork.SaveAsync();

            _logger.LogInformation($"Genre with Id {addedGenre.Id} has been added");
            await _mongoLogger.LogInformation<Genre>(ActionType.Create);

            return _mapper.Map<GenreDTO>(addedGenre);
        }

        public async Task<GenreDTO> GetGenreAsync(int id)
        {
            var searchedGenre = await _unitOfWork.GenreRepository.GetAsync(genre => genre.Id == id, g => g.SubGenres);

            return searchedGenre != null ? _mapper.Map<GenreDTO>(searchedGenre) : throw new KeyNotFoundException();
        }

        public async Task<List<GenreDTO>> GetListOfGenresAsync()
        {
            List<Genre> genresFromStore = await _unitOfWork.GenreRepository.GetListAsync(g => g.SubGenres);

            return _mapper.Map<List<GenreDTO>>(genresFromStore);
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
            {
                _logger.LogInformation($"Genre with Id: {id} has been deleted");
                await _mongoLogger.LogInformation<Genre>(ActionType.Delete);
            }
            else
                throw new ArgumentException("Genre can not be deleted");

            return isDeletedGenre;
        }

        public async Task<GenreDTO> UpdateGenreAsync(UpdateGenreDTO updateGenreDTO)
        {
            Genre mappedGenre = _mapper.Map<Genre>(updateGenreDTO);
            Genre oldGenre = await _unitOfWork.GenreRepository.GetAsync(g => g.Id == updateGenreDTO.Id);
            var oldVersion = oldGenre.ToBsonDocument();
            Genre updatedGenre = await _unitOfWork.GenreRepository.UpdateAsync(mappedGenre);
            await _unitOfWork.SaveAsync();

            if (updatedGenre != null)
            {
                _logger.LogInformation($"Genre with id {updatedGenre.Id} has been updated");
                await _mongoLogger.LogInformation<Genre>(ActionType.Update,oldVersion,updatedGenre.ToBsonDocument());
            }
            else
                throw new ArgumentException("Genre can not be updated");

            return _mapper.Map<GenreDTO>(updatedGenre);
        }
    }
}