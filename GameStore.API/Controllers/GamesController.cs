using GameStore.BLL.DTO;
using GameStore.BLL.Services;
using GameStore.BLL.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace GameStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {

        private IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost]
        [Route("/Games/New")]
        public async Task<GameDTO> Post([FromBody] AddGameDTO addGameDTO)
        {
            return await _gameService.AddAsync(addGameDTO);
        }

     
        [HttpGet]
        [Route("/Games/Get")]
        public async Task<List<GameDTO>> Get()
        {
            return await _gameService.GetLisAsync();
        }
      
        [HttpGet]
        [Route("/Game/{key}")]
        public async Task<GameDTO> GetByKey(Guid key)
        {          
            return await _gameService.GetAsync(g => g.GameId == key);
        }

       
        [HttpPut]
        [Route("/Games/Update")]
        public async Task<GameDTO> Update([FromBody] UpdateGameDTO gameToUpdate)
        {
            return await _gameService.UpdateAsync(gameToUpdate);
        }
        
       
        [HttpPut]
        [Route("/Games/Remove/{key}")]
        public async Task<bool> Remove(Guid key)
        {
            return await _gameService.RemoveAsync(g=>g.GameId == key);
        }

        [HttpGet]
        [Route("/Games/Download/{gameKey}")]
        public async Task<IActionResult> Download(int gameKey)
        {
            return File(await _gameService.DownloadFile(gameKey),"text/plain","Game.txt");
        }

       
    }
}
