using GameStore.BLL.DTO;
using GameStore.BLL.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        [Route("/Genres/GetAll")]
        [ResponseCache(CacheProfileName = "Caching")]
        public async Task<List<GenreDTO>> GetAllGenresAsync()
        {
            var allGenres = await _genreService.GetListOfGenresAsync();
            return allGenres;
        }
    }
}
