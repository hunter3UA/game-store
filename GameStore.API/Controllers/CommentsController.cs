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
        public async Task<CommentDTO> AddCommentAsync([FromBody]AddCommentDTO addCommentDTO)
        {
            var addedComment = await _commentService.AddCommentAsync(addCommentDTO);
            return addedComment;
        }

        [HttpGet]
        [Route("/game/{gameKey}/comments")]
        [ResponseCache(CacheProfileName = "Caching")]
        public async Task<CommentDTO> GetCommentAsync([FromRoute]int gameKey)
        {
            var commentByGameKey = await _commentService.GetCommentAsync(c=>c.GameId==gameKey);
            return commentByGameKey;
        }
        

     
      
    }
}
