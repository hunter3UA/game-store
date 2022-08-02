using System;
using Microsoft.AspNetCore.Http;

namespace GameStore.API.Helpers
{
    public class CustomerGenerator : ICustomerGenerator
    {
        private const string CustomerIdKey = "CustomerId";

        public string GetCookies(HttpContext context)
        {
            string customerId;
            var cookies = context.Request.Cookies.ContainsKey(CustomerIdKey);
            if (!cookies)
            {
                customerId = CreateCookies(context);
            }
            else
            {
                context.Request.Cookies.TryGetValue(CustomerIdKey, out customerId);
            }

            return customerId;
        }

        private string CreateCookies(HttpContext context)
        {
            var customerId = Guid.NewGuid().ToString();
            context.Response.Cookies.Append(CustomerIdKey, customerId, new CookieOptions { Secure = true, Expires = DateTimeOffset.UtcNow.AddHours(1) });

            return customerId;
        }
    }
}
