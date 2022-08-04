﻿using System.Threading.Tasks;
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
        public async Task<IActionResult> UpdateAsync([FromBody] UpdatePublisherDTO updatePublisherDTO)
        {
            var updatedPublisher = await _publisherService.UpdatePublisherAsync(updatePublisherDTO);

            return new JsonResult(updatedPublisher);
        }

        [HttpDelete]
        [Route("remove/{id}")]
        public async Task<IActionResult> RemoveAsync([FromRoute] int id)
        {
            await _publisherService.RemovePublisherAsync(id);

            return Ok();
        }
    }
}
