using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GameStore.BLL.DTO.OrderDetails;
using GameStore.BLL.Services.Abstract;
using GameStore.API.Helpers;

namespace GameStore.API.Controllers
{
    [Route("api/basket")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _orderService;
        private readonly ICustomerGenerator _customerGenerator;

        public BasketsController(IBasketService orderService,ICustomerGenerator customerGenerator)
        {
            _orderService = orderService;
            _customerGenerator = customerGenerator;
        }

        [HttpGet]   
        public async Task<IActionResult> GetBasketAsync()
        {     
            var customerId = _customerGenerator.GetCookies(HttpContext);
            var orderByCustomer = await _orderService.GetBasketAsync(customerId);

            return new JsonResult(orderByCustomer);
        }

        [HttpGet]
        [Route("games/{gamekey}/buy")]
        public async Task<IActionResult> AddOrderDetailsAsync([FromRoute] string gamekey)
        {
            var customerId = _customerGenerator.GetCookies(HttpContext);
            var addedOrderDetails = await _orderService.AddOrderDetailsAsync(gamekey, customerId);

            return new JsonResult(addedOrderDetails);
        }

        [HttpPut]
        [Route("details/update")]
        public async Task<IActionResult> ChangeQuantityOfOrderDetailsAsync([FromBody] ChangeQuantityDTO changeQuantityDTO)
        {
            var updatedOrderDetails = await _orderService.ChangeQuantityOfDetailsAsync(changeQuantityDTO);
            
            return new JsonResult(updatedOrderDetails);           
        }

        [HttpDelete]
        [Route("details/{id}")]
        public async Task<IActionResult> RemoveOrderDetailsAsync([FromRoute] int id) 
        {
            await _orderService.RemoveOrderDetailsAsync(id);
            
            return Ok();
        }
    }
}
