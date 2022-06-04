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
        [Route("{gameKey}/new-comment")]
        public async Task<IActionResult> AddCommentAsync([FromRoute] string gameKey, [FromBody] AddCommentDTO addCommentDTO)
        {
            var addedComment = await _commentService.AddCommentAsync(gameKey, addCommentDTO);

            return new JsonResult(addedComment);
        }

        [HttpGet]
        [Route("{gameKey}/comments")]
        public async Task<IActionResult> GetCommentsAsync([FromRoute] string gameKey)
        {
            var commentsByGameKey = await _commentService.GetListOfCommentsAsync(gameKey);

            return new JsonResult(commentsByGameKey);
        }
    }
}
