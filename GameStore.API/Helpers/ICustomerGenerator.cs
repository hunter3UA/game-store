using Microsoft.AspNetCore.Http;

namespace GameStore.API.Helpers
{
    public interface ICustomerGenerator
    {
        string GetCookies(HttpContext context);
    }
}
