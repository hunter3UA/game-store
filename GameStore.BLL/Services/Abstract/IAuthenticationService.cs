using GameStore.BLL.DTO.Auth;
using GameStore.DAL.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace GameStore.BLL.Services.Abstract
{
    public interface IAuthenticationService
    {
        Task<AuthResponseDTO> GetJwtTokenAsync(AuthRequestDTO authRequestDTO);

        Task<AuthResponseDTO> GetJwtTokenAsync(User user);

        Task<AuthResponseDTO> RefreshTokenAsync(RefreshTokenRequestDTO refreshTokenRequestDTO);

        JwtSecurityToken ReadJwtToken(string expiredToken);
    }
}
