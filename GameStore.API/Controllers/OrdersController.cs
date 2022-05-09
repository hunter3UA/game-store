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
        [Route("games/{gamekey}/buy")]

        public async Task<IActionResult> AddOrderDetailsAsync([FromRoute] string gamekey,[FromBody] AddOrderDetailsDTO addOrderDetailsDTO)
        {


            return Ok();
        }

    }
}
