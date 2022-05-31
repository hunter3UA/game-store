using System.Threading.Tasks;
using GameStore.BLL.DTO.Genre;
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
        [Route("/genres/new")]
        public async Task<IActionResult> AddGenreAsync([FromBody] AddGenreDTO addGenreDTO)
        {
            var addedGenre = await _genreService.AddGenreAsync(addGenreDTO);

            if (addedGenre == null)
            {
                return BadRequest();
            }

            return new JsonResult(addedGenre);
        }

        [HttpGet]
        [Route("/genres")]
        public async Task<IActionResult> GetAllGenresAsync()
        {
            var allGenres = await _genreService.GetListOfGenresAsync();

            if (allGenres == null)
            {
                return NotFound();
            }

            return new JsonResult(allGenres);
        }

        [HttpGet]
        [Route("/genres/{id}")]
        public async Task<IActionResult> GetGenreAsync([FromRoute] int id)
        {
            var genreByKey = await _genreService.GetGenreAsync(id);

            if (genreByKey == null)
            {
                return NotFound();
            }

            return new JsonResult(genreByKey);
        }

        [HttpPut]
        [Route("/genres/update")]
        public async Task<IActionResult> UpdateGenreAsync([FromBody] UpdateGenreDTO updateGenreDTO)
        {
            var updatedGenre = await _genreService.UpdateGenreAsync(updateGenreDTO);

            if (updatedGenre == null)
            {
                return BadRequest();
            }

            return new JsonResult(updatedGenre);
        }

        [HttpDelete]
        [Route("/genres/remove/{id}")]
        public async Task<IActionResult> RemoveGenreAsync([FromRoute] int id)
        {
            var isRemovedGenre = await _genreService.RemoveGenreAsync(id);

            if (!isRemovedGenre)
            {
                return NotFound(isRemovedGenre);
            }

            return Ok();
        } 
    }
}
