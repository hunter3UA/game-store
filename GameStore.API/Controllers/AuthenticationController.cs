using GameStore.BLL.DTO.Auth;
using GameStore.BLL.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GameStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthenticationService _authService;

        public AuthenticationController(IUserService userService, IAuthenticationService authService)
        {
            _userService = userService;
            _authService = authService;
        }


        [HttpPost]
        public async Task<IActionResult> RegisterUserAsync(RegisterDTO registerDTO)
        {
            var jwtToken = await _userService.RegisterUserAsync(registerDTO);

            return new JsonResult(jwtToken);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginUserAsync(AuthRequestDTO authRequestDTO)
        {
            var jwtToken = await _authService.GetJwtTokenAsync(authRequestDTO);
            if (jwtToken == null)
                return Unauthorized();

            return new JsonResult(jwtToken);
        }

        [HttpPost]
        [Route("refresh")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequestDTO refreshTokenRequestDTO)
        {
            var jwtToken = await _authService.RefreshTokenAsync(refreshTokenRequestDTO);
            if (jwtToken == null)
                return Unauthorized();

            return new JsonResult(jwtToken);
        }
    }
}
