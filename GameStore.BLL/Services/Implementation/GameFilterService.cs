using AutoMapper;
using GameStore.BLL.DTO.Common;
using GameStore.BLL.DTO.Game;
using GameStore.BLL.Enum;
using GameStore.BLL.Services.Abstract;
using GameStore.DAL.Entities;
using GameStore.DAL.UoW.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GameStore.BLL.Services.Implementation
{
    public class GameFilterService:IGameFilterService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GameFilterService(IUnitOfWork unitOfWork,IMapper _mapper)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Expression<Func<Game, bool>>>> GetFilteredGames(GameFilterDTO gameFilterDTO)
        {
            List<Expression<Func<Game, bool>>> filters = new List<Expression<Func<Game, bool>>>();

            if (!string.IsNullOrEmpty(gameFilterDTO.Name))
                filters.Add(g => g.Name.ToLower().Contains(gameFilterDTO.Name.ToLower()));
            
            if (gameFilterDTO.Genres != null)
            {
                gameFilterDTO.Genres = await GetAllGenresByFilter(gameFilterDTO.Genres);
                filters.Add(g => g.Genres.Any(gf => gameFilterDTO.Genres.Any(filter => filter == gf.Id)));
            }

            if (gameFilterDTO.Platforms != null)
                filters.Add(g => g.PlatformTypes.Any(gf => gameFilterDTO.Platforms.Any(filter => filter == gf.Id)));
            
            if (gameFilterDTO.Publishers != null)
                filters.Add(g => gameFilterDTO.Publishers.Contains((int)g.PublisherId));
            
            if (gameFilterDTO.MinPrice != null)
                filters.Add(g => g.Price >= gameFilterDTO.MinPrice);
            
            if (gameFilterDTO.MaxPrice != null)
                filters.Add(g => g.Price <= gameFilterDTO.MaxPrice);
            
            if (gameFilterDTO.PublishingDate != null)          
                filters.Add(DateFilter((PublishingDate)gameFilterDTO.PublishingDate));
            
            return filters;
        }

        public Expression<Func<Game, object>> Sort(SortingType sortingType)
        {
            Expression<Func<Game, object>> expression = null;
            switch (sortingType)
            {
                case SortingType.Popularity:
                    {
                        expression = g => g.NumberOfViews;
                        break;
                    }
                case SortingType.Commented:
                    {
                        expression = g => g.Comments.Where(c => !c.IsDeleted).Count();
                        break;
                    }
                case SortingType.PriceAsc:
                    {
                        expression = g => g.Price;
                        break;
                    }
                case SortingType.PriceDesc:
                    {
                        expression = g => g.Price;
                        break;
                    }
                case SortingType.Publishing:
                    {
                        expression = g => g.AddedAt;
                        break;
                    }
            }

            return expression;
        }

        public ItemPageDTO<GameDTO> GetGamePage(List<Game> filteredGames, GameFilterDTO gameFilterDTO)
        {
        
            List<Game> gamesByPage = filteredGames.Skip(((gameFilterDTO.Page - 1) * gameFilterDTO.ElementsOnPage)).Take(gameFilterDTO.ElementsOnPage).ToList();

            ItemPageDTO<GameDTO> gamePage = new ItemPageDTO<GameDTO>
            {
                Items = _mapper.Map<List<GameDTO>>(gamesByPage),
                PageInfo = new PageInfoDTO() { ElementsOnPage = gameFilterDTO.ElementsOnPage, CurrentPageNumber = gameFilterDTO.Page, TotalItems = filteredGames.Count() }
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

        private Expression<Func<Game, bool>> DateFilter(PublishingDate publishingDate)
        {
            Expression<Func<Game, bool>> filter = null;
            switch (publishingDate)
            {
                case PublishingDate.Week:
                    {
                        filter = g => g.AddedAt > DateTime.UtcNow.AddDays(-7);
                        return filter;
                    }
                case PublishingDate.Month:
                    {
                        filter = g => g.AddedAt > DateTime.UtcNow.AddMonths(-1);
                        return filter;
                    }
                case PublishingDate.Year:
                    {
                        filter = g => g.AddedAt > DateTime.UtcNow.AddYears(-1);
                        return filter;
                    }
                case PublishingDate.TwoYears:
                    {
                        filter = g => g.AddedAt > DateTime.UtcNow.AddYears(-2);
                        return filter;
                    }
                case PublishingDate.ThreeYears:
                    {
                        filter = g => g.AddedAt > DateTime.UtcNow.AddYears(-3);
                        return filter;
                    }
            }

            return filter;
        }
    }
}
