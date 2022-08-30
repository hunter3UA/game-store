using AutoMapper;
using GameStore.BLL.DTO.Shipper;
using GameStore.BLL.Services.Abstract;
using GameStore.DAL.Context.Abstract;
using GameStore.DAL.Entities.Northwind;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.BLL.Services.Implementation
{
    public class ShipperService : IShipperService
    {
        private readonly INorthwindFactory _northwindDbContext;
        private readonly IMapper _mapper;

        public ShipperService(INorthwindFactory northwindDbContext,IMapper mapper)
        {
            _northwindDbContext = northwindDbContext;
            _mapper = mapper;
        }

        public async Task<List<ShipperDTO>> GetListOfShippersAsync()
        {
            List<Shipper> shippers = await _northwindDbContext.ShipperRepository.GetListAsync();

            return _mapper.Map <List<ShipperDTO>>(shippers);  
        }

    }
}
