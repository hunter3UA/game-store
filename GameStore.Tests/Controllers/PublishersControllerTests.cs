using AutoFixture.Xunit2;
using FluentAssertions;
using GameStore.API.Controllers;
using GameStore.BLL.DTO.Publisher;
using GameStore.BLL.Services.Abstract;
using GameStore.Tests.Attributes;
using Microsoft.AspNetCore.Mvc;
using Moq;
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

            var result = await publishersController.AddPublisherAsync(addPublisherDTO);

            result.Should().BeOfType<JsonResult>();
        }

        [Theory, AutoDomainData]
        public async Task AddPublisherAsync_GivenPublisherIsInValid_ReturnBadRequesttResult([Frozen] Mock<IPublisherService> mockPublisherService,
            [NoAutoProperties] PublishersController publishersController
            )
        {
            mockPublisherService.Setup(m => m.AddPublisherAsync(It.IsAny<AddPublisherDTO>())).ReturnsAsync(()=> {
                return null;
            });

            var result = await publishersController.AddPublisherAsync(null);

            result.Should().BeOfType<BadRequestResult>();
        }

        [Theory, AutoDomainData]
        public async Task GetListOfPublishersAsync_RequestedPublisherIsExist_ReturnJsonResult(List<PublisherDTO> publishers,[Frozen]Mock<IPublisherService> mockPublisherService,
            [NoAutoProperties]PublishersController publishersController)         
        {
            mockPublisherService.Setup(m => m.GetListOfPublishersAsync()).ReturnsAsync(publishers);

            var result = await publishersController.GetListOfPublishersAsync();

            result.Should().BeOfType<JsonResult>();
        }

        [Theory, AutoDomainData]
        public async Task GetListOfPublishersAsync_RequestedPublisherIsNotExist_ReturnNotFoundResult([Frozen] Mock<IPublisherService> mockPublisherService,
            [NoAutoProperties] PublishersController publishersController
            )
        {
            mockPublisherService.Setup(m => m.GetListOfPublishersAsync()).ReturnsAsync(()=> {
                return null;
            });
            
            var result = await publishersController.GetListOfPublishersAsync();

            result.Should().BeOfType<NotFoundResult>();
        }

        [Theory,AutoDomainData]
        public async Task GetPublisherAsync_RequestedPublisherIsExist_ReturnJsonResult([Frozen] Mock<IPublisherService> mockPublisherService,
            [NoAutoProperties] PublishersController publishersController)
        {
            mockPublisherService.Setup(m => m.GetPublisherAsync(It.IsAny<int>())).ReturnsAsync(new PublisherDTO());

            var result = await publishersController.GetPublisherAsync(1);

            result.Should().BeOfType<JsonResult>();
        }

        [Theory, AutoDomainData]
        public async Task GetPublisherAsync_RequestedPublisherIsNotExist_ReturnNotFoundResult([Frozen] Mock<IPublisherService> mockPublisherService,
            [NoAutoProperties] PublishersController publishersController)
        {
            mockPublisherService.Setup(m => m.GetPublisherAsync(It.IsAny<int>())).ReturnsAsync(()=> {
                return null;
            });

            var result = await publishersController.GetPublisherAsync(1);

            result.Should().BeOfType<NotFoundResult>();
        }

        [Theory,AutoDomainData]
        public async Task RemovePublisherAsync_GivenValidPublisherId_ReturnOkResult([Frozen] Mock<IPublisherService> mockPublisherService,
            [NoAutoProperties] PublishersController publishersController)
        {
            mockPublisherService.Setup(m => m.RemovePublisherAsync(It.IsAny<int>())).ReturnsAsync(()=> {
                return true;
            });

            var result = await publishersController.RemovePublisherAsync(1);

            result.Should().BeOfType<OkResult>();
        }

        [Theory, AutoDomainData]
        public async Task RemovePublisherAsync_GivenInValidPublisherId_ReturnNotFoundResult([Frozen] Mock<IPublisherService> mockPublisherService,
            [NoAutoProperties] PublishersController publishersController)
        {
            mockPublisherService.Setup(m => m.RemovePublisherAsync(It.IsAny<int>())).ReturnsAsync(() => {
                return false;
            });

            var result = await publishersController.RemovePublisherAsync(1);

            result.Should().BeOfType<NotFoundResult>();
        }

        [Theory,AutoDomainData]
        public async Task UpdatePublisherAsync_GivenValidPublisher_ReturnJsonResult(UpdatePublisherDTO updatePublisherDTO,[Frozen] Mock<IPublisherService> mockPublisherService,
            [NoAutoProperties] PublishersController publishersController)
        {
            mockPublisherService.Setup(m => m.UpdatePublisherAsync(It.IsAny<UpdatePublisherDTO>())).ReturnsAsync(new PublisherDTO());

            var result = await publishersController.UpdatePublisherAsync(updatePublisherDTO);

            result.Should().BeOfType<JsonResult>();

        }

        [Theory, AutoDomainData]
        public async Task UpdatePublisherAsync_GivenInValidPublisher_ReturnBadRequestResult(UpdatePublisherDTO updatePublisherDTO, [Frozen] Mock<IPublisherService> mockPublisherService,
            [NoAutoProperties] PublishersController publishersController)
        {
            mockPublisherService.Setup(m => m.UpdatePublisherAsync(It.IsAny<UpdatePublisherDTO>())).ReturnsAsync(()=> {
                return null;
            });

            var result = await publishersController.UpdatePublisherAsync(updatePublisherDTO);

            result.Should().BeOfType<BadRequestResult>();

        }
    }
}
