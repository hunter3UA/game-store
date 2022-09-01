using System.Threading.Tasks;
using GameStore.API.Auth;
using GameStore.BLL.DTO.Genre;
using GameStore.BLL.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.API.Controllers
{
    [Route("api/genres")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpPost]
        [Route("new")]
        [Authorize(Roles = ApiRoles.ManagerRole)]
        public async Task<IActionResult> AddAsync([FromBody] AddGenreDTO addGenreDTO)
        {
            var addedGenre = await _genreService.AddGenreAsync(addGenreDTO);

            return new JsonResult(addedGenre);
        }

        [HttpGet]
        public async Task<IActionResult> GetListAsync()
        {
            var allGenres = await _genreService.GetListOfGenresAsync();

            return new JsonResult(allGenres);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
        {
            var genreByKey = await _genreService.GetGenreAsync(id);

            return new JsonResult(genreByKey);
        }

        [HttpPut]
        [Route("update")]
        [Authorize(Roles = ApiRoles.ManagerRole)]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateGenreDTO updateGenreDTO)
        {
            var updatedGenre = await _genreService.UpdateGenreAsync(updateGenreDTO);

            return new JsonResult(updatedGenre);
        }

        [HttpDelete]
        [Route("remove/{id}")]
        [Authorize(Roles = ApiRoles.ManagerRole)]
        public async Task<IActionResult> RemoveAsync([FromRoute] int id)
        {
            await _genreService.RemoveGenreAsync(id);

            return Ok();
        }
    }
}
