using System.Threading.Tasks;
using GameStore.BLL.DTO.Publisher;
using GameStore.BLL.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.API.Controllers
{
    [Route("api/publishers")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly IPublisherService _publisherService;

        public PublishersController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> AddPublisherAsync([FromBody] AddPublisherDTO addPublisherDTO)
        {
            var addedPublisher = await _publisherService.AddPublisherAsync(addPublisherDTO);

            return new JsonResult(addedPublisher);
        } 

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetPublisherAsync([FromRoute] int id)
        {
            var searchedPublisher = await _publisherService.GetPublisherAsync(id);

            return new JsonResult(searchedPublisher);
        }

        [HttpGet]
        public async Task<IActionResult> GetListOfPublishersAsync()
        {
            var allPublishers = await _publisherService.GetListOfPublishersAsync();

            return new JsonResult(allPublishers);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdatePublisherAsync([FromBody] UpdatePublisherDTO updatePublisherDTO)
        {
            var updatedPublisher = await _publisherService.UpdatePublisherAsync(updatePublisherDTO);

            return new JsonResult(updatedPublisher);
        }

        [HttpDelete]
        [Route("remove/{id}")]
        public async Task<IActionResult> RemovePublisherAsync([FromRoute] int id)
        {
            await _publisherService.RemovePublisherAsync(id);

            return Ok();
        }
    }
}
