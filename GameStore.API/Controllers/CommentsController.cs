using GameStore.API.Static;
using GameStore.BLL.DTO;
using GameStore.BLL.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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
        [Route("/comments/addComment")]
        public async Task<ActionResult<CommentDTO>> AddCommentAsync([FromBody] AddCommentDTO addCommentDTO)
        {
            var addedComment = await _commentService.AddCommentAsync(addCommentDTO);
            if (addedComment == null)
                return BadRequest();

            return Ok(addedComment);
        }

        [HttpGet]
        [Route("/game/{gameKey}/comments")]
        [ResponseCache(CacheProfileName = Constants.CACHING_PROFILE_NAME)]
        public async Task<ActionResult<CommentDTO>> GetCommentAsync([FromRoute] int gameKey)
        {
            var commentByGameKey = await _commentService.GetCommentAsync(c => c.GameId == gameKey);
            if (commentByGameKey == null)
                return NotFound(commentByGameKey);

            return Ok(commentByGameKey);
        }
    }
}
