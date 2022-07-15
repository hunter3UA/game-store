using System;
using System.Collections.Generic;
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
using GameStore.DAL.Context.Abstract;
using GameStore.DAL.Entities;
using GameStore.DAL.UoW.Abstract;
using Microsoft.Extensions.Logging;
using Serilog.Context;

namespace GameStore.BLL.Services.Implementation.Games
{
    public class GameService : IGameService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGameFilterService _gameFilterService;
        private readonly ILogger<GameService> _logger;
        private readonly IMapper _mapper;
        private readonly INorthwindDbContext _northwindDbContext;
        private const string AddedToStoreDate = "June 2, 2022";

        public GameService(IUnitOfWork unitOfWork, ILogger<GameService> logger, IMapper mapper, IGameFilterService gameFilterService, INorthwindDbContext northwindDbContext)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _gameFilterService = gameFilterService;
            _northwindDbContext = northwindDbContext;
        }

        public async Task<GameDTO> AddGameAsync(AddGameDTO gameToAddDTO)
        {
            Game mappedGame = _mapper.Map<Game>(gameToAddDTO);
            Game initializedGame = await InitializeGameAsync(mappedGame, gameToAddDTO.GenresId, gameToAddDTO.PlatformsId, gameToAddDTO.Key);
            Game addedGame = await _unitOfWork.GameRepository.AddAsync(initializedGame);
            await _unitOfWork.SaveAsync();

            _logger.LogInformation("{Date} {Action} {Type}", DateTime.UtcNow, "Create", "Game");

            return _mapper.Map<GameDTO>(addedGame);
        }

        public async Task<int> GetCountAsync()
        {
            var gamesFromStore = await _unitOfWork.GameRepository.GetRangeAsync(g => !g.IsDeleted);
            var gamesFromNorthwind = await _northwindDbContext.ProductRepository.GetListAsync();
            gamesFromStore.AddRange(gamesFromNorthwind);
            gamesFromStore = gamesFromStore.DistinctBy(g => g.Key).ToList();
            int totalGames = gamesFromStore.Count();

            return totalGames;
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

            if (searchedGame.TypeOfBase == TypeOfBase.GameStore && isView)
            {
                searchedGame.NumberOfViews += 1;
                await _unitOfWork.SaveAsync();
            }
            else if (searchedGame.TypeOfBase == TypeOfBase.Northwind && isView)
            {
                searchedGame.NumberOfViews += 1;
                await _northwindDbContext.ProductRepository.UpdateAsync(searchedGame);
            }

            return _mapper.Map<GameDTO>(searchedGame);
        }

        public async Task<bool> RemoveGameAsync(string key)
        {
            Game gameById = await GetGameFromBasesAsync(key);
            bool isRemovedGame = false;

            if (gameById.IsDeleted)
                return isRemovedGame;

            if (gameById.TypeOfBase == TypeOfBase.GameStore)
            {
                isRemovedGame = await _unitOfWork.GameRepository.RemoveAsync(g => g.Key == key);
                await _unitOfWork.SaveAsync();

                if (isRemovedGame)
                    _logger.LogInformation($"Game with Key {key} has been deleted");
                else
                    throw new ArgumentException("Game can not be deleted");

            }
            else if (gameById.TypeOfBase == TypeOfBase.Northwind)
            {
                gameById.IsDeleted = true;
                Game addedGame = await _unitOfWork.GameRepository.AddAsync(gameById);

                await _unitOfWork.SaveAsync();
                return gameById.IsDeleted;
            }
            return isRemovedGame;
        }

        public async Task<GameDTO> UpdateGameAsync(UpdateGameDTO updateGameDTO)
        {
            Game gameByKey = await SetGameAsync(updateGameDTO.OldGameKey);

            if (gameByKey.TypeOfBase == TypeOfBase.GameStore)
            {
                Game mappedGame = _mapper.Map<Game>(updateGameDTO);
                Game initializedGame = await InitializeGameAsync(mappedGame, updateGameDTO.GenresId, updateGameDTO.PlatformsId, updateGameDTO.NewGameKey);
                Game updatedGame = await _unitOfWork.GameRepository.UpdateAsync(initializedGame, g => g.Genres, p => p.PlatformTypes);
                await _unitOfWork.SaveAsync();

                if (updatedGame != null)
                    _logger.LogInformation($"Game with Id:{updatedGame.Id} has been updated");
                else
                    throw new ArgumentException("Game can not be updated");

                return _mapper.Map<GameDTO>(updatedGame);
            }
            else
            {
                var mappedGame = _mapper.Map<Game>(updateGameDTO);
                var initializedGame = await InitializeGameAsync(mappedGame, updateGameDTO.GenresId, updateGameDTO.PlatformsId, updateGameDTO.NewGameKey);
                var detailsByOrder = await _unitOfWork.OrderDetailsRepository.GetRangeAsync(o => o.GameKey == gameByKey.Key);
                detailsByOrder.ForEach(o =>
                {
                    o.GameKey = mappedGame.Key;

                });
                var addedGame = await _unitOfWork.GameRepository.AddAsync(initializedGame);
                await _unitOfWork.SaveAsync();

                return _mapper.Map<GameDTO>(addedGame);
            }
        }

        private async Task<List<Game>> FilterGamesFromBasesAsync(GameFilterDTO gameFilterDTO)
        {
            List<Expression<Func<Game, bool>>> storeFilters = await _gameFilterService.GetFiltersForGameStore(gameFilterDTO);
            List<Expression<Func<Game, bool>>> northwindFilters = await _gameFilterService.GetFiltersForNorthwind(gameFilterDTO);

            var filteredGames = await _unitOfWork.GameRepository.GetFilteredListAsync(
                storeFilters,
                g => g.Genres, g => g.PlatformTypes, g => g.Comments);
            if (gameFilterDTO.Platforms == null)
            {
                var northwindGames = await InitializeNorthwindEntities(northwindFilters);
                filteredGames = filteredGames.Concat(northwindGames).ToList();
            }
            filteredGames = filteredGames.DistinctBy(g => g.Key).ToList();

            return filteredGames;
        }

        private async Task<List<Game>> InitializeNorthwindEntities(List<Expression<Func<Game, bool>>> filters)
        {
            var northwindGames = await _northwindDbContext.ProductRepository.GetFilteredListAsync(filters);

            foreach (var item in northwindGames.Where(g => g.Key == null).ToList())
            {
                item.Key = CreateGameKey(item.Name);
                await _northwindDbContext.ProductRepository.UpdateAsync(item);
                item.AddedAt = DateTime.Parse(AddedToStoreDate);
            }
            return northwindGames;
        }

        private async Task<Game> SetGameAsync(string gameKey)
        {
            Game gameByKey = await _unitOfWork.GameRepository.GetAsync(g => g.Key == gameKey, g => g.Genres, g => g.PlatformTypes);
            gameByKey ??= await _northwindDbContext.ProductRepository.GetAsync(g => g.Key == gameKey);

            return gameByKey != null ? gameByKey : throw new KeyNotFoundException();
        }

        private async Task<Game> GetGameFromBasesAsync(string gameKey)
        {
            Game searchedGame = await SetGameAsync(gameKey);

            if (searchedGame.PublisherName != null || searchedGame.SupplierID != 0)
            {
                var publisher = await _unitOfWork.PublisherRepository.GetAsync(p => p.CompanyName == searchedGame.PublisherName);
                publisher ??= await _northwindDbContext.SupplierRepository.GetAsync(p => p.SupplierID == searchedGame.SupplierID);
                searchedGame.Publisher = publisher;
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
            {
                throw new ArgumentException("The name cannot be empty or contain only spaces.");
            }

            name = Regex.Replace(name, @"[^'0-9a-zA-Z]", "-");

            name = Regex.Replace(name, @"[-]{2,}", "-");

            name = Regex.Replace(name, @"-+$", string.Empty);

            if (name.StartsWith("-"))
            {
                name = name[1..];
            }

            return name.ToLower();
        }
    }
}