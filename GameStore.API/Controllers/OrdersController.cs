using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using GameStore.BLL.DTO.OrderDetails;
using GameStore.BLL.Services.Abstract;
using GameStore.API.Services.Abstract;

namespace GameStore.API.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IAuthService _authService;

        public OrdersController(IOrderService orderService,IAuthService authService)
        {
            _orderService = orderService;
            _authService = authService;
        }

        [HttpGet]
        [Route("/basket")]
        public async Task<IActionResult> GetOrderAsync()
        {
            var customerId = _authService.GetCookies(HttpContext);
            var orderByCustomer = await _orderService.GetOrderAsync(customerId);

            if (orderByCustomer == null)
            {
                return NotFound();
            }

            return new JsonResult(orderByCustomer);
        }

        [HttpGet]
        [Route("/games/{gamekey}/buy")]
        public async Task<IActionResult> AddOrderDetailsAsync([FromRoute] string gamekey)
        {
            var customerId = _authService.GetCookies(HttpContext);
            var addedOrderDetails = await _orderService.AddOrderDetailsAsync(gamekey, customerId);

            if (addedOrderDetails == null)
            {
                return BadRequest();
            }

            return new JsonResult(addedOrderDetails);
        }

        [HttpPut]
        [Route("/basket/details/update")]
        public async Task<IActionResult> ChangeQuantityOfOrderDetailsAsync([FromBody] ChangeQuantityDTO changeQuantityDTO)
        {
            var updatedOrderDetails = await _orderService.ChangeQuantityOfDetailsAsync(changeQuantityDTO);

            if (updatedOrderDetails == null)
            {
                return BadRequest();
            }

            return new JsonResult(updatedOrderDetails);           
        }

        [HttpDelete]
        [Route("/basket/details/remove/{id}")]
        public async Task<IActionResult> RemoveOrderDetailsAsync([FromRoute] int id) 
        {
            var deletedOrderDetails = await _orderService.RemoveOrderDetailsAsync(id);

            if (!deletedOrderDetails)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
