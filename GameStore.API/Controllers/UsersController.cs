using GameStore.BLL.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GameStore.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthenticationService _authService;

        public UsersController(IUserService userService,IAuthenticationService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsersAsync()
        {
            var res = HttpContext.User.Claims;
            var users = await _userService.GetListOfUsersAsync();

            return new JsonResult(users);
        }




        

        [HttpGet]
        [Route("ban")]
        public IActionResult BanUser()
        {
            _userService.BanUser();

            return Ok();
        }
    }
}
