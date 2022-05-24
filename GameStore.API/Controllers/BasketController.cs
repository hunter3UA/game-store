using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using GameStore.BLL.DTO.OrderDetails;
using GameStore.BLL.Services.Abstract;
using GameStore.API.Helpers;

namespace GameStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _orderService;
        private readonly ICustomerGenerator _customerGenerator;

        public BasketController(IBasketService orderService,ICustomerGenerator customerGenerator)
        {
            _orderService = orderService;
            _customerGenerator = customerGenerator;
        }

        [HttpGet]
        [Route("/basket")]
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

        [HttpGet]
        [Route("/games/{gamekey}/buy")]
        public async Task<IActionResult> AddOrderDetailsAsync([FromRoute] string gamekey)
        {
            var customerId = _customerGenerator.GetCookies(HttpContext);
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
