using GameStore.BLL.DTO.Auth;
using GameStore.BLL.Services.Abstract;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.API.Middleware
{
    public class AuthTokenMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IAuthenticationService _jwtService;
    
        public AuthTokenMiddleware(RequestDelegate next,IAuthenticationService authenticationService)
        {
            _next = next;
            _jwtService = authenticationService;
        }


        public async Task InvokeAsync(HttpContext context, IWebHostEnvironment env)
        {
            var accessToken = context.Request.Headers["Authorization"].ToString();
            var refreshToken = context.Request.Cookies["refresh-token"];
            await _next(context);

            var jwtSecurityToken = _jwtService.ReadJwtToken(accessToken);
            

            if (!string.IsNullOrEmpty(accessToken) && jwtSecurityToken.ValidTo<DateTime.UtcNow)
            {
                var refreshTokenRequest = new RefreshTokenRequestDTO();
                refreshTokenRequest.ExpiredAccessToken = accessToken;
                refreshTokenRequest.RefreshToken = refreshToken;

                var newJwt = await _jwtService.RefreshTokenAsync(refreshTokenRequest);

                context.Response.Cookies.Append("refresh-token", newJwt.RefreshToken);
                //context.Response.
            }

          
        }
    }
}
