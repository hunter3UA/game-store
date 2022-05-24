using GameStore.API.Helpers;
using GameStore.BLL.Services.Abstract;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GameStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ICustomerGenerator _customerGenerator;

        public OrdersController(IOrderService orderService,ICustomerGenerator customerGenerator)
        {
            _orderService = orderService;
            _customerGenerator = customerGenerator;

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

        //[HttpDelete]
        //public async Task<IActionResult> CancelOrderAsync([FromRoute] int orderId)
        //{

        //}
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
