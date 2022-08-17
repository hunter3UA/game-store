using Microsoft.AspNetCore.Http;

namespace GameStore.API.Helpers
{
    public interface ICustomerHelper
    {
        string GetUserId(HttpContext context);
    }
}
