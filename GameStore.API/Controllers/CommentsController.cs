using System.Threading.Tasks;
using GameStore.API.Static;
using GameStore.BLL.DTO;
using GameStore.BLL.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        [Route("/game/{gameKey}/newcomment")]
        public async Task<IActionResult> AddCommentAsync([FromRoute] string gameKey, [FromBody] AddCommentDTO addCommentDTO)
        {
            var addedComment = await _commentService.AddCommentAsync(gameKey, addCommentDTO);

            if (addedComment == null)
            {
                return BadRequest();
            }

            return Ok(addedComment);
        }

        [HttpGet]
        [Route("/game/{gameKey}/comments")]
        [ResponseCache(CacheProfileName = Constants.CACHING_PROFILE_NAME)]
        public async Task<IActionResult> GetCommentAsync([FromRoute] string gameKey)
        {
            var commentByGameKey = await _commentService.GetCommentAsync(c => c.Game.Key == gameKey);

            if (commentByGameKey == null)
            {
                return NotFound(commentByGameKey);
            }

            return Ok(commentByGameKey);
        }

        [HttpDelete]
        [Route("/comments/remove/{id}")]
        public async Task<IActionResult> RemoveCommentAsync([FromRoute] int id)
        {
            bool isRemovedComment = await _commentService.RemoveCommentAsync(id);

            if (!isRemovedComment)
            {
                return NotFound(isRemovedComment);
            }

            return Ok($"{isRemovedComment}. Comment with Id {id} has been deleted");
        }
    }
}
