using AutoFixture.Xunit2;
using FluentAssertions;
using GameStore.API.Controllers;
using GameStore.API.Helpers;
using GameStore.BLL.DTO.Order;
using GameStore.BLL.Services.Abstract;
using GameStore.Tests.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace GameStore.Tests.Controllers
{
    public class OrdersControllerTest
    {
        [Theory, AutoDomainData]
        public async Task MakeOrderAsync_GivenValidOrderId_ReturnJsonResult([Frozen] Mock<IOrderService> mockOrderService, [NoAutoProperties] OrdersController ordersController)
        {
            mockOrderService.Setup(m => m.MakeOrderAsync(It.IsAny<int>())).ReturnsAsync(() => { return new OrderDTO(); });

            var result = await ordersController.MakeOrderAsync(1);

            result.Should().BeOfType<JsonResult>();
        }

        [Theory, AutoDomainData]
        public async Task GetByCustomerAsync_GivenValidOrder_ReturnJsonResult([Frozen] Mock<IOrderService> mockOrderService, Mock<ICustomerHelper> mockCustomerGenerator, [NoAutoProperties] OrdersController ordersController)
        {
            mockCustomerGenerator.Setup(m => m.GetUserId(It.IsAny<HttpContext>())).Returns("1");
            mockOrderService.Setup(m => m.GetOrderAsync(It.IsAny<int>())).ReturnsAsync(new OrderDTO());

            var result = await ordersController.GetByCustomerAsync();

            result.Should().BeOfType<JsonResult>();
        }

        [Theory, AutoDomainData]
        public async Task GetByOrderIdAsync_GivenValidOrder_ReturnJsonResult([Frozen] Mock<IOrderService> mockOrderService, [NoAutoProperties] OrdersController ordersController)
        {

            mockOrderService.Setup(m => m.GetOrderAsync(It.IsAny<int>())).ReturnsAsync(new OrderDTO());

            var result = await ordersController.GetByOrderIdAsync(1);

            result.Should().BeOfType<JsonResult>();
        }

        [Theory, AutoDomainData]
        public async Task CancelOrderAsync_GivenValidOrder_ReturnOkResult([Frozen] Mock<IOrderService> mockOrderService, [NoAutoProperties] OrdersController ordersController)
        {
            mockOrderService.Setup(m => m.CancelOrderAsync(It.IsAny<int>())).ReturnsAsync(true);

            var result = await ordersController.CancelOrderAsync(1);

            result.Should().BeOfType<OkResult>();
        }

        [Theory, AutoDomainData]
        public async Task PayAsync_GivenValidVisaPaymentOrder_ReturnOkResult([Frozen] Mock<IPaymentContext> mockPaymentContext, [NoAutoProperties] OrdersController ordersController)
        {
            mockPaymentContext.Setup(m => m.ExecutePay(It.IsAny<int>())).ReturnsAsync(new object());

            var result = await ordersController.PayAsync(new OrderPaymentDTO() { OrderId = 1, PaymentType = BLL.Enum.PaymentType.VisaPayment });

            result.Should().BeOfType<OkResult>();
        }

        [Theory, AutoDomainData]
        public async Task PayAsync_GivenValidIBoxPaymentOrder_ReturnOkResult([Frozen] Mock<IPaymentContext> mockPaymentContext, [NoAutoProperties] OrdersController ordersController)
        {
            mockPaymentContext.Setup(m => m.ExecutePay(It.IsAny<int>())).ReturnsAsync(new object());

            var result = await ordersController.PayAsync(new OrderPaymentDTO() { OrderId = 1, PaymentType = BLL.Enum.PaymentType.IBoxPayment });

            result.Should().BeOfType<OkResult>();

        }

        [Theory, AutoDomainData]
        public async Task UpdateOrderAsync_GivenValidUpdateOrder_ReturnJsonResult(UpdateOrderDTO updateOrderDTO, [Frozen] Mock<IOrderService> mockOrderService, [NoAutoProperties] OrdersController ordersController)
        {
            mockOrderService.Setup(m => m.UpdateOrderAsync(It.IsAny<UpdateOrderDTO>())).ReturnsAsync(new OrderDTO());

            var result = await ordersController.UpdateAsync(updateOrderDTO);

            result.Should().BeOfType<JsonResult>();
        }

        [Theory, AutoDomainData]
        public async Task GetStoreOrdersAsync_RequestList_ReturnJsonResult([NoAutoProperties] OrdersController ordersController, [Frozen] Mock<IOrderService> mockOrderService, List<OrderDTO> ordersList)
        {
            mockOrderService.Setup(m => m.GetStoreOrdersAsync(It.IsAny<OrderFilterDTO>())).ReturnsAsync(ordersList);

            var result = await ordersController.GetStoreOrdersAsync(new OrderFilterDTO());

            result.Should().BeOfType<JsonResult>();
        }

        [Theory, AutoDomainData]
        public async Task GetOrderHistoryAsync_RequestList_ReturnJsonResult([NoAutoProperties] OrdersController ordersController, [Frozen] Mock<IOrderService> mockOrderService, List<OrderDTO> ordersList)
        {
            mockOrderService.Setup(m => m.GetOrderHistoryAsync(It.IsAny<OrderFilterDTO>())).ReturnsAsync(ordersList);

            var result = await ordersController.GetOrderHistoryAsync(new OrderFilterDTO());

            result.Should().BeOfType<JsonResult>();
        }


        [Theory, AutoDomainData]
        public async Task RemoveOrderDetailsAsync_RemoveExistedOrderDetails_ReturnOkResult([NoAutoProperties] OrdersController ordersController, [Frozen]Mock<IOrderService> mockOrderService)
        {
            mockOrderService.Setup(m => m.RemoveOrderDetailsAsync(It.IsAny<int>())).ReturnsAsync(true);

            var result = await ordersController.RemoveDetailsAsync(1);

            result.Should().BeOfType<OkResult>();
        }

    }
}
