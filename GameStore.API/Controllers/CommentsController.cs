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
        [Route("/Comments/AddComment")]
        public async Task<CommentDTO> AddComment([FromBody]AddCommentDTO addCommentDTO)
        {
            return await _commentService.AddCommentAsync(addCommentDTO);
        }

        [HttpGet]
        [Route("/Comments/{gameKey}")]
        public async Task<CommentDTO> Get(Guid gameKey)
        {
            return await _commentService.GetAsync(c=>c.GameId==gameKey);
        }
        

     
      
    }
}
