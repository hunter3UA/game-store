using System.IO;
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
    [Route("api/[controller]")]
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
        [Route("/pay")]
        public async Task<IActionResult> PayAsync([FromBody] OrderPaymentDTO orderPayment)
        {       
            switch (orderPayment.PaymentType)
            {
                case PaymentType.BankPayment:
                    _paymentContext.SetStrategy(new BankPayment());
                    object filePath = await _paymentContext.ExecutePay(orderPayment.OrderId);
                    return PhysicalFile(filePath.ToString(), Constants.TEXT_PLAIN_CONTENT_TYPE, Path.GetFileName(filePath.ToString()));
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
        [Route("/order/{orderId}")]
        public async Task<IActionResult> MakeOrderAsync([FromRoute] int orderId)
        {
            var createdOrder = await _orderService.MakeOrderAsync(orderId);

            if (createdOrder == null)
            {
                return BadRequest();
            }

            return Ok(createdOrder);
        }

        [HttpDelete]
        [Route("/order/{orderId}")]
        public async Task<IActionResult> CancelOrderAsync([FromRoute] int orderId)
        {
            var canceledOrder = await _orderService.CancelOrderAsync(orderId);

            if (canceledOrder == false)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpGet]
        [Route("/order")]
        public async Task<IActionResult> GetOrderAsync()
        {
            var customerId = _customerGenerator.GetCookies(HttpContext);
            var orderByCustomer = await _orderService.GetOrderAsync(customerId);

            if (orderByCustomer == null)
            {
                return NotFound();
            }

            return new JsonResult(orderByCustomer);
        }
    }
}
