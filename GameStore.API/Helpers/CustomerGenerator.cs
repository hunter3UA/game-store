using System;
using Microsoft.AspNetCore.Http;

namespace GameStore.API.Helpers
{
    public class CustomerGenerator : ICustomerGenerator
    {
        private const string CustomerIdKey = "CustomerId";

        public int GetCookies(HttpContext context)
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

            return Convert.ToInt32(customerId);
        }

        private string CreateCookies(HttpContext context)
        {
            Random rand = new Random();
            int customerId = rand.Next(1, int.MaxValue);
            context.Response.Cookies.Append(CustomerIdKey, customerId.ToString(), new CookieOptions { Secure = true, Expires = DateTimeOffset.UtcNow.AddHours(1) });

            return customerId.ToString();
        }
    }
}
