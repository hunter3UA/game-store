using System;
using System.Threading.Tasks;
using GameStore.API.Auth;
using GameStore.API.Helpers;
using GameStore.API.Static;
using GameStore.BLL.DTO.Order;
using GameStore.BLL.DTO.OrderDetails;
using GameStore.BLL.Enum;
using GameStore.BLL.Services.Abstract;
using GameStore.BLL.Services.Implementation.PaymentServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace GameStore.API.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ICustomerHelper _customerHelper;
        private readonly IPaymentContext _paymentContext;

        public OrdersController(IOrderService orderService, ICustomerHelper customerGenerator, IPaymentContext paymentContext)
        {
            _orderService = orderService;
            _customerHelper = customerGenerator;
            _paymentContext = paymentContext;
        }

        [HttpPost]
        [Route("pay")]
        public async Task<IActionResult> PayAsync([FromBody] OrderPaymentDTO orderPayment)
        {
            switch (orderPayment.PaymentType)
            {
                case PaymentType.BankPayment:
                    _paymentContext.SetStrategy(new BankPayment());
                    object stream = await _paymentContext.ExecutePay(orderPayment.OrderId);
                    return File((byte[])stream, Constants.TextPlainContentType, $"{orderPayment.OrderId}{DateTime.Now.Ticks}");
                case PaymentType.IBoxPayment:
                    _paymentContext.SetStrategy(new IBoxPayment());
                    await _paymentContext.ExecutePay(orderPayment.OrderId);
                    return Ok();
                case PaymentType.VisaPayment:
                    _paymentContext.SetStrategy(new VisaPayment());
                    await _paymentContext.ExecutePay(orderPayment.OrderId);
                    break;
            }
            return Ok();
        }

        [HttpGet]
        [Route("history")]
        [Authorize(Roles = ApiRoles.ManagerRole)]
        public async Task<IActionResult> GetOrderHistoryAsync([FromQuery] OrderFilterDTO orderFilterDTO)
        {
            var orders = await _orderService.GetOrderHistoryAsync(orderFilterDTO);
            return new JsonResult(orders);
        }

        [HttpGet]
        [Authorize(Roles = ApiRoles.ManagerRole)]
        public async Task<IActionResult> GetStoreOrdersAsync([FromQuery] OrderFilterDTO orderFilterDTO)
        {
            var storeOrders = await _orderService.GetStoreOrdersAsync(orderFilterDTO);

            return new JsonResult(storeOrders);
        }

        [HttpPost]
        public async Task<IActionResult> MakeOrderAsync([FromBody] int orderId)
        {
            var createdOrder = await _orderService.MakeOrderAsync(orderId);

            return new JsonResult(createdOrder);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateOrderDTO updateOrderDTO)
        {
            var updatedOrder = await _orderService.UpdateOrderAsync(updateOrderDTO);

            return new JsonResult(updatedOrder);
        }

        [HttpDelete]
        [Route("{orderId}")]
        public async Task<IActionResult> CancelOrderAsync([FromRoute] int orderId)
        {
            await _orderService.CancelOrderAsync(orderId);

            return Ok();
        }

        [HttpGet]
        [Route("/api/order")]
        public async Task<IActionResult> GetByCustomerAsync()
        {
            var customerId = _customerHelper.GetUserId(HttpContext);
            var orderByCustomer = await _orderService.GetOrderAsync(customerId);

            return new JsonResult(orderByCustomer);
        }

        [HttpGet]
        [Route("{orderId}")]
        public async Task<IActionResult> GetByOrderIdAsync([FromRoute] int orderId)
        {
            var orderById = await _orderService.GetOrderAsync(orderId);

            return new JsonResult(orderById);
        }

        [HttpDelete]
        [Route("details/{detailsId}")]
        public async Task<IActionResult> RemoveDetailsAsync([FromRoute] int detailsId)
        {
            await _orderService.RemoveOrderDetailsAsync(detailsId);

            return Ok();
        }
    }
}
