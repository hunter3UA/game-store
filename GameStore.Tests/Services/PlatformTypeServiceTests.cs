using AutoFixture.Xunit2;
using AutoMapper;
using GameStore.BLL.DTO;
using GameStore.BLL.Services.Implementation;
using GameStore.DAL.Entities;
using GameStore.DAL.UoW.Abstract;
using GameStore.Tests.Attributes;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GameStore.Tests.Services
{
    public class PlatformTypeServiceTests
    {
        [Theory,AutoDomainData]
        public async Task AddPlatformAsync_IfPlatformAdded_ShouldReturnPlatformTypeDTO(AddPlatformTypeDTO addPlatformTypeDTO,
            [Frozen]Mock<IUnitOfWork> mockUnitOfWork,IMapper mapper, PlatformTypeService platformTypeService)
        {
            PlatformType platform = mapper.Map<PlatformType>(addPlatformTypeDTO);
            var id = 10;
            mockUnitOfWork.Setup(m=>m.PlatformTypeRepository.AddPlatformAsync()
            )
        }
    }
}
