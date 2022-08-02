using GameStore.BLL.DTO.Auth;
using GameStore.BLL.DTO.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.BLL.Services.Abstract
{
    public interface IUserService
    {
        Task<AuthResponseDTO> RegisterUserAsync(RegisterDTO registerDTO);

        Task<UserDTO> GetUserAsync(string email);

        Task<List<UserDTO>> GetListOfUsersAsync();

        bool BanUser();
    }
}
