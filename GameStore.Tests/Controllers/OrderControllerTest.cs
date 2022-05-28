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
    public class OrderControllerTest
    {
        [Theory, AutoDomainData]
        public async Task AddOrderDetailsAsync_AddValidOrderDetails_ReturnOrderDetails(
            [Frozen] Mock<IBasketService> mockOrderService,
            [NoAutoProperties] BasketController ordersController)
        {
            mockOrderService.Setup(m => m.AddOrderDetailsAsync(It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new BLL.DTO.OrderDetails.OrderDetailsDTO());

            var result = await ordersController.AddOrderDetailsAsync("Test");

            result.Should().BeOfType<JsonResult>();
        }

        [Theory, AutoDomainData]
        public async Task AddOrderDetailsAsync_AddInValidOrderDetails_ReturnOrderDetails(
            [Frozen] Mock<IBasketService> mockOrderService,
            [NoAutoProperties] BasketController ordersController)
        {
            mockOrderService.Setup(m => m.AddOrderDetailsAsync(It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(() => { return null; });

            var result = await ordersController.AddOrderDetailsAsync("Test");

            result.Should().BeOfType<BadRequestResult>();
        }

        [Theory, AutoDomainData]
        public async Task GetOrderAsync_RequestExistingOrder_ReturnJsonResult([Frozen] Mock<IBasketService> mockOrderService, [NoAutoProperties] BasketController ordersController)
        {
            mockOrderService.Setup(m => m.GetBasketAsync(1)).ReturnsAsync(new BLL.DTO.Order.OrderDTO());

            var result = await ordersController.GetOrderAsync();

            result.Should().BeOfType<JsonResult>();
        }

        [Theory, AutoDomainData]
        public async Task GetOrderAsync_RequestNotExistingOrder_ReturnNotFoundResult([Frozen] Mock<IBasketService> mockOrderService, [NoAutoProperties] BasketController ordersController)
        {
            mockOrderService.Setup(m => m.GetBasketAsync(It.IsAny<int>())).ReturnsAsync(() => { return null; });

            var result = await ordersController.GetOrderAsync();

            result.Should().BeOfType<NotFoundResult>();
        }

        [Theory, AutoDomainData]
        public async Task ChangeQauntitOfOrderDetailsyAsync_GivenValidData_ReturnOkResult([Frozen] Mock<IBasketService> mockOrderService, ChangeQuantityDTO changeQuantityDTO, [NoAutoProperties] BasketController ordersController)
        {
            mockOrderService.Setup(m => m.ChangeQuantityOfDetailsAsync(It.IsAny<ChangeQuantityDTO>())).ReturnsAsync(new OrderDetailsDTO());

            var result = await ordersController.ChangeQuantityOfOrderDetailsAsync(changeQuantityDTO);

            result.Should().BeOfType<OkObjectResult>();
        }

        [Theory, AutoDomainData]
        public async Task ChangeQauntitOfOrderDetailsyAsync_GivenInValidData_ReturnBadRequestResult([Frozen] Mock<IBasketService> mockOrderService, ChangeQuantityDTO changeQuantityDTO, [NoAutoProperties] BasketController ordersController)
        {
            mockOrderService.Setup(m => m.ChangeQuantityOfDetailsAsync(It.IsAny<ChangeQuantityDTO>())).ReturnsAsync(() => { return null; });

            var result = await ordersController.ChangeQuantityOfOrderDetailsAsync(changeQuantityDTO);

            result.Should().BeOfType<BadRequestResult>();
        }

        [Theory, AutoDomainData]
        public async Task RemoveOrderDetailsAsync_RemoveExistingOrderDetails_ReturnOkResult([Frozen] Mock<IBasketService> mockOrderService, [NoAutoProperties] BasketController ordersController)
        {
            mockOrderService.Setup(m => m.RemoveOrderDetailsAsync(It.IsAny<int>())).ReturnsAsync(() => { return true; });

            var result = await ordersController.RemoveOrderDetailsAsync(1);

            result.Should().BeOfType<OkResult>();
        }

        [Theory, AutoDomainData]
        public async Task RemoveOrderDetailsAsync_RemoveNotExistingOrderDetails_ReturnBadRequestResult([Frozen] Mock<IBasketService> mockOrderService, [NoAutoProperties] BasketController ordersController)
        {
            mockOrderService.Setup(m => m.RemoveOrderDetailsAsync(It.IsAny<int>())).ReturnsAsync(() => { return false; });

            var result = await ordersController.RemoveOrderDetailsAsync(1);

            result.Should().BeOfType<BadRequestResult>();
        }
    }
}
