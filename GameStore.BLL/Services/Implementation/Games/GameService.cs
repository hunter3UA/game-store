using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using GameStore.BLL.DTO.Common;
using GameStore.BLL.DTO.Game;
using GameStore.BLL.Enum;
using GameStore.BLL.Helpers;
using GameStore.BLL.Services.Abstract.Games;
using GameStore.DAL.Entities;
using GameStore.DAL.UoW.Abstract;
using Microsoft.Extensions.Logging;

namespace GameStore.BLL.Services.Implementation.Games
{
    public class GameService : IGameService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGameFilterService _gameFilterService;
        private readonly ILogger<GameService> _logger;
        private readonly IMapper _mapper;

        public GameService(IUnitOfWork unitOfWork, ILogger<GameService> logger, IMapper mapper, IGameFilterService gameFilterService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _gameFilterService = gameFilterService;
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

        public async Task<int> GetCountAsync()
        {
            int totalGames = await _unitOfWork.GameRepository.CountListAsync(new List<Expression<Func<Game, bool>>>());

            return totalGames;
        }

        public async Task<ItemPageDTO<GameDTO>> GetRangeOfGamesAsync(GameFilterDTO gameFilterDTO)
        {
            List<Expression<Func<Game, bool>>> filters = await _gameFilterService.GetFilteredGames(gameFilterDTO);
            Expression<Func<Game, object>> order = null;
            if (gameFilterDTO.SortingType != null)
                order = _gameFilterService.Sort((SortingType)gameFilterDTO.SortingType);

            bool orderDesc = gameFilterDTO.SortingType != SortingType.PriceAsc ? false : true;
            int totalGames = await _unitOfWork.GameRepository.CountListAsync(filters);
            gameFilterDTO.Page = PaginationHelper<Game>.CheckCurrentPage(gameFilterDTO.Page, gameFilterDTO.ElementsOnPage, totalGames);

            var gamesOnPage = await _unitOfWork.GameRepository.GetFilteredList(
                 filters,
                 (gameFilterDTO.Page - 1) * gameFilterDTO.ElementsOnPage,
                 gameFilterDTO.ElementsOnPage,
                 orderDesc,
                 order,
                 g => g.Genres, g => g.Publisher, g => g.PlatformTypes);

            var mappedGames = _mapper.Map<List<GameDTO>>(gamesOnPage);
            ItemPageDTO<GameDTO> gamePage = PaginationHelper<GameDTO>.CreatePage(gameFilterDTO.Page, gameFilterDTO.ElementsOnPage, totalGames, mappedGames);

            return gamePage;
        }

        public async Task<GameDTO> GetGameAsync(string gameKey, bool isView)
        {
            Game searchedGame = await _unitOfWork.GameRepository.GetAsync(game => game.Key == gameKey, p => p.PlatformTypes, g => g.Genres, pub => pub.Publisher);

            if (searchedGame != null && isView)
            {
                searchedGame.NumberOfViews += 1;
                await _unitOfWork.SaveAsync();
            }

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