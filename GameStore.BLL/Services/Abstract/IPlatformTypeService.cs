using GameStore.BLL.DTO;
using GameStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.BLL.Services.Abstract
{
    public interface IPlatformTypeService
    {
        Task<PlatformTypeDTO> AddPlatformTypeAsync(AddPlatformTypeDTO addPlatformDTO);
        Task<List<PlatformTypeDTO>> GetListOfPlatformsAsync();
        Task<PlatformTypeDTO> GetPlatformAsync(Expression<Func<PlatformType, bool>> predicate);
        Task<bool> RemovePlatformAsync(int key);
    }
}
