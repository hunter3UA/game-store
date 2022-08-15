using GameStore.BLL.DTO.Auth;
using GameStore.BLL.DTO.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.BLL.Services.Abstract
{
    public interface IUserService
    {
        Task<AuthRequestDTO> RegisterUserAsync(RegisterDTO registerDTO);

        Task<UserDTO> GetUserAsync(string userName);

        Task<List<UserDTO>> GetListOfUsersAsync();

        Task<UserDTO> UpdateUserAsync(UpdateUserDTO updateUserDTO);

        bool BanUser();
    }
}
