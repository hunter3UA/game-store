using Microsoft.AspNetCore.Http;

namespace GameStore.API.Services.Abstract
{
    public interface IAuthService
    {
        int GetCookies(HttpContext context);
    }
}
