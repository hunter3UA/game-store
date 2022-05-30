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
using System.Threading.Tasks;
using Xunit;

namespace GameStore.Tests.Controllers
{
    public class OrdersControllerTest
    {
        [Theory, AutoDomainData]
        public async Task MakeOrderAsync_GivenValidOrderId_ReturnOkResult([Frozen] Mock<IOrderService> mockOrderService, [NoAutoProperties] OrdersController ordersController)
        {
            mockOrderService.Setup(m => m.MakeOrderAsync(It.IsAny<int>())).ReturnsAsync(() => { return new OrderDTO(); });

            var result = await ordersController.MakeOrderAsync(1);

            result.Should().BeOfType<OkObjectResult>();
        }

        [Theory, AutoDomainData]
        public async Task MakeOrderAsync_GivenInValidOrderId_ReturnBadRequestResult([Frozen] Mock<IOrderService> mockOrderService, [NoAutoProperties] OrdersController ordersController)
        {
            mockOrderService.Setup(m => m.MakeOrderAsync(It.IsAny<int>())).ReturnsAsync(() => { return null; });

            var result = await ordersController.MakeOrderAsync(1);

            result.Should().BeOfType<BadRequestResult>();
        }

        [Theory, AutoDomainData]
        public async Task GetOrderAsync_GivenValidOrder_ReturnJsonResult([Frozen] Mock<IOrderService> mockOrderService, Mock<ICustomerGenerator> mockCustomerGenerator, [NoAutoProperties] OrdersController ordersController)
        {
            mockCustomerGenerator.Setup(m => m.GetCookies(It.IsAny<HttpContext>())).Returns(1);
            mockOrderService.Setup(m => m.GetOrderAsync(It.IsAny<int>())).ReturnsAsync(new OrderDTO());

            var result = await ordersController.GetOrderAsync();

            result.Should().BeOfType<JsonResult>();
        }

        [Theory, AutoDomainData]
        public async Task GetOrderAsync_GivenInValidOrder_ReturnNotFoudResult([Frozen] Mock<IOrderService> mockOrderService, [NoAutoProperties] OrdersController ordersController)
        {
            mockOrderService.Setup(m => m.GetOrderAsync(It.IsAny<int>())).ReturnsAsync(() => { return null; });

            var result = await ordersController.GetOrderAsync();

            result.Should().BeOfType<NotFoundResult>();
        }

        [Theory, AutoDomainData]
        public async Task CancelOrderAsync_GivenValidOrder_ReturnOkObjectResult([Frozen] Mock<IOrderService> mockOrderService, [NoAutoProperties] OrdersController ordersController)
        {
            mockOrderService.Setup(m => m.CancelOrderAsync(It.IsAny<int>())).ReturnsAsync(true);

            var result = await ordersController.CancelOrderAsync(1);

            result.Should().BeOfType<OkResult>();
        }

        [Theory, AutoDomainData]
        public async Task CancelOrderAsync_GivenInvalidOrder_ReturnBadRequest([Frozen] Mock<IOrderService> mockOrderService, [NoAutoProperties] OrdersController ordersController)
        {
            mockOrderService.Setup(m => m.CancelOrderAsync(It.IsAny<int>())).ReturnsAsync(false);

            var result = await ordersController.CancelOrderAsync(1);

            result.Should().BeOfType<BadRequestResult>();
        }
    
        [Theory,AutoDomainData]
        public async Task PayAsync_GivenValidVisaPaymentOrder_ReturnOkResult([Frozen]Mock<IPaymentContext> mockPaymentContext,[NoAutoProperties] OrdersController ordersController)
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
        public async Task PayAsync_GivenValidBankPaymentOrder_ReturnOkResult([Frozen] Mock<IPaymentContext> mockPaymentContext, [NoAutoProperties] OrdersController ordersController)
        {
            mockPaymentContext.Setup(m => m.ExecutePay(It.IsAny<int>())).ReturnsAsync(new object());

            var result = await ordersController.PayAsync(new OrderPaymentDTO() { OrderId = 1, PaymentType = BLL.Enum.PaymentType.BankPayment });

            result.Should().BeOfType<PhysicalFileResult>();
        }
    }
}
