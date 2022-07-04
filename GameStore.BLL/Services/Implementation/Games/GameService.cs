using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

namespace GameStore.BLL.Services.Implementation.Games
{
    public class GameService : IGameService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGameFilterService _gameFilterService;
        private readonly ILogger<GameService> _logger;
        private readonly IMapper _mapper;
        private readonly INorthwindDbContext _northwindDbContext;

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

            mappedGame.Genres = await _unitOfWork.GenreRepository.GetRangeAsync(g => gameToAddDTO.GenresId.Contains(g.Id));
            mappedGame.PlatformTypes = await _unitOfWork.PlatformTypeRepository.GetRangeAsync(p => gameToAddDTO.PlatformsId.Contains(p.Id));
            mappedGame.Publisher = await _unitOfWork.PublisherRepository.GetAsync(p => p.CompanyName == gameToAddDTO.PublisherName);
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

        public async Task<int> GetCountAsync(List<Expression<Func<Game, bool>>> filters)
        {
            filters = filters == null ? new List<Expression<Func<Game, bool>>>() : filters;
            int totalGames = await _unitOfWork.GameRepository.CountListAsync(filters);
            totalGames = await _northwindDbContext.Products.GetCountAsync(filters);

            return totalGames;
        }

        public async Task<ItemPageDTO<GameDTO>> GetRangeOfGamesAsync(GameFilterDTO gameFilterDTO)
        {
            List<Expression<Func<Game, bool>>> filtersFromStore = await _gameFilterService.GetFiltersForGameStore(gameFilterDTO);
            List<Expression<Func<Game, bool>>> filtersFromNorthwind = await _gameFilterService.GetFiltersForNorthwind(gameFilterDTO);
            Expression<Func<Game, object>> order = _gameFilterService.Sort(gameFilterDTO.SortingType);

            bool orderDesc = gameFilterDTO.SortingType != SortingType.PriceAsc ? false : true;
            int totalGames = await _unitOfWork.GameRepository.CountListAsync(filtersFromStore);
            totalGames += await _northwindDbContext.Products.GetCountAsync(filtersFromNorthwind);
            gameFilterDTO.Page = PaginationHelper<Game>.CheckCurrentPage(gameFilterDTO.Page, gameFilterDTO.ElementsOnPage, totalGames);

            var filteredGames = await _unitOfWork.GameRepository.GetFilteredListAsync(
                 filtersFromStore,
                 g => g.Genres, g => g.Publisher, g => g.PlatformTypes, g => g.Comments);

            var northwindGames = await GetNorthwindGames(filtersFromNorthwind);
            filteredGames.AddRange(northwindGames);
            filteredGames.DistinctBy(g => g.Key);
            var gamesOnPage = filteredGames.SortByParameter(order, orderDesc).GetPage(gameFilterDTO.Page, gameFilterDTO.ElementsOnPage);

            var mappedGames = _mapper.Map<List<GameDTO>>(gamesOnPage);
            ItemPageDTO<GameDTO> gamePage = PaginationHelper<GameDTO>.CreatePage(gameFilterDTO.Page, gameFilterDTO.ElementsOnPage, totalGames, mappedGames);

            return gamePage;
        }

        private async Task<List<Game>> GetNorthwindGames(List<Expression<Func<Game, bool>>> filters)
        {
            var northwindGames = await _northwindDbContext.Products.GetFilteredListAsync(filters);
            foreach (var item in northwindGames)
            {
                if (item.Key == null)
                {
                    item.Key = CreateGameKey(item.Name);
                    await _northwindDbContext.Products.UpdateAsync(item);
                }
            }
            return northwindGames;
        }

        public async Task<GameDTO> GetGameAsync(string gameKey, bool isView)
        {
            Game searchedGame = await _unitOfWork.GameRepository.GetAsync(game => game.Key == gameKey, p => p.PlatformTypes, g => g.Genres, pub => pub.Publisher);
            searchedGame = searchedGame == null ? await _northwindDbContext.Products.GetAsync(g => g.Key == gameKey) : searchedGame;

            if (searchedGame == null)
                throw new KeyNotFoundException();

            if (searchedGame.TypeOfBase == TypeOfBase.GameStore && isView)
            {
                searchedGame.NumberOfViews += 1;
                await _unitOfWork.SaveAsync();
            }
            else if (searchedGame.TypeOfBase == TypeOfBase.Northwind && isView)
            {
                searchedGame.NumberOfViews += 1;
                await _northwindDbContext.Products.UpdateAsync(searchedGame);
            }

            return _mapper.Map<GameDTO>(searchedGame);
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
            Game gameByKey = await _unitOfWork.GameRepository.GetAsync(g => g.Key == updateGameDTO.Key);

            if (gameByKey != null)
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
            else
            {
                var mappedGame = _mapper.Map<AddGameDTO>(updateGameDTO);
                GameDTO addedGame = await AddGameAsync(mappedGame);

                return addedGame;
            }
        }

        private string CreateGameKey(string name)
        {
            var key = name.Trim().ToLower().Replace(" ", "-");
            return key;
        }
    }
}