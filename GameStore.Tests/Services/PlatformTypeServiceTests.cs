using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using AutoMapper;
using FluentAssertions;
using GameStore.BLL.DTO;
using GameStore.BLL.DTO.Platform;
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
        public async Task AddPlatformAsync_GivenInvalidPlatform_ReturnNull([Frozen] Mock<IUnitOfWork> mockUnitOfWork, PlatformTypeService platformTypeService)
        {
            AddPlatformTypeDTO platform = new AddPlatformTypeDTO();
            platform.Type = null;
            mockUnitOfWork.Setup(m => m.PlatformTypeRepository.AddAsync(It.IsAny<PlatformType>())).ThrowsAsync(new Exception());

            Exception result = await Record.ExceptionAsync(() => platformTypeService.AddPlatformAsync(platform));

            result.Should().BeOfType<Exception>();
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

        [Theory, AutoDomainData]
        public async Task GetPlatformAsync_GivenInvalidId_ReturnNull([Frozen] Mock<IUnitOfWork> mockUnitOfWork, PlatformTypeService platformService)
        {
            mockUnitOfWork.Setup(m => m.PlatformTypeRepository.GetAsync(
                  It.IsAny<Expression<Func<PlatformType, bool>>>())).ReturnsAsync(() =>
                  {
                      return null;
                  });

            var result = await platformService.GetPlatformAsync(1);

            result.Should().BeNull();
        }

        [Theory, AutoDomainData]
        public async Task UpdatePlatformAsync_GivenValidPlatformToBeUpdated_ReturnPlatform(
            UpdatePlatformTypeDTO updatePlatformTypeDTO, [Frozen] Mock<IUnitOfWork> mockUnitOfWork, PlatformTypeService platformService)
        {
            mockUnitOfWork.Setup(m => m.PlatformTypeRepository.UpdateAsync(
               It.IsAny<PlatformType>(),
               It.IsAny<Expression<Func<PlatformType, object>>[]>())).ReturnsAsync(() => { return new PlatformType { Type = updatePlatformTypeDTO.Type }; });

            var result = await platformService.UpdatePlatformAsync(updatePlatformTypeDTO);

            result.Should().BeOfType(typeof(PlatformTypeDTO));
            result.Type.Should().BeEquivalentTo(updatePlatformTypeDTO.Type);
        }

        [Theory, AutoDomainData]
        public async Task UpdatePlatformAsync_GivenInvalidPlatformToUpdate_ReturnNull(
            [Frozen] Mock<IUnitOfWork> mockUnitOfWork, PlatformTypeService platformTypeService)        
        {
            mockUnitOfWork.Setup(m => m.PlatformTypeRepository.UpdateAsync(It.IsAny<PlatformType>())).ThrowsAsync(new Exception());

            Exception result = await Record.ExceptionAsync(() => platformTypeService.UpdatePlatformAsync(null));

            result.Should().BeOfType<Exception>();
        }

        [Theory, AutoDomainData]
        public async Task RemovePlatformAsync_GivenNotExistingPlatformToRemove_ReturnNull(
            [Frozen] Mock<IUnitOfWork> mockUnitOfWork, PlatformTypeService platformService)
        {
            mockUnitOfWork.Setup(m => m.PlatformTypeRepository.RemoveAsync(It.IsAny<Expression<Func<PlatformType, bool>>>())).ReturnsAsync(() =>
            {
                return false;
            });

            var result = await platformService.RemovePlatformAsync(1);

            result.Should().BeFalse();
        }
    }
}
