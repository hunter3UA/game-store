using GameStore.DAL.Context;
using GameStore.DAL.Context.Abstract;
using GameStore.DAL.Entities;
using GameStore.DAL.UoW.Abstract;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GameStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NorthwindController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWOrk;
        private readonly INorthwindDbContext _northwindDbContext;
        

        public NorthwindController(INorthwindDbContext northwindDbContext, IUnitOfWork unitOfWork)
        {
            _unitOfWOrk = unitOfWork;
            _northwindDbContext = northwindDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            Expression<Func<Game, object>> ex = g => g.Genres;
            var b = ex.Body;
            var res = await _unitOfWOrk.CommentRepository.GetAsync(g => g.Id == 3, g => g.Game, g => g.Game.Genres);
            //var res= await _unitOfWOrk.CommentRepository.GetAsync()


            return new JsonResult(res);

        }
    }
}
