using Microsoft.AspNetCore.Http;

namespace GameStore.BLL.Services.Abstract
{
    public interface IAuthService
    {
        string GetCookies(HttpContext context);
    }
}
