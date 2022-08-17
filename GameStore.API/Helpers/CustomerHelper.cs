using System;
using System.Linq;
using System.Security.Claims;
using GameStore.BLL.Services.Abstract;
using Microsoft.AspNetCore.Http;

namespace GameStore.API.Helpers
{
    public class CustomerHelper : ICustomerHelper
    {
        private readonly IAuthenticationService _jwtService;
        private const string CustomerIdKey = "CustomerId";
        private const string AuthTokenHeader = "Authorization";

        public CustomerHelper(IAuthenticationService jwtService)
        {
            _jwtService = jwtService;
        }

        public string GetUserId(HttpContext context)
        {
            string customerId;
        
            if (context.User.Identity.IsAuthenticated)
            {
                var accessToken = context.Request.Headers[AuthTokenHeader].ToString();
                accessToken = accessToken.Substring(accessToken.IndexOf(" ")+1);
                var decodedToken = _jwtService.ReadJwtToken(accessToken);
                customerId = decodedToken.Claims.First(c=>c.Type==ClaimTypes.Sid).Value;
                return customerId;
            }

            var hasCustomerId = context.Request.Cookies.ContainsKey(CustomerIdKey);
            if (!hasCustomerId)
                customerId = CreateCookies(context);
            else
                context.Request.Cookies.TryGetValue(CustomerIdKey, out customerId);
            

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
