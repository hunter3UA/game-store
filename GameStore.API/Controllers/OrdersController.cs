using System;
using System.Threading.Tasks;
using GameStore.API.Helpers;
using GameStore.API.Static;
using GameStore.BLL.DTO.Order;
using GameStore.BLL.Enum;
using GameStore.BLL.Services.Abstract;
using GameStore.BLL.Services.Implementation.PaymentServices;
using Microsoft.AspNetCore.Mvc;


namespace GameStore.API.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ICustomerGenerator _customerGenerator;
        private readonly IPaymentContext _paymentContext;

        public OrdersController(IOrderService orderService,ICustomerGenerator customerGenerator,IPaymentContext paymentContext)
        {
            _orderService = orderService;
            _customerGenerator = customerGenerator;
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
                    return File((byte[])stream, Constants.TextPlainContentType,$"{orderPayment.OrderId}{DateTime.Now.Ticks}");
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
        public async Task<IActionResult> GetOrdersAsync([FromQuery] OrderHistoryDTO orderHistoryDTO)
        {
            var orders = await _orderService.GetListOfOrdersAsync(orderHistoryDTO);
            return new JsonResult(orders);
        }

        [HttpGet]
        [Route("{orderId}")]
        public async Task<IActionResult> MakeOrderAsync([FromRoute] int orderId)
        {
            var createdOrder = await _orderService.MakeOrderAsync(orderId);

            return new JsonResult(createdOrder);
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
        public async Task<IActionResult> GetOrderAsync()
        {
            var customerId = _customerGenerator.GetCookies(HttpContext);
            var orderByCustomer = await _orderService.GetOrderAsync(customerId);

            return new JsonResult(orderByCustomer);
        }
    }
}
