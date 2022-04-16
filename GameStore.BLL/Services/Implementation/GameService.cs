using AutoMapper;
using GameStore.BLL.DTO;
using GameStore.BLL.Mapper;
using GameStore.BLL.Services.Abstract;
using GameStore.DAL.Entities;
using GameStore.DAL.UoW;
using GameStore.DAL.UoW.Abstract;
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


namespace GameStore.BLL.Services.Implementation
{
    public class GameService : IGameService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHostEnvironment _env;
        private readonly ILogger<GameService> _logger;

        private IMapper _mapper;
        public GameService(IUnitOfWork unitOfWork, IHostEnvironment env, ILogger<GameService> logger,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _env = env;
            _logger = logger;
        }

        public async Task<GameDTO> AddGameAsync(AddGameDTO gameToAddDTO)
        {

            Game gameToAdd = _mapper.Map<Game>(gameToAddDTO);
            gameToAdd.Genres = await _unitOfWork.GenreRepository.GetListOfGenresAsync(g => gameToAddDTO.GenresID.Contains(g.GenreId));
            gameToAdd.PlatformTypes = await _unitOfWork.PlatformTypeRepository.GetListOfPlatformTypesAsync(p => gameToAddDTO.PlatformsId.Contains(p.PlatformTypeId));
            if (gameToAdd.Genres.Count() <= 0 || gameToAdd.PlatformTypes.Count() <= 0)
                throw new Exception("Genres and PlatformTypes can not be empty");
            gameToAdd = await _unitOfWork.GameRepository.AddGameAsync(gameToAdd);
            await _unitOfWork.SaveAsync();
            _logger.LogInformation($"Game has been added with Id: {gameToAdd.GameId}");
            return _mapper.Map<GameDTO>(gameToAdd);


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
        public async Task<bool> RemoveGameAsync(int key)
        {
            bool isRemovedGame = false;
            isRemovedGame = await _unitOfWork.GameRepository.RemoveGameAsync(key);
            await _unitOfWork.SaveAsync();  
            if (isRemovedGame)
                _logger.LogInformation("The game has been deleted");
            else
                _logger.LogInformation("The game has not been deleted");
            return isRemovedGame;
        }

        public async Task<GameDTO> UpdateGameAsync(UpdateGameDTO updateGameDTO)
        {

            Game gameToUpdate = await _unitOfWork.GameRepository.GetGameAsync(g => g.GameId == updateGameDTO.GameId);
            gameToUpdate.Name = updateGameDTO.Name;
            gameToUpdate.Description = updateGameDTO.Description;
            gameToUpdate.Genres = await _unitOfWork.GenreRepository.GetListOfGenresAsync(g => updateGameDTO.GenresID.Contains(g.GenreId));
            gameToUpdate.PlatformTypes = await _unitOfWork.PlatformTypeRepository.GetListOfPlatformTypesAsync(p => updateGameDTO.PlatformsId.Contains(p.PlatformTypeId));
            if (gameToUpdate.PlatformTypes.Count() <= 0 || gameToUpdate.Genres.Count() <= 0)
                throw new Exception("Genres and PlatformTypes can not be empty");
            await _unitOfWork.SaveAsync();
            _logger.LogInformation($"Game with Id:{gameToUpdate.GameId} has been updated");
            return _mapper.Map<GameDTO>(gameToUpdate);

        }



        public async Task<byte[]> DownloadFileAsync(int gameKey)
        {

            string filePath = Path.Combine(_env.ContentRootPath, "wwwroot");
            var bytes = await File.ReadAllBytesAsync(filePath + "\\file.txt");
            return bytes;

        }


    }
}
