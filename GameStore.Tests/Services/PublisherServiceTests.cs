using AutoFixture.Xunit2;
using AutoMapper;
using FluentAssertions;
using GameStore.BLL.DTO.Publisher;
using GameStore.BLL.Services.Implementation;
using GameStore.DAL.Entities;
using GameStore.DAL.UoW.Abstract;
using GameStore.Tests.Attributes;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GameStore.Tests.Services
{
    public class PublisherServiceTests
    {
        [Theory, AutoDomainData]
        public async Task AddPublisherAsync_GivenValidPublisherToBeAdded_ReturnPublisher(
          AddPublisherDTO addpublisherDTO,
          [Frozen] Mock<IUnitOfWork> mockUnitOfWork,
          IMapper mapper,
          PublisherService publisherService)
        {
            Publisher publisherToAdd = mapper.Map<Publisher>(addpublisherDTO);
            mockUnitOfWork.Setup(m => m.PublisherRepository.AddAsync(It.IsAny<Publisher>()))
                .ReturnsAsync(() =>
                {
                    publisherToAdd.Id = 1;
                    return publisherToAdd;
                });

            var result = await publisherService.AddPublisherAsync(addpublisherDTO);

            result.Should().BeOfType<PublisherDTO>();
            result.Id.Should().Be(1);
        }

        [Theory, AutoDomainData]
        public async Task GetListOfPublishersAsync_ListExist_ReturnListOfPublishers(
            [Frozen] Mock<IUnitOfWork> mockUnitOfWork, PublisherService publisherService
            )
        {
            mockUnitOfWork.Setup(m => m.PublisherRepository.GetListAsync());

            var result = await publisherService.GetListOfPublishersAsync();

            result.Should().NotBeNull();
        }

        [Theory, AutoDomainData]
        public async Task GetPublisherAsync_GivenValidPublisherId_ReturnPublisher(Publisher publisher, [Frozen] Mock<IUnitOfWork> mockUnitOfWOrk, PublisherService publisherService)
        {
            mockUnitOfWOrk.Setup(m => m.PublisherRepository.GetAsync(It.IsAny<Expression<Func<Publisher, bool>>>())).ReturnsAsync(publisher);

            var result = await publisherService.GetPublisherAsync(1);

            result.Id.Should().Be(publisher.Id);
            result.Should().BeOfType<PublisherDTO>();
        }

        [Theory, AutoDomainData]
        public async Task GetPublisherAsync_GivenInValidPublisherId_ReturnPublisher([Frozen] Mock<IUnitOfWork> mockUnitOfWOrk, PublisherService publisherService)
        {
            mockUnitOfWOrk.Setup(m => m.PublisherRepository.GetAsync(It.IsAny<Expression<Func<Publisher, bool>>>())).ReturnsAsync(() =>
            {
                return null;
            });

            var result = await publisherService.GetPublisherAsync(1);

            result.Should().BeNull();
        }

        [Theory, AutoDomainData]
        public async Task RemovePublisherAsync_GivenValidPublisherId_ReturnTrue([Frozen] Mock<IUnitOfWork> mockUnitOfWOrk, PublisherService publisherService)
        {
            mockUnitOfWOrk.Setup(m => m.PublisherRepository.RemoveAsync(It.IsAny<Expression<Func<Publisher, bool>>>())).ReturnsAsync(() =>
            {
                return true;
            });

            var result = await publisherService.RemovePublisherAsync(1);

            result.Should().BeTrue();
        }

        [Theory, AutoDomainData]
        public async Task RemovePublisherAsync_GivenInValidPublisherId_ReturnFalse([Frozen] Mock<IUnitOfWork> mockUnitOfWOrk, PublisherService publisherService)
        {
            mockUnitOfWOrk.Setup(m => m.PublisherRepository.RemoveAsync(It.IsAny<Expression<Func<Publisher, bool>>>())).ReturnsAsync(() =>
            {
                return false;
            });

            var result = await publisherService.RemovePublisherAsync(1);

            result.Should().BeFalse();
        }

        [Theory, AutoDomainData]
        public async Task UpdatePublisherAsync_GivenInValidPublisherId_ReturnPublisher(UpdatePublisherDTO updatePublisherDTO,[Frozen] Mock<IUnitOfWork> mockUnitOfWOrk, PublisherService publisherService)
        {
            mockUnitOfWOrk.Setup(m => m.PublisherRepository.UpdateAsync(It.IsAny<Publisher>(),
                It.IsAny<Expression<Func<Publisher, object>>[]>()));

            var result = await publisherService.UpdatePublisherAsync(updatePublisherDTO);

            result.Should().NotBeNull().And.BeOfType<PublisherDTO>();
        }

    }
}
