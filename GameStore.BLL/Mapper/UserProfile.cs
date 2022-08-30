using AutoMapper;
using GameStore.BLL.DTO.Auth;
using GameStore.BLL.DTO.User;
using GameStore.DAL.Entities.GameStore;

namespace GameStore.BLL.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterDTO, User>();
            CreateMap<User, UserDTO>();
        }
    }
}
