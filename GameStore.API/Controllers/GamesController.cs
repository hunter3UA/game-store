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
using Newtonsoft.Json.Linq;

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
        public async Task<ActionResult<GameDTO>> AddGameAsync([FromBody] AddGameDTO addGameDTO)
        {

            var addedGame = await _gameService.AddGameAsync(addGameDTO);
            if (addedGame == null)
                return BadRequest();
            return Ok(addedGame);
        }

        [HttpGet]
        [Route("/games")]
        [ResponseCache(CacheProfileName = Constants.CACHING_PROFILE_NAME)]
        public async Task<ActionResult<List<GameDTO>>> GetListOfGamesAsync()
        {
            var listOfGames = await _gameService.GetListOfGamesAsync();
            if (listOfGames == null)
                return NotFound();

            return Ok(listOfGames);
        }

        [HttpGet]
        [Route("/game/{key}")]
        [ResponseCache(CacheProfileName = Constants.CACHING_PROFILE_NAME)]
        public async Task<ActionResult<GameDTO>> GetGameAsync([FromRoute] string key)
        {
            var gameByKey = await _gameService.GetGameAsync(g => g.Key == key);
            if (gameByKey == null)
                return NotFound();

            return Ok(gameByKey);
        }

        [HttpPut]
        [Route("/games/update")]
        public async Task<ActionResult<GameDTO>> UpdateGameAsync([FromBody] UpdateGameDTO gameToUpdate)
        {
            var updatedGame = await _gameService.UpdateGameAsync(gameToUpdate);
            if (updatedGame == null)
                return BadRequest();

            return Ok(updatedGame);
        }

        [HttpDelete]
        [Route("/games/remove/{key}")]
        public async Task<ActionResult<bool>> RemoveGameAsync([FromRoute] string key)
        {
            bool isRemovedGame = await _gameService.RemoveGameAsync(key);
            if (!isRemovedGame)
                return NotFound(isRemovedGame);

            return Ok($"{isRemovedGame}. Game with Id {key} has been deleted");

        }

        [HttpGet]
        [Route("/game/{gameKey}/download")]
        [ResponseCache(CacheProfileName = Constants.CACHING_PROFILE_NAME)]
        public async Task<IActionResult> DownloadGameAsync([FromRoute] string gameKey)
        {
            var data = await _gameService.DownloadFileAsync(gameKey);

            return File(data, Constants.TEXT_PLAIN_CONTENT_TYPE, Constants.GAME_FILE_NAME);
        }
    }
}
