using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using GameStore.BLL.DTO.OrderDetails;
using GameStore.BLL.Services.Abstract;
using System;

namespace GameStore.API.Controllers
{
    [EnableCors("AllowOrigin")]
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
        [Route("/basket/{id}")]
        public async Task<IActionResult> GetOrderAsync([FromRoute] int id)
        {
            var orderByCustomer = await _orderService.GetOrderAsync(id);

            if (orderByCustomer == null)
            {
                return NotFound();
            }

            return Ok(orderByCustomer);
        }

        [HttpPost]
        [Route("/games/{gamekey}/buy")]
        public async Task<IActionResult> AddOrderDetailsAsync([FromRoute] string gamekey,[FromBody] int customerId)
        {
         
            var addedOrderDetails = await _orderService.AddOrderDetailsAsync(gamekey, customerId);

            if (addedOrderDetails == null)
            {
                return BadRequest();
            }

            return Ok(addedOrderDetails);
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

            return Ok(updatedOrderDetails);           
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
