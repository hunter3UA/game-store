using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
using GameStore.BLL.DTO.Common;
using GameStore.BLL.DTO.Game;
using GameStore.BLL.Enum;
using GameStore.BLL.Extensions;
using GameStore.BLL.Helpers;
using GameStore.BLL.Services.Abstract.Games;
using GameStore.DAL.Entities.Games;
using GameStore.DAL.Enums;
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
            Game initializedGame = await InitializeGameAsync(mappedGame, gameToAddDTO.GenresId, gameToAddDTO.PlatformsId, gameToAddDTO.Key);
            bool keyExist = await _unitOfWork.GameRepository.AnyAsync(g => g.Key == initializedGame.Key);
            if (keyExist)
                throw new ValidationException("Game with this key already,please exsit enter another key");

            Game addedGame = await _unitOfWork.GameRepository.AddAsync(initializedGame);
            await _unitOfWork.SaveAsync();

            _logger.LogInformation("Game has been created");

            return _mapper.Map<GameDTO>(addedGame);
        }

        public async Task<int> GetCountAsync()
        {
            var gamesFromStore = await _unitOfWork.GameRepository.GetListAsync();

            return gamesFromStore.Where(g => !g.IsDeleted).Count();
        }

        public async Task<ItemPageDTO<GameDTO>> GetRangeOfGamesAsync(GameFilterDTO gameFilterDTO)
        {
            Expression<Func<Game, object>> order = _gameFilterService.Sort(gameFilterDTO.SortingType);
            bool orderDesc = gameFilterDTO.SortingType != SortingType.PriceAsc ? false : true;

            var filteredGames = await FilterGamesFromBasesAsync(gameFilterDTO);
            int totalGames = filteredGames.Count();
            gameFilterDTO.Page = PaginationHelper<Game>.CheckCurrentPage(gameFilterDTO.Page, gameFilterDTO.ElementsOnPage, totalGames);
            var gamesOnPage = filteredGames.SortByParameter(order, orderDesc).GetPage(gameFilterDTO.Page, gameFilterDTO.ElementsOnPage);

            var mappedGames = _mapper.Map<List<GameDTO>>(gamesOnPage);
            ItemPageDTO<GameDTO> gamePage = PaginationHelper<GameDTO>.CreatePage(gameFilterDTO.Page, gameFilterDTO.ElementsOnPage, totalGames, mappedGames);

            return gamePage;
        }

        public async Task<GameDTO> GetGameAsync(string gameKey, bool isView)
        {
            Game searchedGame = await GetGameFromBasesAsync(gameKey);

            if (isView)
            {
                searchedGame.NumberOfViews += 1;
                await _unitOfWork.SaveAsync();
            }

            return _mapper.Map<GameDTO>(searchedGame);
        }

        public async Task<bool> RemoveGameAsync(string key)
        {
            Game gameById = await GetGameFromBasesAsync(key);
            bool isGameRemoved = false;

            if (gameById.IsDeleted)
                return isGameRemoved;

            if (gameById.TypeOfBase == TypeOfBase.GameStore)
            {
                isGameRemoved = await _unitOfWork.GameRepository.RemoveAsync(g => g.Key == key);
            }
            else if (gameById.TypeOfBase == TypeOfBase.Northwind)
            {
                gameById.IsDeleted = true;
                Game addedGame = await _unitOfWork.GameRepository.AddAsync(gameById);
                isGameRemoved = gameById.IsDeleted;
            }

            await _unitOfWork.SaveAsync();
            if (isGameRemoved)
            {
                _logger.LogInformation($"Game with Key {key} has been deleted");
            }
            else
                throw new ArgumentException("Game can not be deleted");

            return isGameRemoved;
        }

        public async Task<GameDTO> UpdateGameAsync(UpdateGameDTO updateGameDTO)
        {
            Game gameByKey = await SetGameAsync(updateGameDTO.OldGameKey);

            Game mappedGame = _mapper.Map<Game>(updateGameDTO);
            Game initializedGame = await InitializeGameAsync(mappedGame, updateGameDTO.GenresId, updateGameDTO.PlatformsId, updateGameDTO.NewGameKey);
            bool keyExist = await _unitOfWork.GameRepository.AnyAsync(g => g.Key == initializedGame.Key);
            if (keyExist)
                throw new ValidationException("Game with this key already,please exsit enter another key");

            Game updatedGame = await _unitOfWork.GameRepository.UpdateAsync(initializedGame, g => g.Genres, p => p.PlatformTypes);

            if (updatedGame != null)
            {
                await _unitOfWork.SaveAsync();
                _logger.LogInformation($"Game with Id:{updatedGame.Id} has been updated");
            }
            else
                throw new ArgumentException("Game can not be updated");

            return _mapper.Map<GameDTO>(updatedGame);
        }

        private async Task<List<Game>> FilterGamesFromBasesAsync(GameFilterDTO gameFilterDTO)
        {
            List<Expression<Func<Game, bool>>> storeFilters = await _gameFilterService.GetFiltersForGameStore(gameFilterDTO);


            var filteredGames = await _unitOfWork.GameRepository.GetFilteredListAsync(
                storeFilters,
                g => g.Genres, g => g.PlatformTypes, g => g.Comments);


            filteredGames = filteredGames.DistinctBy(g => g.Key).ToList();
            filteredGames = filteredGames.Where(g => !g.IsDeleted).ToList();
            filteredGames = _gameFilterService.FilterByPlatforms(filteredGames, gameFilterDTO.Platforms);

            return filteredGames;
        }


        public async Task<Game> SetGameAsync(string gameKey)
        {
            Game gameByKey = await _unitOfWork.GameRepository.GetAsync(g => g.Key == gameKey, g => g.Genres, g => g.PlatformTypes, g => g.Translations);

            return gameByKey != null && !gameByKey.IsDeleted ? gameByKey : throw new KeyNotFoundException();
        }


        private async Task<Game> GetGameFromBasesAsync(string gameKey)
        {
            Game searchedGame = await SetGameAsync(gameKey);

            if (searchedGame.PublisherName != null || searchedGame.SupplierID != 0)
            {
                searchedGame.Publisher = await _unitOfWork.PublisherRepository.GetAsync(p => p.CompanyName == searchedGame.PublisherName);
            }

            if (searchedGame.CategoryID != 0)
                searchedGame.Genres = await _unitOfWork.GenreRepository.GetRangeAsync(g => g.CategoryId == searchedGame.CategoryID);

            return searchedGame;
        }

        private async Task<Game> InitializeGameAsync(Game gameToInitialize, List<int> genres, List<int> platforms, string key)
        {
            gameToInitialize.Genres = await _unitOfWork.GenreRepository.GetRangeAsync(g => genres.Contains(g.Id));
            gameToInitialize.PlatformTypes = await _unitOfWork.PlatformTypeRepository.GetRangeAsync(p => platforms.Contains(p.Id));
            if (string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(gameToInitialize.Name))
                gameToInitialize.Key = CreateGameKey(gameToInitialize.Name);

            return gameToInitialize;
        }

        private string CreateGameKey(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("The name cannot be empty or contain only spaces.");

            name = Regex.Replace(name, @"[^'0-9a-zA-Z]", "-");
            name = Regex.Replace(name, @"[-]{2,}", "-");
            name = Regex.Replace(name, @"-+$", string.Empty);

            if (name.StartsWith("-"))
                name = name[1..];

            return name.ToLower();
        }
    }
}