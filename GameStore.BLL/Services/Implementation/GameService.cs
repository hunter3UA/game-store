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
using GameStore.BLL.Services.Abstract;
using GameStore.DAL.Entities;
using GameStore.DAL.UoW.Abstract;
using Microsoft.Extensions.Logging;

namespace GameStore.BLL.Services.Implementation
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

        public async Task<ItemPageDTO<GameDTO>> GetRangeOfGamesAsync(GameFilterDTO gameFilterDTO)
        {
            List<Expression<Func<Game, bool>>> filters = await _gameFilterService.GetFilteredGames(gameFilterDTO);
            Expression<Func<Game, object>> order=null;
            if (gameFilterDTO.SortingType != null)
                  order = _gameFilterService.Sort((SortingType)gameFilterDTO.SortingType);
          
            bool orderDesc = gameFilterDTO.SortingType != SortingType.PriceAsc ? false : true;

            var totalGames = await _unitOfWork.GameRepository.GetFilteredList(filters,
                    0, int.MaxValue,
                    false,
                    order);

            var gamesOnPage = await _unitOfWork.GameRepository.GetFilteredList(
                 filters,
                 ((gameFilterDTO.Page - 1) * gameFilterDTO.ElementsOnPage),
                 gameFilterDTO.ElementsOnPage,
                 orderDesc,
                 order,
                 g => g.Genres, g => g.Publisher, g => g.PlatformTypes);

            var mappedGames = _mapper.Map<List<GameDTO>>(gamesOnPage);
            ItemPageDTO<GameDTO> gamePage = PaginationHelper<GameDTO>.CreatePage(gameFilterDTO.Page, gameFilterDTO.ElementsOnPage, totalGames.Count(), mappedGames);

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
/*public class GameService : IGameService
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

        public async Task<GamePageDTO> GetRangeOfGamesAsync(GameFilterDTO gameFilterDTO)
        {
            List<Game> allGames = await _unitOfWork.GameRepository.GetListAsync(g => g.Genres, p => p.PlatformTypes, pb => pb.Publisher);
            List<Expression<Func<Game, bool>>> ex = new List<Expression<Func<Game, bool>>>();
            if (!string.IsNullOrEmpty(gameFilterDTO.Name))
                allGames = allGames.Where(g => g.Name.ToLower().Contains(gameFilterDTO.Name.ToLower())).ToList();

            if (gameFilterDTO.Genres != null)
            {              
                gameFilterDTO.Genres = await GetAllGenresByFilter(gameFilterDTO.Genres);
                Expression<Func<Game, bool>> genreExpresion = (g) => g.Genres.Any(gf => gameFilterDTO.Genres.Any(filter => filter == gf.Id));
                allGames = allGames.Where(g => g.Genres.Any(gf => gameFilterDTO.Genres.Any(filter => filter == gf.Id))).ToList();
            }

            if (gameFilterDTO.Platforms != null)
                allGames = allGames.Where(g => g.PlatformTypes.Any(gf => gameFilterDTO.Platforms.Any(filter => filter == gf.Id))).ToList();

            if (gameFilterDTO.Publishers != null)
                allGames = allGames.Where(g => gameFilterDTO.Publishers.Contains((int)g.PublisherId)).ToList();

            if (gameFilterDTO.MinPrice != null)
                allGames = allGames.Where(g => g.Price >= gameFilterDTO.MinPrice).ToList();

            if (gameFilterDTO.MaxPrice != null)
                allGames = allGames.Where(g => g.Price <= gameFilterDTO.MaxPrice).ToList();

            if (gameFilterDTO.SortingType != null)
                allGames = Sort(gameFilterDTO.SortingType, allGames);

            if (gameFilterDTO.PublishingDate != null)
                allGames = DateFilter(gameFilterDTO.PublishingDate, allGames);

            GamePageDTO gamePage = GetGamePage(allGames, gameFilterDTO);

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

        private GamePageDTO GetGamePage(List<Game> filteredGames, GameFilterDTO gameFilterDTO)
        {
            if (gameFilterDTO.ElementsOnPage == null)
                gameFilterDTO.ElementsOnPage = 10;

            if (gameFilterDTO.Page == null)
                gameFilterDTO.Page = 1;

            List<Game> gamesByPage = filteredGames.Skip((int)((gameFilterDTO.Page - 1) * gameFilterDTO.ElementsOnPage)).Take((int)gameFilterDTO.ElementsOnPage).ToList();

            GamePageDTO gamePage = new GamePageDTO
            {
                Games = _mapper.Map<List<GameDTO>>(gamesByPage),
                PageInfo = new PageInfoDTO() { ElementsOnPage = (int)gameFilterDTO.ElementsOnPage, CurrentPageNumber = (int)gameFilterDTO.Page, TotalItems = filteredGames.Count() }
            };

            return gamePage;
        }

        private async Task<List<int>> GetAllGenresByFilter(List<int> defaultGenres)
        {
            List<int> resultGenres = new List<int>();
            foreach (var genre in defaultGenres)
            {
                Genre byId = await _unitOfWork.GenreRepository.GetAsync(g => g.Id == genre, g => g.SubGenres);
                if (!resultGenres.Any(res => res == byId.Id))
                    resultGenres.Add(byId.Id);

                if (byId.SubGenres.Any())
                {
                    var result = await GetAllGenresByFilter(byId.SubGenres.Select(g => g.Id).ToList());
                    resultGenres.AddRange(result);
                }
            }
            return resultGenres;
        }

        private List<Game> Sort(SortingType? sortingType, List<Game> gamesList)
        {
            switch (sortingType)
            {
                case SortingType.Popularity:
                    {
                        gamesList = gamesList.OrderByDescending(g => g.NumberOfViews).ToList();
                        break;
                    }
                case SortingType.Commented:
                    {
                        gamesList = gamesList.OrderByDescending(g => g.Comments.Where(c => !c.IsDeleted).Count()).ToList();
                        break;
                    }
                case SortingType.PriceAsc:
                    {
                        gamesList = gamesList.OrderBy(g => g.Price).ToList();
                        break;
                    }
                case SortingType.PriceDesc:
                    {
                        gamesList = gamesList.OrderByDescending(g => g.Price).ToList();
                        break;
                    }
                case SortingType.Publishing:
                    {
                        gamesList = gamesList.OrderBy(g => g.AddedAt).ToList();
                        break;
                    }
            }

            return gamesList;
        }

        private List<Game> DateFilter(PublishingDate? publishingDate, List<Game> gameList)
        {
            switch (publishingDate)
            {
                case PublishingDate.Week:
                    {
                        gameList = gameList.Where(g => g.AddedAt > DateTime.UtcNow.AddDays(-7)).ToList();
                        break;
                    }
                case PublishingDate.Month:
                    {
                        gameList = gameList.Where(g => g.AddedAt > DateTime.UtcNow.AddMonths(-1)).ToList();
                        break;
                    }
                case PublishingDate.Year:
                    {
                        gameList = gameList.Where(g => g.AddedAt > DateTime.UtcNow.AddYears(-1)).ToList();
                        break;
                    }
                case PublishingDate.TwoYears:
                    {
                        gameList = gameList.Where(g => g.AddedAt > DateTime.UtcNow.AddYears(-2)).ToList();
                        break;
                    }
                case PublishingDate.ThreeYears:
                    {
                        gameList = gameList.Where(g => g.AddedAt > DateTime.UtcNow.AddYears(-3)).ToList();
                        break;
                    }
            }
            return gameList;
        }
    }*/