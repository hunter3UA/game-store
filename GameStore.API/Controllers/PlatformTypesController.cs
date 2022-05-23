using System.Threading.Tasks;
using GameStore.API.Static;
using GameStore.BLL.DTO;
using GameStore.BLL.DTO.Platform;
using GameStore.BLL.DTO.PlatformType;
using GameStore.BLL.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformTypesController : ControllerBase
    {
        private readonly IPlatformTypeService _platformService;

        public PlatformTypesController(IPlatformTypeService platformService)
        {
            _platformService = platformService;
        }

        [HttpPost]
        [Route("/platformTypes/add")]
        public async Task<IActionResult> AddPlatformTypeAsync([FromBody] AddPlatformTypeDTO platformDTO)
        {
            var addedPlatform = await _platformService.AddPlatformAsync(platformDTO);

            if (addedPlatform == null)
            {
                return BadRequest();
            }

            return Ok(addedPlatform);
        }

        [HttpGet]
        [Route("/platformTypes")]
        public async Task<IActionResult> GetListOfPlatformsAsync()
        {
            var listOfPlatforms = await _platformService.GetListOfPlatformsAsync();

            return Ok(listOfPlatforms);
        }

        [HttpGet]
        [Route("/platformTypes/{id}")]
        public async Task<IActionResult> GetPlatformAsync([FromRoute] int id)
        {
            var searchedPlatform = await _platformService.GetPlatformAsync(id);

            if (searchedPlatform == null)
            {
                return NotFound();
            }

            return Ok(searchedPlatform);
        }

        [HttpPut]
        [Route("/platformTypes/update")]
        public async Task<IActionResult> UpdatePlatformAsync([FromBody] UpdatePlatformTypeDTO updatePlatformTypeDTO)
        {
            var updatedPlatform = await _platformService.UpdatePlatformAsync(updatePlatformTypeDTO);

            if (updatedPlatform == null)
            {
                return BadRequest();
            }
            
            return new JsonResult(updatedPlatform);
        }

        [HttpDelete]
        [Route("/platformTypes/remove/{id}")]
        public async Task<IActionResult> RemovePlatformAsync([FromRoute] int id)
        {
            bool isRemovedPlatform = await _platformService.RemovePlatformAsync(id);

            if (!isRemovedPlatform)
            {
                return NotFound(false);
            }

            return new JsonResult($"{isRemovedPlatform}. Platform with Id {id} has been deleted ");
        }
    }
}