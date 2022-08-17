using GameStore.API.Helpers;
using GameStore.BLL.DTO.Auth;
using GameStore.BLL.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthenticationService _authService;
        private readonly ICustomerHelper _customerHelper;
        private readonly IBasketService _basketService;

        public AuthenticationController(IBasketService basketService,IUserService userService, IAuthenticationService authService,ICustomerHelper customerGenerator)
        {
            _userService = userService;
            _authService = authService;
            _customerHelper = customerGenerator;
            _basketService = basketService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(RegisterDTO registerDTO)
        {
            var authRequest = await _userService.RegisterUserAsync(registerDTO);

            var jwtToken = await _authService.GetJwtTokenAsync(authRequest);
           
            return new JsonResult(jwtToken);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync(AuthRequestDTO authRequestDTO)
        {
            var oldUserId = _customerHelper.GetUserId(HttpContext);
        
            var jwtToken = await _authService.GetJwtTokenAsync(authRequestDTO);
            if (jwtToken == null)
                return Unauthorized();

            var newUserId = _authService.ReadJwtToken(jwtToken).Claims.FirstOrDefault();
            await _basketService.MergeOrdersAsync(oldUserId, newUserId.Value);

            return new JsonResult(jwtToken);
        }

    }
}
