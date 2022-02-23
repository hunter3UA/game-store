using AutoMapper;
using GameStore.BLL.DTO;
using GameStore.BLL.Mapper;
using GameStore.BLL.Services.Abstract;
using GameStore.DAL.Models;
using GameStore.DAL.UoW;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace GameStore.BLL.Services
{
    public class GameService : IGameService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHostingEnvironment _env;
        private IMapper _mapper;
        public GameService(IUnitOfWork unitOfWork, IHostingEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _mapper = AutoMapperConfig.Configure().CreateMapper();
            _env = env;
        }

        public async Task<GameDTO> AddAsync(AddGameDTO gameToAddDTO)
        {
            try
            {
                if (gameToAddDTO != null)
                {
                    Game gameToAdd = _mapper.Map<Game>(gameToAddDTO);
                    gameToAdd.Genres = await _unitOfWork.GenreRepository.GetListAsync(g => gameToAddDTO.GenresID.Contains(g.GenreId));
                    gameToAdd.PlatformTypes = await _unitOfWork.PlatformRepository.GetListAsync(p => gameToAddDTO.PlatformsId.Contains(p.PlatformTypeId));
                    await _unitOfWork.GameRepository.AddAsync(gameToAdd);
                    await _unitOfWork.SaveAsync();
                    return _mapper.Map<GameDTO>(gameToAdd);

                }
                return new GameDTO();
            }
            catch
            {
                return new GameDTO();
            }
        }

        public async Task<List<GameDTO>> GetLisAsync()
        {
            List<Game> games = await _unitOfWork.GameRepository.GetListAsync();
            return games != null ? _mapper.Map<List<GameDTO>>(games) : new List<GameDTO>();

        }

        public async Task<GameDTO> GetAsync(Expression<Func<Game, bool>> predicate)
        {
            Game game = await _unitOfWork.GameRepository.GetAsync(predicate);
            return game != null ? _mapper.Map<GameDTO>(game) : new GameDTO();
        }
        public async Task<bool> RemoveAsync(Expression<Func<Game, bool>> predicate)
        {
            return await _unitOfWork.GameRepository.RemoveAsync(predicate);
        }

        public async Task<GameDTO> UpdateAsync(UpdateGameDTO updateGameDTO)
        {
            try
            {
                Game gameToUpdate = await _unitOfWork.GameRepository.GetAsync(g => g.GameId == updateGameDTO.GameId);
                if (gameToUpdate != null)
                {
                    gameToUpdate.Name = updateGameDTO.Name;
                    gameToUpdate.Description = updateGameDTO.Description;
                    gameToUpdate.Genres = await _unitOfWork.GenreRepository.GetListAsync(g => updateGameDTO.GenresID.Contains(g.GenreId));
                    gameToUpdate.PlatformTypes = await _unitOfWork.PlatformRepository.GetListAsync(p => updateGameDTO.PlatformsId.Contains(p.PlatformTypeId));
                    await _unitOfWork.SaveAsync();
                    return _mapper.Map<GameDTO>(gameToUpdate);  
                }
                return new GameDTO();
            }
            catch
            {
                return new GameDTO();
            }
        }
    
        
        
    }
}
