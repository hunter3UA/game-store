using GameStore.BLL.DTO.Shipper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.BLL.Services.Abstract
{
    public interface IShipperService
    {
        Task<List<ShipperDTO>> GetListOfShippersAsync();
    }
}
