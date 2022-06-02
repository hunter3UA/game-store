using System.Threading.Tasks;
using GameStore.BLL.DTO.Comment;
using GameStore.BLL.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.API.Controllers
{
    [Route("api/games")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        [Route("{gameKey}/newcomment")]
        public async Task<IActionResult> AddCommentAsync([FromRoute] string gameKey, [FromBody] AddCommentDTO addCommentDTO)
        {
            var addedComment = await _commentService.AddCommentAsync(gameKey, addCommentDTO);

            if (addedComment == null)
                return BadRequest();

            return new JsonResult(addedComment);
        }

        [HttpGet]
        [Route("{gameKey}/comments")]
        public async Task<IActionResult> GetCommentsAsync([FromRoute] string gameKey)
        {
            var commentsByGameKey = await _commentService.GetListOfCommentsAsync(gameKey);

            if (commentsByGameKey == null)
                return NotFound();

            return new JsonResult(commentsByGameKey);
        }
    }
}
