using GameStore.API.Static;
using GameStore.BLL.DTO;
using GameStore.BLL.Services;
using GameStore.BLL.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.HttpOverrides;

namespace GameStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {

        private readonly IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost]
        [Route("/games/new")]
        [ResponseCache(CacheProfileName = "Caching")]
        public async Task<GameDTO> AddGameAsync([FromBody] AddGameDTO addGameDTO)
        {

            var addedGame = await _gameService.AddGameAsync(addGameDTO);
            return addedGame;
        }


        [HttpGet]
        [Route("/games")]
        [ResponseCache(CacheProfileName = "Caching")]
        public async Task<List<GameDTO>> GetListOfGamesAsync()
        {
            var listOfGames = await _gameService.GetListOfGamesAsync();
            return listOfGames;
        }

        [HttpGet]
        [Route("/game/{key}")]
        [ResponseCache(CacheProfileName = "Caching")]
        public async Task<GameDTO> GetGameAsync([FromRoute] int key)
        {
            var gameByKey = await _gameService.GetGameAsync(g => g.GameId == key);
            return gameByKey;
        }


        [HttpPut]
        [Route("/games/update")]
        public async Task<GameDTO> UpdateGameAsync([FromBody] UpdateGameDTO gameToUpdate)
        {
            var updatedGame = await _gameService.UpdateGameAsync(gameToUpdate);
            return updatedGame;
        }


        [HttpPut]
        [Route("/games/remove/{key}")]
        public async Task<bool> RemoveGameAsync([FromRoute] int key)
        {
            bool isRemovedGame = await _gameService.RemoveGameAsync(key);
            return isRemovedGame;
        }

        [HttpGet]
        [Route("/game/{gameKey}/download")]
        [ResponseCache(CacheProfileName = "Caching")]
        public async Task<IActionResult> DownloadGameAsync([FromRoute] int gameKey)
        {
            var data = await _gameService.DownloadFileAsync(gameKey);
            return File(data, Constants.TEXT_PLAIN_CONTENT_TYPE, Constants.GAME_FILE_NAME);
        }


    }
}
