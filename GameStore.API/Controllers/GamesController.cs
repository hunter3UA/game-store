using System.IO;
using System.Threading.Tasks;
using GameStore.API.Static;
using GameStore.BLL.DTO.Game;
using GameStore.BLL.Services.Abstract;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> AddGameAsync([FromBody] AddGameDTO addGameDTO)
        {
            var addedGame = await _gameService.AddGameAsync(addGameDTO);

            if (addedGame == null)
            {
                return BadRequest();
            }

            return new JsonResult(addedGame);
        }

        [HttpGet]
        [Route("/games")]
        public async Task<IActionResult> GetListOfGamesAsync()
        {
            var listOfGames = await _gameService.GetListOfGamesAsync();

            if (listOfGames == null)
            {
                return NotFound();
            }

            return new JsonResult(listOfGames);
        }

        [HttpGet]
        [Route("/game/{key}")]
        public async Task<IActionResult> GetGameAsync([FromRoute] string key)
        {
            var gameByKey = await _gameService.GetGameAsync(key);

            if (gameByKey == null)
            {
                return NotFound();
            }

            return new JsonResult(gameByKey);
        }

        [HttpPut]
        [Route("/games/update")]
        public async Task<IActionResult> UpdateGameAsync([FromBody] UpdateGameDTO gameToUpdate)
        {
            var updatedGame = await _gameService.UpdateGameAsync(gameToUpdate);

            if (updatedGame == null)
            {
                return BadRequest();
            }

            return new JsonResult(updatedGame);
        }

        [HttpDelete]
        [Route("/games/remove/{id}")]
        public async Task<IActionResult> RemoveGameAsync([FromRoute] int id)
        {
            bool isRemovedGame = await _gameService.RemoveGameAsync(id);

            if (!isRemovedGame)
            {
                return NotFound(isRemovedGame);
            }

            return Ok();
        }

        [HttpGet]
        [Route("/games/{gameKey}/download")]
        [ResponseCache(CacheProfileName = Constants.CACHING_PROFILE_NAME)]
        public IActionResult DownloadGameFile([FromRoute] string gameKey)
        {
            string path = Directory.GetCurrentDirectory();

            return PhysicalFile($"{path}\\wwwroot\\Game.txt", Constants.TEXT_PLAIN_CONTENT_TYPE, Constants.GAME_FILE_NAME);
        }
    }
}
