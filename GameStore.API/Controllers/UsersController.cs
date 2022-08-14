using GameStore.API.Auth;
using GameStore.BLL.DTO.User;
using GameStore.BLL.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
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

        public UsersController(IUserService userService, IAuthenticationService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        [HttpGet]
        public async Task<IActionResult> GetListAsync()
        {
            var users = await _userService.GetListOfUsersAsync();

            return new JsonResult(users);
        }

        [HttpGet]
        [Route("{userName}")]
        public async Task<IActionResult> GetAsync([FromRoute] string userName)
        {
            var userByName = await _userService.GetUserAsync(userName);

            return new JsonResult(userByName);
        }

        [HttpPut]
        [Authorize(Roles = ApiRoles.UserRole)]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateUserDTO updateUserDTO)
        {
            var updatedUser = await _userService.UpdateUserAsync(updateUserDTO);

            return new JsonResult(updatedUser);
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
