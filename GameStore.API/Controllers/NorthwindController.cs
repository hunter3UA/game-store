using GameStore.DAL.Context;
using GameStore.DAL.Context.Abstract;
using GameStore.DAL.Entities;
using GameStore.DAL.UoW.Abstract;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace GameStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NorthwindController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWOrk;
        private readonly INorthwindDbContext _northwindDbContext;
        private readonly IMongoCollection<Game> products;

        //public NorthwindController(NorthwindDbContext northwindDbContext,IUnitOfWork unitOfWork)
        //{
        //    _unitOfWOrk = unitOfWork;
        //    _northwindDbContext = northwindDbContext;
        //}

        //[HttpGet]
        //public async Task<IActionResult> Get()
        //{
     
        //    var res = await _northwindDbContext.Orders.GetListAsync();
        //  //  _northwindDbContext.UpdateDb();

        //    return new JsonResult(res);
        //}
    }
}
