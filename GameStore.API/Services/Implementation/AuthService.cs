using System;
using GameStore.API.Services.Abstract;
using Microsoft.AspNetCore.Http;

namespace GameStore.API.Services.Implementation
{
    public class AuthService : IAuthService
    {
        private const string KEY = "CustomerId";

        public int GetCookies(HttpContext context)
        {
            string customerId;
            var cookies = context.Request.Cookies.ContainsKey(KEY);
            if (!cookies)
            {
                customerId = CreateCookies(context);
            }
            else
            {
                context.Request.Cookies.TryGetValue(KEY, out customerId);
            }

            return Convert.ToInt32(customerId);
        }

        private string CreateCookies(HttpContext context)
        {
            Random rand = new Random();
            int customerId = rand.Next(1, int.MaxValue);
            context.Response.Cookies.Append(KEY, customerId.ToString(), new CookieOptions { Secure = true, Expires = DateTimeOffset.UtcNow.AddHours(1) });

            return customerId.ToString();
        }
    }
}
