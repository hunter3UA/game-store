using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using AutoMapper;
using FluentAssertions;
using GameStore.API.Controllers;
using GameStore.BLL.DTO;
using GameStore.BLL.DTO.Platform;
using GameStore.BLL.DTO.PlatformType;
using GameStore.BLL.Services.Abstract;
using GameStore.DAL.Entities;
using GameStore.Tests.Attributes;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace GameStore.Tests.Controllers
{
    public class PlatformTypesControllerTests
    {
        [Theory, AutoDomainData]
        public async Task AddPlatformTypeAsync_GivenPlatformIsValid_ReturnJsonResult(
            AddPlatformTypeDTO addPlatformDTO, 
            IMapper mapper,
            [Frozen] Mock<IPlatformTypeService> mockPlatformService, 
            [NoAutoProperties] PlatformTypesController platformController)
        {
            PlatformType platformToAdd = mapper.Map<PlatformType>(addPlatformDTO);
            var id = 10;
            platformToAdd.Id = id;
            mockPlatformService.Setup(m => m.AddPlatformAsync(It.IsAny<AddPlatformTypeDTO>()))
                .ReturnsAsync(() =>
                {
                    platformToAdd.Id = id;
                    return mapper.Map<PlatformTypeDTO>(platformToAdd);
                });

            var result = await platformController.AddPlatformTypeAsync(addPlatformDTO);

            result.Should().BeOfType<JsonResult>();
        }

        [Theory, AutoDomainData]
        public async Task AddPlatformTypeAsync_GivenPlatformIsInValid_ReturnBadRequestResult(
            [Frozen] Mock<IPlatformTypeService> mockPlatformService,
            [NoAutoProperties] PlatformTypesController platformController)
        {
      
            mockPlatformService.Setup(m => m.AddPlatformAsync(It.IsAny<AddPlatformTypeDTO>()))
                .ReturnsAsync(() =>
                {
                    return null;
                });

            var result = await platformController.AddPlatformTypeAsync(null);

            result.Should().BeOfType<BadRequestResult>();
        }

        [Theory, AutoDomainData]
        public async Task GetListOfPlatformsAsync_RequestedListExist_ReturnJsonResult(
            [Frozen] Mock<IPlatformTypeService> mockPlatformService, 
            [NoAutoProperties] PlatformTypesController platformController)
        {
            mockPlatformService.Setup(m => m.GetListOfPlatformsAsync()).ReturnsAsync(new List<PlatformTypeDTO>());

            var result = await platformController.GetListOfPlatformsAsync();

            result.Should().BeOfType<JsonResult>();
        }

        [Theory, AutoDomainData]
        public async Task GetListOfPlatformsAsync_RequestedListNotExist_ReturnNotFoundResult(
            [Frozen] Mock<IPlatformTypeService> mockPlatformService,
            [NoAutoProperties] PlatformTypesController platformController)
        {
            mockPlatformService.Setup(m => m.GetListOfPlatformsAsync()).ReturnsAsync(()=> {
                return null;
            });

            var result = await platformController.GetListOfPlatformsAsync();

            result.Should().BeOfType<NotFoundResult>();
        }

        [Theory, AutoDomainData]
        public async Task GetPlatformTypeAsync_RequestedPlatformExist_ReturnJsonResult(
            PlatformType platformType, 
            IMapper mapper,
            [Frozen] Mock<IPlatformTypeService> mockPlatformService, 
            [NoAutoProperties] PlatformTypesController platformsController)
        {
            mockPlatformService.Setup(m => m.GetPlatformAsync(It.IsAny<int>()))
                .ReturnsAsync(() =>
                {
                    return mapper.Map<PlatformTypeDTO>(platformType);
                });
            var result = await platformsController.GetPlatformAsync(platformType.Id);

            result.Should().BeOfType<JsonResult>();
        }

        [Theory, AutoDomainData]
        public async Task RemovePlatformTypeAsync_RequestedPlatformRemoved_ReturnOkResult(
            int id,
            [Frozen] Mock<IPlatformTypeService> mockPlatformService, 
            [NoAutoProperties] PlatformTypesController platformsController)
        {
            mockPlatformService.Setup(m => m.RemovePlatformAsync(It.IsAny<int>())).ReturnsAsync(true);

            var result = await platformsController.RemovePlatformAsync(id);

            result.Should().BeOfType<OkResult>();
        }

        [Theory,AutoDomainData]
        public async Task UpdatePlatformTypeAsync_RequestedPlatformUpdate_ReturnJsonResult(UpdatePlatformTypeDTO updatePlatformTypeDTO,[Frozen]Mock<IPlatformTypeService> mockPlatformService,
          [NoAutoProperties] PlatformTypesController platformTypesController
            )
        {
            mockPlatformService.Setup(m => m.UpdatePlatformAsync(It.IsAny<UpdatePlatformTypeDTO>())).ReturnsAsync(new PlatformTypeDTO());

            var result = await platformTypesController.UpdatePlatformAsync(updatePlatformTypeDTO);

            result.Should().BeOfType<JsonResult>();
        }

        [Theory, AutoDomainData]
        public async Task UpdatePlatformTypeAsync_PlatformNotUpdated_ReturnBadRequest(UpdatePlatformTypeDTO updatePlatformTypeDTO, [Frozen] Mock<IPlatformTypeService> mockPlatformService,
          [NoAutoProperties] PlatformTypesController platformTypesController
            )
        {
            mockPlatformService.Setup(m => m.UpdatePlatformAsync(It.IsAny<UpdatePlatformTypeDTO>())).ReturnsAsync(()=> {
                return null;
            });

            var result = await platformTypesController.UpdatePlatformAsync(updatePlatformTypeDTO);

            result.Should().BeOfType<BadRequestResult>();
        }
    }
}
