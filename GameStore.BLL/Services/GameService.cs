using AutoMapper;
using GameStore.BLL.DTO;
using GameStore.BLL.Mapper;
using GameStore.BLL.Services.Abstract;
using GameStore.DAL.Models;
using GameStore.DAL.UoW;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
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
        private readonly IHostEnvironment _env;
        private readonly ILogger<GameService> _logger;

        private IMapper _mapper;
        public GameService(IUnitOfWork unitOfWork, IHostEnvironment env, ILogger<GameService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = AutoMapperConfig.Configure().CreateMapper();
            _env = env;
            _logger = logger;
        }

        public async Task<GameDTO> AddAsync(AddGameDTO gameToAddDTO)
        {
            try
            {
                if (gameToAddDTO == null)
                    throw new ArgumentNullException("AddGameDTO can not be null");
                Game gameToAdd = _mapper.Map<Game>(gameToAddDTO);
                gameToAdd.Genres = await _unitOfWork.GenreRepository.GetListAsync(g => gameToAddDTO.GenresID.Contains(g.GenreId));
                gameToAdd.PlatformTypes = await _unitOfWork.PlatformRepository.GetListAsync(p => gameToAddDTO.PlatformsId.Contains(p.PlatformTypeId));
                if (gameToAdd.Genres.Count <= 0 || gameToAdd.PlatformTypes.Count <= 0)
                    throw new Exception("Genres and PlatformTypes can not be empty");
                await _unitOfWork.GameRepository.AddAsync(gameToAdd);
                await _unitOfWork.SaveAsync();
                _logger.LogInformation($"Game has been added with Id: {gameToAdd.GameId}");
                return _mapper.Map<GameDTO>(gameToAdd);
            }
            catch (Exception ex)
            {               
                _logger.LogError($"Error: {ex.Message}, \n {ex.StackTrace}");
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
            bool removedGame = false;
            try
            {
                removedGame = await _unitOfWork.GameRepository.RemoveAsync(predicate);
                if (removedGame)
                    _logger.LogInformation("The game has been deleted");
                else
                    _logger.LogInformation("The game has not been deleted");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}, \n {ex.StackTrace}"); ;
            }
            return removedGame;
        }

        public async Task<GameDTO> UpdateAsync(UpdateGameDTO updateGameDTO)
        {
            try
            {
                Game gameToUpdate = await _unitOfWork.GameRepository.GetAsync(g => g.GameId == updateGameDTO.GameId);
                if (gameToUpdate == null)
                    throw new ArgumentNullException("The game for update cannot be null");
                gameToUpdate.Name = updateGameDTO.Name;
                gameToUpdate.Description = updateGameDTO.Description;
                gameToUpdate.Genres = await _unitOfWork.GenreRepository.GetListAsync(g => updateGameDTO.GenresID.Contains(g.GenreId));
                gameToUpdate.PlatformTypes = await _unitOfWork.PlatformRepository.GetListAsync(p => updateGameDTO.PlatformsId.Contains(p.PlatformTypeId));
                if (gameToUpdate.PlatformTypes.Count <= 0 || gameToUpdate.Genres.Count <= 0)
                    throw new Exception("Genres and PlatformTypes can not be empty");         
                await _unitOfWork.SaveAsync();
                _logger.LogInformation($"Game with Id:{gameToUpdate.GameId} has been updated");
                return _mapper.Map<GameDTO>(gameToUpdate);           
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}, \n {ex.StackTrace}");
                return new GameDTO();
            }
        }



        public async Task<byte[]> DownloadFile(int gameKey)
        {
            try
            {
                string filePath = Path.Combine(_env.ContentRootPath, "wwwroot");
                var bytes = await File.ReadAllBytesAsync(filePath + "\\file.txt");
                return bytes;
            }catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}, \n {ex.StackTrace}");
                return new byte[0];
            }
        }


    }
}
