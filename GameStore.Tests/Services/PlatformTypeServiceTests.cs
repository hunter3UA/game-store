using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using AutoMapper;
using FluentAssertions;
using GameStore.BLL.DTO;
using GameStore.BLL.DTO.PlatformType;
using GameStore.BLL.Services.Implementation;
using GameStore.DAL.Entities;
using GameStore.DAL.UoW.Abstract;
using GameStore.Tests.Attributes;
using Moq;
using Xunit;

namespace GameStore.Tests.Services
{
    public class PlatformTypeServiceTests
    {
        [Theory, AutoDomainData]
        public async Task AddPlatformAsync_GivenValidPlatformToBeAdded_ReturnPlatformType(
            AddPlatformTypeDTO addPlatformTypeDTO,
            [Frozen] Mock<IUnitOfWork> mockUnitOfWork,
            IMapper mapper,
            PlatformTypeService platformTypeService)
        {
            PlatformType platform = mapper.Map<PlatformType>(addPlatformTypeDTO);
            var id = 10;
            mockUnitOfWork.Setup(m => m.PlatformTypeRepository.AddAsync(It.IsAny<PlatformType>()))
                .ReturnsAsync(() =>
                {
                    platform.Id = id;
                    return platform;
                });

            var result = await platformTypeService.AddPlatformAsync(addPlatformTypeDTO);

            result.Should().BeOfType<PlatformTypeDTO>().Which.Id.Should().Be(id);
        }

        [Theory, AutoDomainData]
        public async Task GetListOfPlatformsAsync_RequestedListExist_ReturnListOfPlatfoms(
            [Frozen] Mock<IUnitOfWork> mockUnitOfWork, PlatformTypeService platformTypeService)
        {
            mockUnitOfWork.Setup(m => m.PlatformTypeRepository.GetListAsync()).ReturnsAsync(new List<PlatformType>());

            var listOfPlatforms = await platformTypeService.GetListOfPlatformsAsync();

            listOfPlatforms.Should().BeOfType<List<PlatformTypeDTO>>();
        }

        [Theory, AutoDomainData]
        public async Task RemovePlatformTypeAsync_PlatformIsNotRemoved_ShouldReturnFalse(
           [Frozen] Mock<IUnitOfWork> mockUnitOfWork, PlatformTypeService platformService)
        {
            mockUnitOfWork.Setup(m => m.PlatformTypeRepository.RemoveAsync(It.IsAny<Expression<Func<PlatformType, bool>>>())).ReturnsAsync(false);

            var result = await platformService.RemovePlatformAsync(4);

            result.Should().BeFalse();
        }

        [Theory, AutoDomainData]
        public async Task GetPlatformAsync_GivenValidId_ReturnPlatform(
             PlatformType platform, [Frozen] Mock<IUnitOfWork> mockUnitOfWork, PlatformTypeService platformService)
        {
            mockUnitOfWork.Setup(m => m.PlatformTypeRepository.GetAsync(
                It.IsAny<Expression<Func<PlatformType, bool>>>())).ReturnsAsync(platform);

            var result = await platformService.GetPlatformAsync(platform.Id);

            result.Id.Should().Be(platform.Id);
        }
    }
}
