using System.Threading.Tasks;
using GameStore.API.Auth;
using GameStore.API.Permissions.Publisher;
using GameStore.BLL.DTO.Publisher;
using GameStore.BLL.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.API.Controllers
{
    [Route("api/publishers")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly IPublisherService _publisherService;
        private readonly IPublisherPermission _publisherPermission;

        public PublishersController(IPublisherService publisherService,
            IPublisherPermission publisherPermission
            )
        {
            _publisherService = publisherService;
            _publisherPermission = publisherPermission;
        }

        [HttpPost]
        [Route("new")]
        [Authorize(Roles = ApiRoles.ManagerRole)]
        public async Task<IActionResult> AddAsync([FromBody] AddPublisherDTO addPublisherDTO)
        {
            var addedPublisher = await _publisherService.AddPublisherAsync(addPublisherDTO);

            return new JsonResult(addedPublisher);
        }

        [HttpGet]
        [Route("{name}")]
        public async Task<IActionResult> GetAsync([FromRoute] string name)
        {
            var searchedPublisher = await _publisherService.GetPublisherAsync(name);

            return new JsonResult(searchedPublisher);
        }

        [HttpGet]
        public async Task<IActionResult> GetListAsync()
        {
            var allPublishers = await _publisherService.GetListOfPublishersAsync();

            return new JsonResult(allPublishers);
        }

        [HttpPut]
        [Route("update")]
        [Authorize(Roles = ApiRoles.PublisherRole)]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdatePublisherDTO updatePublisherDTO)
        {
            bool canEdit = _publisherPermission.CanEditPublisher(HttpContext, updatePublisherDTO.OldCompanyName);
            if (!canEdit)
                return StatusCode(StatusCodes.Status403Forbidden);

            var updatedPublisher = await _publisherService.UpdatePublisherAsync(updatePublisherDTO);

            return new JsonResult(updatedPublisher);
        }

        [HttpDelete]
        [Route("remove/{id}")]
        [Authorize(Roles = ApiRoles.ManagerRole)]
        public async Task<IActionResult> RemoveAsync([FromRoute] int id)
        {
            await _publisherService.RemovePublisherAsync(id);

            return Ok();
        }
    }
}
