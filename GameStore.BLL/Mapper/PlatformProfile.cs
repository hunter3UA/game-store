using AutoMapper;
using GameStore.BLL.DTO;
using GameStore.BLL.DTO.Platform;
using GameStore.BLL.DTO.PlatformType;
using GameStore.DAL.Entities.Platforms;

namespace GameStore.BLL.Mapper
{
    public class PlatformProfile : Profile
    {
        public PlatformProfile()
        {
            CreateMap<PlatformType, PlatformTypeDTO>();
            CreateMap<AddPlatformTypeDTO, PlatformType>();
            CreateMap<UpdatePlatformTypeDTO, PlatformType>();
        }
    }
}
