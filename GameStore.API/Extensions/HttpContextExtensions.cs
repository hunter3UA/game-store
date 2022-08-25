using GameStore.BLL.DTO.User;
using GameStore.BLL.Enums;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace GameStore.API.Extensions
{
    public static class HttpContextExtensions
    {
        public static string GetAuthToken(this HttpContext context)
        {
            if (context.User.Identity.IsAuthenticated)
            {
                const string AuthTokenHeader = "Authorization";
                var accessToken = context.Request.Headers[AuthTokenHeader].ToString();
                accessToken = accessToken.Substring(accessToken.IndexOf(" ") + 1);

                return accessToken;
            }

            return string.Empty;
        }

        public static UserDTO GetUser(this HttpContext context)
        {
            if (!context.User.Identity.IsAuthenticated)
                return null;

            var securityTokenHandler = new JwtSecurityTokenHandler();
            var accessToken = context.GetAuthToken();
            var decodedToken = securityTokenHandler.ReadJwtToken(accessToken);
  
            var user = new UserDTO
            {
                Id = decodedToken.Claims.FirstOrDefault(c => c.Type == CustomClaimTypes.Sid)?.Value,
                UserName = decodedToken.Claims.FirstOrDefault(c => c.Type == CustomClaimTypes.Name)?.Value,
                Email = decodedToken.Claims.FirstOrDefault(c => c.Type == CustomClaimTypes.Email)?.Value,
                Role = decodedToken.Claims.FirstOrDefault(c => c.Type == CustomClaimTypes.Role)?.Value,
                PublisherName = decodedToken.Claims.FirstOrDefault(c => c.Type == CustomClaimTypes.Publisher)?.Value
            };

            return user;
        }
    }
}