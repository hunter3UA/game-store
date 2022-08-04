using System.Threading.Tasks;
using GameStore.BLL.DTO.Platform;
using GameStore.BLL.DTO.PlatformType;
using GameStore.BLL.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.API.Controllers
{
    [Route("api/platform-types")]
    [ApiController]
    public class PlatformTypesController : ControllerBase
    {
        private readonly IPlatformTypeService _platformService;

        public PlatformTypesController(IPlatformTypeService platformService)
        {
            _platformService = platformService;
        }

        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> AddAsync([FromBody] AddPlatformTypeDTO platformDTO)
        {
            var addedPlatform = await _platformService.AddPlatformAsync(platformDTO);

            return new JsonResult(addedPlatform);
        }

        [HttpGet]
        public async Task<IActionResult> GetListAsync()
        {
            var listOfPlatforms = await _platformService.GetListOfPlatformsAsync();

            return new JsonResult(listOfPlatforms);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
        {
            var searchedPlatform = await _platformService.GetPlatformAsync(id);

            return new JsonResult(searchedPlatform);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdatePlatformTypeDTO updatePlatformTypeDTO)
        {
            var updatedPlatform = await _platformService.UpdatePlatformAsync(updatePlatformTypeDTO);
            
            return new JsonResult(updatedPlatform);
        }

        [HttpDelete]
        [Route("remove/{id}")]
        public async Task<IActionResult> RemoveAsync([FromRoute] int id)
        {
            await _platformService.RemovePlatformAsync(id);

            return Ok();
        }
    }
}