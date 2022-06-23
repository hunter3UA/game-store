using GameStore.DAL.Context;
using GameStore.DAL.UoW.Abstract;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NorthwindController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWOrk;
        private readonly NorthwindDbContext _northwindDbContext;

        public NorthwindController(NorthwindDbContext northwindDbContext,IUnitOfWork unitOfWork)
        {
            _unitOfWOrk = unitOfWork;
            _northwindDbContext = northwindDbContext;
        }
    }
}
