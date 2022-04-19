using GameStore.API.Static;
using GameStore.BLL.DTO;
using GameStore.BLL.Services.Abstract;
using GameStore.DAL.Repositories.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<ActionResult<PlatformTypeDTO>> AddPlatformTypeAsync([FromBody] AddPlatformTypeDTO platformDTO)
        {
            var addedPlatform = await _platformService.AddPlatformTypeAsync(platformDTO);
            if (addedPlatform == null)
                return BadRequest();

            return Ok(addedPlatform);
        }

        [HttpGet]
        [Route("/platformTypes/all")]
        [ResponseCache(CacheProfileName = Constants.CACHING_PROFILE_NAME)]
        public async Task<ActionResult<List<PlatformTypeDTO>>> GetListOfPlatformsAsync()
        {
            var listOfPlatforms = await _platformService.GetListOfPlatformsAsync();

            return Ok(listOfPlatforms);
        }

        [HttpGet]
        [Route("/platformTypes/{key}")]
        [ResponseCache(CacheProfileName = Constants.CACHING_PROFILE_NAME)]
        public async Task<ActionResult<PlatformTypeDTO>> GetPlatformAsync([FromRoute] int key)
        {
            var platformToSearch = await _platformService.GetPlatformAsync(p => p.Id == key);
            if (platformToSearch == null)
                return NotFound();

            return Ok(platformToSearch);
        }

        [HttpPut]
        [Route("/platformTypes/remove/{key}")]
        public async Task<ActionResult<bool>> RemovePlatformAsync([FromRoute] int key)
        {
            bool isRemovedPlatform = await _platformService.RemovePlatformAsync(key);
            if (!isRemovedPlatform)
                return NotFound(false);

            return Ok($"{isRemovedPlatform}. Platform with Id {key} has been deleted ");
        }
    }
}

