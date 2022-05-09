using GameStore.BLL.DTO.Publisher;
using GameStore.BLL.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly IPublisherService _publisherService;

        public PublishersController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpPost]
        [Route("/publishers/new")]
        public async Task<IActionResult> AddPublisherAsync([FromBody] AddPublisherDTO addPublisherDTO)
        {
            var addedPublisher = await _publisherService.AddPublisherAsync(addPublisherDTO);

            if (addedPublisher == null)
            {
                return BadRequest();
            }

            return new JsonResult(addedPublisher);
        } 

        [HttpGet]
        [Route("/publishers/{id}")]
        public async Task<IActionResult> GetPublisherAsync([FromRoute] int id)
        {
            var searchedPublisher = await _publisherService.GetPublisherAsync(id);

            if (searchedPublisher == null)
            {
                return NotFound();
            }

            return new JsonResult(searchedPublisher);
        }

        [HttpGet]
        [Route("/publishers")]
        public async Task<IActionResult> GetListOfPublishersAsync()
        {
            var allPublishers = await _publisherService.GetListOfPublishersAsync();

            if (allPublishers == null)
            {
                return NotFound();
            }

            return Ok(allPublishers);
        }

        [HttpDelete]
        [Route("/publishers/remove/{id}")]
        public async Task<IActionResult> RemovePublisherAsync([FromRoute] int id)
        {
            bool isDeletedPublisher = await _publisherService.RemovePublisherAsync(id);

            if (!isDeletedPublisher)
            {
                return NotFound();
            }

            return new JsonResult($"{isDeletedPublisher}. Publisher with id {id} has been deleted");

        }


        [HttpPut]
        [Route("/publishers/update")]
        public async Task<IActionResult> UpdatePublisherAsync([FromBody] UpdatePublisherDTO updatePublisherDTO)
        {
            var updatedPublisher = await _publisherService.UpdatePublisherAsync(updatePublisherDTO);

            if (updatedPublisher == null)
            {
                return BadRequest();
            }

            return Ok(updatedPublisher);
        }
    }
}
