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
        public async Task<CommentDTO> Add([FromBody]AddCommentDTO addCommentDTO)
        {
            return await _commentService.AddAsync(addCommentDTO);
        }


        [HttpGet]
        [Route("/Comments/{key}")]
        public async Task<CommentDTO> Get(Guid key)
        {
            return await _commentService.GetAsync(c=>c.GameId==key);
        }
        

     
      
    }
}
