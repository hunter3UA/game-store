using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using GameStore.API.Controllers;
using GameStore.BLL.DTO.OrderDetails;
using GameStore.BLL.Services.Abstract;
using GameStore.Tests.Attributes;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace GameStore.Tests.Controllers
{
    public class BasketsControllerTests
    {
        [Theory, AutoDomainData]
        public async Task AddOrderDetailsAsync_AddValidOrderDetails_ReturnJsonResult(
            [Frozen] Mock<IBasketService> mockOrderService,
            [NoAutoProperties] BasketsController ordersController)
        {
            mockOrderService.Setup(m => m.AddOrderDetailsAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(new BLL.DTO.OrderDetails.OrderDetailsDTO());

            var result = await ordersController.AddOrderDetailsAsync("Test");

            result.Should().BeOfType<JsonResult>();
        }

        [Theory, AutoDomainData]
        public async Task GetBasketAsync_RequestExistingOrder_ReturnJsonResult([Frozen] Mock<IBasketService> mockOrderService, [NoAutoProperties] BasketsController ordersController)
        {
            mockOrderService.Setup(m => m.GetBasketAsync("1")).ReturnsAsync(new BLL.DTO.Order.OrderDTO());

            var result = await ordersController.GetAsync();

            result.Should().BeOfType<JsonResult>();
        }

        [Theory, AutoDomainData]
        public async Task ChangeQauntitOfOrderDetailsyAsync_GivenValidData_ReturnJsonResult([Frozen] Mock<IBasketService> mockOrderService, ChangeQuantityDTO changeQuantityDTO, [NoAutoProperties] BasketsController ordersController)
        {
            mockOrderService.Setup(m => m.ChangeQuantityOfDetailsAsync(It.IsAny<ChangeQuantityDTO>())).ReturnsAsync(new OrderDetailsDTO());

            var result = await ordersController.ChangeQuantityOfOrderDetailsAsync(changeQuantityDTO);

            result.Should().BeOfType<JsonResult>();
        }

        [Theory, AutoDomainData]
        public async Task RemoveOrderDetailsAsync_RemoveExistingOrderDetails_ReturnOkResult([Frozen] Mock<IBasketService> mockOrderService, [NoAutoProperties] BasketsController ordersController)
        {
            mockOrderService.Setup(m => m.RemoveOrderDetailsAsync(It.IsAny<int>())).ReturnsAsync(() => { return true; });

            var result = await ordersController.RemoveOrderDetailsAsync(1);

            result.Should().BeOfType<OkResult>();
        }
    }
}
