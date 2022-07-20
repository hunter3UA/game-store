using AutoFixture.Xunit2;
using FluentAssertions;
using GameStore.BLL.DTO.Shipper;
using GameStore.BLL.Services.Implementation;
using GameStore.DAL.Context.Abstract;
using GameStore.DAL.Entities;
using GameStore.Tests.Attributes;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace GameStore.Tests.Services
{
    public class ShipperServiceTests
    {
        [Theory, AutoDomainData]
        public async Task GetListOfShippersAsync_ShippersExist_RetrunListOfShippers([Frozen]Mock<INorthwindFactory> mockNorthwindDb, ShipperService shipperService,List<Shipper> shippers)
        {
            mockNorthwindDb.Setup(m => m.ShipperRepository.GetListAsync()).ReturnsAsync(()=> { return shippers; });

            var result = await shipperService.GetListOfShippersAsync();

            result.Should().BeOfType<List<ShipperDTO>>();
        }
    }
}
