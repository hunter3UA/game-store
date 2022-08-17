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
        private readonly ICustomerHelper _customerHelper;
        private readonly IAuthenticationService _jwtService;

        public BasketsController(IAuthenticationService authenticationService,IBasketService orderService,ICustomerHelper customerHelper)
        {
            _basketService = orderService;
            _customerHelper = customerHelper;
            _jwtService = authenticationService;
        }

        [HttpGet]   
        public async Task<IActionResult> GetAsync()
        {
            string customerId = _customerHelper.GetUserId(HttpContext);
           
            var orderByCustomer = await _basketService.GetBasketAsync(customerId);

            return new JsonResult(orderByCustomer);
        }

        [HttpGet]
        [Route("games/{gamekey}/buy")]
        public async Task<IActionResult> AddOrderDetailsAsync([FromRoute] string gamekey)
        {        
            string customerId = _customerHelper.GetUserId(HttpContext);

            var addedOrderDetails = await _basketService.AddOrderDetailsAsync(gamekey, customerId);

            return new JsonResult(addedOrderDetails);
        }


        [HttpPut]
        [Route("details/update")]
        public async Task<IActionResult> ChangeQuantityOfOrderDetailsAsync([FromBody] ChangeQuantityDTO changeQuantityDTO)
        {
            var updatedOrderDetails = await _basketService.ChangeQuantityOfDetailsAsync(changeQuantityDTO);

            return new JsonResult(updatedOrderDetails);
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
