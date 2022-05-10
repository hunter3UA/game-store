using GameStore.BLL.DTO.OrderDetails;
using GameStore.BLL.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GameStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [Route("/basket")]
        public async Task<IActionResult> GetOrderAsync()
        {
            var orderByCustomer = await _orderService.GetOrderAsync();

            if (orderByCustomer == null)
            {
                return BadRequest();
            }
            return Ok(orderByCustomer);
        }

        [HttpPost]
        [Route("/games/{gamekey}/buy")]
        public async Task<IActionResult> AddOrderDetailsAsync([FromRoute] string gamekey,[FromBody] AddOrderDetailsDTO addOrderDetailsDTO)
        {
            var addedOrderDetails = await _orderService.AddOrderDetailsAsync(gamekey, addOrderDetailsDTO);

            if (addedOrderDetails == null)
            {
                return BadRequest();
            }

            return Ok(addedOrderDetails);
        }

        [HttpPut]
        [Route("/basket/details/update")]
        public async Task<IActionResult> ChangeQuantityOfOrderDetails([FromBody] ChangeQuantityDTO changeQuantityDTO)
        {
            var updatedOrderDetails = await _orderService.ChangeQuantityOfDetails(changeQuantityDTO);

            if (updatedOrderDetails == null)
            {
                return BadRequest();
            }

            return Ok(updatedOrderDetails);           
        }
    }
}
