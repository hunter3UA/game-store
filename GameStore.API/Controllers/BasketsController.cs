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
        private readonly IBasketService _basketService;
        private readonly ICustomerGenerator _customerGenerator;

        public BasketsController(IBasketService orderService,ICustomerGenerator customerGenerator)
        {
            _basketService = orderService;
            _customerGenerator = customerGenerator;
        }

        [HttpGet]   
        public async Task<IActionResult> GetAsync()
        {     
            var customerId = _customerGenerator.GetCookies(HttpContext);
            var orderByCustomer = await _basketService.GetBasketAsync(customerId);

            return new JsonResult(orderByCustomer);
        }

        [HttpGet]
        [Route("games/{gamekey}/buy")]
        public async Task<IActionResult> AddOrderDetailsAsync([FromRoute] string gamekey)
        {
            string customerId = string.Empty;
           
            customerId = _customerGenerator.GetCookies(HttpContext);
            var addedOrderDetails = await _basketService.AddOrderDetailsAsync(gamekey, customerId);

            return new JsonResult(addedOrderDetails);
        }

        [HttpDelete]
        [Route("details/{id}")]
        public async Task<IActionResult> RemoveOrderDetailsAsync([FromRoute] int id) 
        {
            await _basketService.RemoveOrderDetailsAsync(id);
            
            return Ok();
        }
    }
}
