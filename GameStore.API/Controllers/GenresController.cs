using GameStore.API.Static;
using GameStore.BLL.DTO;
using GameStore.BLL.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<ActionResult> AddGenreAsync([FromBody] AddGenreDTO addGenreDTO)
        {
            var addedGenre = await _genreService.AddGenreAsync(addGenreDTO);
            if (addedGenre == null)
                return BadRequest();

            return Ok(addedGenre);
        }

        [HttpGet]
        [Route("/genres/getAll")]
        [ResponseCache(CacheProfileName = Constants.CACHING_PROFILE_NAME)]
        public async Task<ActionResult<List<GenreDTO>>> GetAllGenresAsync()
        {
            var allGenres = await _genreService.GetListOfGenresAsync();
            if (allGenres == null)
                return NotFound();

            return Ok(allGenres);
        }


        [HttpGet]
        [Route("/genres/{key}")]
        [ResponseCache(CacheProfileName = Constants.CACHING_PROFILE_NAME)]
        public async Task<ActionResult<List<GenreDTO>>> GetGenreAsync([FromRoute] int key)
        {
            var genreByKey = await _genreService.GetGenreAsync(g => g.Id == key);
            if (genreByKey == null)
                return NotFound();

            return Ok(genreByKey);
        }

        [HttpPut]
        [Route("/genres/remove/{key}")]
        public async Task<ActionResult<bool>> RemoveGenreAsync([FromRoute] int key)
        {
            var isRemovedGenre = await _genreService.RemoveGenreAsync(key);
            if (!isRemovedGenre)
                return NotFound(isRemovedGenre);

            return Ok($"{isRemovedGenre}.Genre with Id {key} has been deleted");
        }

    }
}
