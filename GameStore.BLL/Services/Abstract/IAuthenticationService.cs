using GameStore.BLL.DTO.Auth;
using GameStore.DAL.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace GameStore.BLL.Services.Abstract
{
    public interface IAuthenticationService
    {
        Task<string> GetJwtTokenAsync(AuthRequestDTO authRequestDTO);


        JwtSecurityToken ReadJwtToken(string expiredToken);
    }
}
