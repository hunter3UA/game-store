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
    public class GameService : IGameService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GameService> _logger;
        private readonly IMapper _mapper;

        public GameService(IUnitOfWork unitOfWork, ILogger<GameService> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<GameDTO> AddGameAsync(AddGameDTO gameToAddDTO)
        {
            Game gameToAdd = _mapper.Map<Game>(gameToAddDTO);

            gameToAdd.Genres = await _unitOfWork.GenreRepository.GetRangeAsync(g => gameToAddDTO.GenresID.Contains(g.Id));
            gameToAdd.PlatformTypes = await _unitOfWork.PlatformTypeRepository.GetRangeAsync(p => gameToAddDTO.PlatformsId.Contains(p.Id));

            if (gameToAdd.Genres.Count() <= 0 || gameToAdd.PlatformTypes.Count() <= 0)
            {
                throw new Exception("Game must contain at least 1 existing genre and 1 existing platform type");
            }

            Game addedGame = await _unitOfWork.GameRepository.AddAsync(gameToAdd);
            await _unitOfWork.SaveAsync();

            if (addedGame != null)
            {
                _logger.LogInformation($"Game has been added with Id: {addedGame.Id}");
            }

            return _mapper.Map<GameDTO>(addedGame);
        }

        public async Task<List<GameDTO>> GetListOfGamesAsync()
        {
            List<Game> allGames = await _unitOfWork.GameRepository.GetListAsync(g => g.Genres, p=>p.PlatformTypes);

            return _mapper.Map<List<GameDTO>>(allGames);
        }

        public async Task<GameDTO> GetGameAsync(Expression<Func<Game, bool>> predicate)
        {
            Game searchedGame = await _unitOfWork.GameRepository.GetAsync(predicate, p=>p.PlatformTypes, g=>g.Genres);

            return _mapper.Map<GameDTO>(searchedGame);
        }

        public async Task<bool> RemoveGameAsync(string key)
        {
            bool isRemovedGame = await _unitOfWork.GameRepository.RemoveAsync(g => g.Key == key);
            await _unitOfWork.SaveAsync();

            if (isRemovedGame)
            {
                _logger.LogInformation($"Game with Key {key} has been deleted");
            }

            return isRemovedGame;
        }

        public async Task<GameDTO> UpdateGameAsync(UpdateGameDTO updateGameDTO)
        {
            Game gameToUpdate = _mapper.Map<Game>(updateGameDTO);

            gameToUpdate.Genres = await _unitOfWork.GenreRepository.GetRangeAsync(g => updateGameDTO.GenresID.Contains(g.Id));
            gameToUpdate.PlatformTypes = await _unitOfWork.PlatformTypeRepository.GetRangeAsync(p => updateGameDTO.PlatformsId.Contains(p.Id));

            if (gameToUpdate.PlatformTypes.Count() <= 0 || gameToUpdate.Genres.Count() <= 0)
            {
                throw new Exception("Genres and PlatformTypes can not be empty");
            }

            Game updatedGame = await _unitOfWork.GameRepository.UpdateAsync(gameToUpdate);
            await _unitOfWork.SaveAsync();

            _logger.LogInformation($"Game with Id:{updatedGame.Id} has been updated");

            return _mapper.Map<GameDTO>(gameToUpdate);
        }
    }
}
