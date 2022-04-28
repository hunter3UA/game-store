using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GameStore.BLL.DTO;
using GameStore.DAL.Entities;

namespace GameStore.BLL.Services.Abstract
{
    public interface IPlatformTypeService
    {
        Task<PlatformTypeDTO> AddPlatformTypeAsync(AddPlatformTypeDTO addPlatformDTO);

        Task<List<PlatformTypeDTO>> GetListOfPlatformsAsync();

        Task<PlatformTypeDTO> GetPlatformAsync(int id);

        Task<bool> RemovePlatformAsync(int id);
    }
}
