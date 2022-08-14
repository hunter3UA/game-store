using AutoFixture.Xunit2;
using FluentAssertions;
using GameStore.API.Controllers;
using GameStore.BLL.DTO.Publisher;
using GameStore.BLL.Services.Abstract;
using GameStore.Tests.Attributes;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace GameStore.Tests.Controllers
{
    public class PublishersControllerTests
    {
        [Theory,AutoDomainData]
        public async Task AddPublisherAsync_GivenPublisherIsValid_ReturnJsonResult(AddPublisherDTO addPublisherDTO,[Frozen]Mock<IPublisherService> mockPublisherService, 
            [NoAutoProperties]PublishersController publishersController
            )
        {
            mockPublisherService.Setup(m => m.AddPublisherAsync(It.IsAny<AddPublisherDTO>())).ReturnsAsync(new PublisherDTO());

            var result = await publishersController.AddAsync(addPublisherDTO);

            result.Should().BeOfType<JsonResult>();
        }


        [Theory, AutoDomainData]
        public async Task GetListOfPublishersAsync_RequestedPublisherIsExist_ReturnJsonResult(List<PublisherDTO> publishers,[Frozen]Mock<IPublisherService> mockPublisherService,
            [NoAutoProperties]PublishersController publishersController)         
        {
            mockPublisherService.Setup(m => m.GetListOfPublishersAsync()).ReturnsAsync(publishers);

            var result = await publishersController.GetListAsync();

            result.Should().BeOfType<JsonResult>();
        }

        [Theory,AutoDomainData]
        public async Task GetPublisherAsync_RequestedPublisherIsExist_ReturnJsonResult([Frozen] Mock<IPublisherService> mockPublisherService,
            [NoAutoProperties] PublishersController publishersController)
        {
            mockPublisherService.Setup(m => m.GetPublisherAsync(It.IsAny<string>())).ReturnsAsync(new PublisherDTO());

            var result = await publishersController.GetAsync("MyPub");

            result.Should().BeOfType<JsonResult>();
        }

        [Theory,AutoDomainData]
        public async Task RemovePublisherAsync_GivenValidPublisherId_ReturnOkResult([Frozen] Mock<IPublisherService> mockPublisherService,
            [NoAutoProperties] PublishersController publishersController)
        {
            mockPublisherService.Setup(m => m.RemovePublisherAsync(It.IsAny<int>())).ReturnsAsync(()=> {
                return true;
            });

            var result = await publishersController.RemoveAsync(1);

            result.Should().BeOfType<OkResult>();
        }

        [Theory,AutoDomainData]
        public async Task UpdatePublisherAsync_GivenValidPublisher_ReturnJsonResult(UpdatePublisherDTO updatePublisherDTO,[Frozen] Mock<IPublisherService> mockPublisherService,
            [NoAutoProperties] PublishersController publishersController)
        {
            mockPublisherService.Setup(m => m.UpdatePublisherAsync(It.IsAny<UpdatePublisherDTO>())).ReturnsAsync(new PublisherDTO());

            var result = await publishersController.UpdateAsync(updatePublisherDTO);

            result.Should().BeOfType<JsonResult>();

        }
    }
}
