using Microsoft.AspNetCore.Http;

namespace GameStore.API.Helpers
{
    public interface ICustomerGenerator
    {
        int GetCookies(HttpContext context);
    }
}
