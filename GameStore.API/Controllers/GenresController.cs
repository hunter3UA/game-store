using System.Collections.Generic;
using System.Threading.Tasks;
using GameStore.API.Static;
using GameStore.BLL.DTO;
using GameStore.BLL.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpPost]
        [Route("/genres/add")]
        public async Task<IActionResult> AddGenreAsync([FromBody] AddGenreDTO addGenreDTO)
        {
            var addedGenre = await _genreService.AddGenreAsync(addGenreDTO);

            if (addedGenre == null)
            {
                return BadRequest();
            }

            return Ok(addedGenre);
        }

        [HttpGet]
        [Route("/genres/getall")]
        [ResponseCache(CacheProfileName = Constants.CACHING_PROFILE_NAME)]
        public async Task<IActionResult> GetAllGenresAsync()
        {
            var allGenres = await _genreService.GetListOfGenresAsync();

            if (allGenres == null)
            {
                return NotFound();
            }

            return Ok(allGenres);
        }

        [HttpGet]
        [Route("/genres")]
        [ResponseCache(CacheProfileName = Constants.CACHING_PROFILE_NAME)]
        public async Task<IActionResult> GetGenreAsync([FromQuery] int id)
        {
            var genreByKey = await _genreService.GetGenreAsync(g => g.Id == id);

            if (genreByKey == null)
            {
                return NotFound();
            }

            return Ok(genreByKey);
        }

        [HttpPut]
        [Route("/genres/remove")]
        public async Task<IActionResult> RemoveGenreAsync([FromQuery] int id)
        {
            var isRemovedGenre = await _genreService.RemoveGenreAsync(id);

            if (!isRemovedGenre)
            {
                return NotFound(isRemovedGenre);
            }

            return Ok($"{isRemovedGenre}.Genre with Id {id} has been deleted");
        }
    }
}
