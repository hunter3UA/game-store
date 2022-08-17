using System.Threading.Tasks;
using GameStore.API.Auth;
using GameStore.BLL.DTO.Comment;
using GameStore.BLL.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.API.Controllers
{
    [Route("api/games")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly IUserService _userService;

        public CommentsController(ICommentService commentService,IUserService userService)
        {
            _commentService = commentService;
            _userService = userService;
        }

        [HttpPost]
        [Route("{gameKey}/new-comment")]
        public async Task<IActionResult> AddAsync([FromRoute] string gameKey, [FromBody] AddCommentDTO addCommentDTO)
        {
            var addedComment = await _commentService.AddCommentAsync(gameKey, addCommentDTO);

            return new JsonResult(addedComment);
        }

        [HttpGet]
        [Route("{gameKey}/comments")]
        public async Task<IActionResult> GetAsync([FromRoute] string gameKey)
        {
            var commentsByGameKey = await _commentService.GetListOfCommentsAsync(gameKey);

            return new JsonResult(commentsByGameKey);
        }

        [HttpPut]
        [Route("comments/update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateCommentDTO updateCommentDTO)
        {
            var updatedComment = await _commentService.UpdateCommentAsync(updateCommentDTO);

            return new JsonResult(updatedComment);
        }

        [HttpDelete]
        [Route("comments/remove/{id}")]
        [Authorize(Roles =ApiRoles.ModeratorRole)]
        public async Task<IActionResult> RemoveAsync([FromRoute] int id)
        {
            await _commentService.RemoveCommentAsync(id);

            return Ok();
        }
    }
}
