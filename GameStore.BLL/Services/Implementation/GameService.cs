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
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GameStore.BLL.Services.Implementation
{
    public class GameService : IGameService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHostEnvironment _env;
        private readonly ILogger<GameService> _logger;
        private readonly IMapper _mapper;

        public GameService(IUnitOfWork unitOfWork, IHostEnvironment env, ILogger<GameService> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _env = env;
            _logger = logger;
        }

        public async Task<GameDTO> AddGameAsync(AddGameDTO gameToAddDTO)
        {
            Game gameToAdd = _mapper.Map<Game>(gameToAddDTO);
            gameToAdd.Genres = await _unitOfWork.GenreRepository.GetListOfGenresAsync(g => gameToAddDTO.GenresID.Contains(g.Id));
            gameToAdd.PlatformTypes = await _unitOfWork.PlatformTypeRepository.GetListOfPlatformTypesAsync(p => gameToAddDTO.PlatformsId.Contains(p.Id));

            if (gameToAdd.Genres.Count() <= 0 || gameToAdd.PlatformTypes.Count() <= 0)
            {
                throw new Exception("Genres and PlatformTypes can not be empty");
            }

            Game addedGame = await _unitOfWork.GameRepository.AddGameAsync(gameToAdd);
            await _unitOfWork.SaveAsync();

            if (addedGame != null)
            {
                _logger.LogInformation($"Game has been added with Id: {addedGame.Id}");
            }

            return _mapper.Map<GameDTO>(addedGame);
        }

        public async Task<List<GameDTO>> GetListOfGamesAsync()
        {
            List<Game> games = await _unitOfWork.GameRepository.GetListOfGamesAsync();

            return _mapper.Map<List<GameDTO>>(games);
        }

        public async Task<GameDTO> GetGameAsync(Expression<Func<Game, bool>> predicate)
        {
            Game game = await _unitOfWork.GameRepository.GetGameAsync(predicate);

            return _mapper.Map<GameDTO>(game);
        }

        public async Task<bool> RemoveGameAsync(string key)
        {
            bool isRemovedGame = await _unitOfWork.GameRepository.RemoveGameAsync(key);
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
            gameToUpdate.Genres = await _unitOfWork.GenreRepository.GetListOfGenresAsync(g => updateGameDTO.GenresID.Contains(g.Id));
            gameToUpdate.PlatformTypes = await _unitOfWork.PlatformTypeRepository.GetListOfPlatformTypesAsync(p => updateGameDTO.PlatformsId.Contains(p.Id));

            if (gameToUpdate.PlatformTypes.Count() <= 0 || gameToUpdate.Genres.Count() <= 0)
            {
                throw new Exception("Genres and PlatformTypes can not be empty");
            }

            Game updatedGame = await _unitOfWork.GameRepository.UpdateGameAsync(gameToUpdate);
            await _unitOfWork.SaveAsync();
            _logger.LogInformation($"Game with Id:{updatedGame.Id} has been updated");

            return _mapper.Map<GameDTO>(gameToUpdate);
        }
    }
}
