using AutoMapper;
using GameStore.BLL.DTO.Shipper;
using GameStore.BLL.Services.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.BLL.Services.Implementation
{
    public class ShipperService : IShipperService
    {

        private readonly IMapper _mapper;

        public ShipperService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<List<ShipperDTO>> GetListOfShippersAsync()
        {
            return new List<ShipperDTO>();  
        }

    }
}
