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
using Microsoft.EntityFrameworkCore;
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
        public async Task AddPlatformAsync_GivenInvalidPlatform_ThrowDbUpdateException([Frozen] Mock<IUnitOfWork> mockUnitOfWork, PlatformTypeService platformTypeService)
        {
   
            mockUnitOfWork.Setup(m => m.PlatformTypeRepository.AddAsync(It.IsAny<PlatformType>())).ThrowsAsync(new DbUpdateException());

            Exception result = await Record.ExceptionAsync(() => platformTypeService.AddPlatformAsync(new AddPlatformTypeDTO()));

            result.Should().BeOfType<DbUpdateException>();
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
        public async Task GetPlatformAsync_GivenValidId_ReturnPlatform(
             PlatformType platform, [Frozen] Mock<IUnitOfWork> mockUnitOfWork, PlatformTypeService platformService)
        {
            mockUnitOfWork.Setup(m => m.PlatformTypeRepository.GetAsync(
                It.IsAny<Expression<Func<PlatformType, bool>>>())).ReturnsAsync(platform);

            var result = await platformService.GetPlatformAsync(platform.Id);

            result.Id.Should().Be(platform.Id);
        }

        [Theory, AutoDomainData]
        public async Task GetPlatformAsync_GivenInvalidPlatformId_ReturnKeyNotFoundException([Frozen] Mock<IUnitOfWork> mockUnitOfWork, PlatformTypeService platformService)
        {
            mockUnitOfWork.Setup(m => m.PlatformTypeRepository.GetAsync(
                  It.IsAny<Expression<Func<PlatformType, bool>>>())).ReturnsAsync(() =>
                  {
                      return null;
                  });

            Exception result = await Record.ExceptionAsync(() => platformService.GetPlatformAsync(1));

            result.Should().BeOfType<KeyNotFoundException>();
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
        public async Task UpdatePlatformAsync_GivenInvalidPlatformToUpdate_ReturnArgumentException(
            [Frozen] Mock<IUnitOfWork> mockUnitOfWork, PlatformTypeService platformTypeService)        
        {
            mockUnitOfWork.Setup(m => m.PlatformTypeRepository.UpdateAsync(It.IsAny<PlatformType>())).ReturnsAsync(()=> { return null; });

            Exception result = await Record.ExceptionAsync(() => platformTypeService.UpdatePlatformAsync(new UpdatePlatformTypeDTO()));

            result.Should().BeOfType<ArgumentException>();
        }

        [Theory, AutoDomainData]
        public async Task RemovePlatformAsync_RemoveExistingPlatform_ReturnTrue(
            [Frozen] Mock<IUnitOfWork> mockUnitOfWork, PlatformTypeService platformService)
        {
            mockUnitOfWork.Setup(m => m.PlatformTypeRepository.RemoveAsync(It.IsAny<Expression<Func<PlatformType, bool>>>())).ReturnsAsync(() =>
            {
                return true;
            });

            var result = await platformService.RemovePlatformAsync(1);

            result.Should().BeTrue();
        }

        [Theory, AutoDomainData]
        public async Task RemovePlatformTypeAsync_PlatformNotRemoved_ThrowArgumentException(
         [Frozen] Mock<IUnitOfWork> mockUnitOfWork, PlatformTypeService platformService)
        {
            mockUnitOfWork.Setup(m => m.PlatformTypeRepository.RemoveAsync(It.IsAny<Expression<Func<PlatformType, bool>>>())).ReturnsAsync(false);

            Exception result = await Record.ExceptionAsync(() => platformService.RemovePlatformAsync(1));

            result.Should().BeOfType<ArgumentException>();
        }
    }
}
