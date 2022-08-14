using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using GameStore.API.Auth;
using GameStore.API.Static;
using GameStore.BLL.DTO.Game;
using GameStore.BLL.Services.Abstract.Games;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.API.Controllers
{
    [Route("api/games")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost]
        [Route("new")]
        [Authorize(Roles = ApiRoles.ManagerRole)]
        public async Task<IActionResult> AddAsync([FromBody] AddGameDTO addGameDTO)
        {
            var addedGame = await _gameService.AddGameAsync(addGameDTO);

            return new JsonResult(addedGame);
        }

        [HttpGet]
        [Route("count")]
        public async Task<IActionResult> GetCountAsync()
        {
            var countOfGames = await _gameService.GetCountAsync();

            return Ok(countOfGames);
        }

        [HttpGet]
        public async Task<IActionResult> GetRangeAsync([FromQuery] GameFilterDTO gameFilterDTO)
        {
            var listOfGames = await _gameService.GetRangeOfGamesAsync(gameFilterDTO);

            return new JsonResult(listOfGames);
        }

        [HttpGet]
        [Route("{key}")]
        public async Task<IActionResult> GetAsync([FromRoute] string key, [FromQuery] bool isView)
        {
            var gameByKey = await _gameService.GetGameAsync(key, isView);

            return new JsonResult(gameByKey);
        }

        [HttpPut]
        [Route("update")]
        [Authorize(Roles = ApiRoles.PublisherRole)]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateGameDTO gameToUpdate)
        {
            var updatedGame = await _gameService.UpdateGameAsync(gameToUpdate);

            return new JsonResult(updatedGame);
        }

        [HttpDelete]
        [Route("remove/{key}")]
        [Authorize(Roles =ApiRoles.ManagerRole)]
        public async Task<IActionResult> RemoveAsync([FromRoute] string key)
        {
            await _gameService.RemoveGameAsync(key);

            return Ok();
        }

        [HttpGet]
        [Route("{gameKey}/download")]
        [ResponseCache(CacheProfileName = Constants.CachingProfileName)]
        public IActionResult DownloadGameFile([FromRoute] string gameKey)
        {
            string path = Directory.GetCurrentDirectory();

            return PhysicalFile($"{path}\\wwwroot\\Game.txt", Constants.TextPlainContentType, Constants.GameFileName);
        }
    }
}
