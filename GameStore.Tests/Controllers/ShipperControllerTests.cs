using AutoFixture.Xunit2;
using FluentAssertions;
using GameStore.API.Controllers;
using GameStore.BLL.DTO.Shipper;
using GameStore.BLL.Services.Implementation;
using GameStore.Tests.Attributes;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace GameStore.Tests.Controllers
{
    public class ShipperControllerTests
    {
        [Theory,AutoDomainData]
        public async Task GetListOfShippersAsync_ShippersExist_RetrunJsonResult([NoAutoProperties]ShipperController shipperController
            )
        {
            var result = await shipperController.GetListAsync();

            result.Should().BeOfType<JsonResult>();
        }
    }
}
