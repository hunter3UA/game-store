using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GameStore.BLL.DTO.Game;
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
            Game mappedGame = _mapper.Map<Game>(gameToAddDTO);

            mappedGame.Genres = await _unitOfWork.GenreRepository.GetRangeAsync(g => gameToAddDTO.GenresId.Contains(g.Id));
            mappedGame.PlatformTypes = await _unitOfWork.PlatformTypeRepository.GetRangeAsync(p => gameToAddDTO.PlatformsId.Contains(p.Id));
            if (string.IsNullOrEmpty(gameToAddDTO.Key) && !string.IsNullOrEmpty(gameToAddDTO.Name))
                mappedGame.Key = CreateGameKey(gameToAddDTO.Name);

            Game addedGame = await _unitOfWork.GameRepository.AddAsync(mappedGame);
            await _unitOfWork.SaveAsync();

            _logger.LogInformation($"Game has been added with Id: {addedGame.Id}");

            return _mapper.Map<GameDTO>(addedGame);
        }

        public async Task<List<GameDTO>> GetListOfGamesAsync()
        {
            List<Game> allGames = await _unitOfWork.GameRepository.GetListAsync(g => g.Genres, p => p.PlatformTypes, pb => pb.Publisher);

            return _mapper.Map<List<GameDTO>>(allGames);
        }

        public async Task<GameDTO> GetGameAsync(string gameKey)
        {
            Game searchedGame = await _unitOfWork.GameRepository.GetAsync(game => game.Key == gameKey, p => p.PlatformTypes, g => g.Genres, pub => pub.Publisher);

            return searchedGame != null ? _mapper.Map<GameDTO>(searchedGame) : throw new KeyNotFoundException();
        }

        public async Task<bool> RemoveGameAsync(int id)
        {
            bool isRemovedGame = await _unitOfWork.GameRepository.RemoveAsync(g => g.Id == id);
            await _unitOfWork.SaveAsync();

            if (isRemovedGame)
                _logger.LogInformation($"Game with Key {id} has been deleted");
            else
                throw new ArgumentException("Game can not be deleted");

            return isRemovedGame;
        }

        public async Task<GameDTO> UpdateGameAsync(UpdateGameDTO updateGameDTO)
        {
            Game mappedGame = _mapper.Map<Game>(updateGameDTO);

            mappedGame.Genres = await _unitOfWork.GenreRepository.GetRangeAsync(g => updateGameDTO.Genres.Contains(g.Id));
            mappedGame.PlatformTypes = await _unitOfWork.PlatformTypeRepository.GetRangeAsync(p => updateGameDTO.Platforms.Contains(p.Id));
            if (string.IsNullOrEmpty(updateGameDTO.Key) && !string.IsNullOrEmpty(updateGameDTO.Name))
                mappedGame.Key = CreateGameKey(updateGameDTO.Name);

            Game updatedGame = await _unitOfWork.GameRepository.UpdateAsync(mappedGame, g => g.Genres, p => p.PlatformTypes);
            await _unitOfWork.SaveAsync();

            if (updatedGame != null)
                _logger.LogInformation($"Game with Id:{updatedGame.Id} has been updated");
            else
                throw new ArgumentException("Game can not be updated");

            return _mapper.Map<GameDTO>(updatedGame);
        }

        private string CreateGameKey(string name)
        {
            var key = name.Trim().ToLower().Replace(" ", "-");
            return key;
        }
    }
}
