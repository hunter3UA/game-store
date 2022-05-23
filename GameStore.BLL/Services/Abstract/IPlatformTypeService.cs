using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GameStore.BLL.DTO;
using GameStore.BLL.DTO.Platform;
using GameStore.BLL.DTO.PlatformType;
using GameStore.DAL.Entities;

namespace GameStore.BLL.Services.Abstract
{
    public interface IPlatformTypeService
    {
        Task<PlatformTypeDTO> AddPlatformAsync(AddPlatformTypeDTO addPlatformDTO);

        Task<List<PlatformTypeDTO>> GetListOfPlatformsAsync();

        Task<PlatformTypeDTO> GetPlatformAsync(int id);

        Task<bool> RemovePlatformAsync(int id);

        Task<PlatformTypeDTO> UpdatePlatformAsync(UpdatePlatformTypeDTO updatePlatformDTO);
    }
}
