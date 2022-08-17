using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using GameStore.API.Static;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace GameStore.API.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, IWebHostEnvironment env)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                await HandleException(error, context, env.IsDevelopment());
                _logger.LogError($"Error: {error.Message}");
            }

        }

        private async Task HandleException(Exception error,HttpContext context ,bool isDevelopment)
        {      
            context.Response.ContentType = Constants.JsonContentType;
            context.Response.StatusCode = GetCode(error);
            var responseBody = GetResponseBody(error,isDevelopment,context.Response.StatusCode);

            await context.Response.WriteAsync(responseBody);
        }

        private static int GetCode(Exception error)
        {
            switch (error)
            {
                case KeyNotFoundException e:
                    return (int)HttpStatusCode.NotFound;                 
                case DbUpdateException e:
                    return (int)HttpStatusCode.BadRequest;
                default:
                    return (int)HttpStatusCode.InternalServerError;
            }
        }

        private static string GetResponseBody(Exception ex, bool isDevelopment, int httpStatusCode)
        {
            string errorMessage;
            if (isDevelopment)
                errorMessage = ex.ToString();
            else if (httpStatusCode >= (int)HttpStatusCode.InternalServerError)
                errorMessage = "Something wrong Happened";
            else
                errorMessage = ex.Message;
            
            errorMessage = JsonConvert.SerializeObject(new { error = errorMessage });

            return errorMessage;
        }
    }
}

