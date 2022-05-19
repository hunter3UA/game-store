using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using GameStore.API.Static;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace GameStore.API.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IDictionary<Type, HttpStatusCode> _handledExceptions;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _handledExceptions = new Dictionary<Type, HttpStatusCode>();
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, IWebHostEnvironment env)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                await HandleException(context, e, env.IsDevelopment());
                _logger.LogError($"Error: {e.Message}");
            }  
            
        }

        private static string GetResponseBody(Exception ex, bool isDevelopment, int httpStatusCode)
        {
            string errorMessage;
            if (isDevelopment)
            {
                errorMessage = ex.ToString();
            }
            else if (httpStatusCode >= (int)HttpStatusCode.InternalServerError)
            {
                errorMessage = "Something wrong Happened";
            }
            else
            {
                errorMessage = ex.Message;
            }

            errorMessage = JsonConvert.SerializeObject(new { error = errorMessage });

            return errorMessage;
        }

        private Task HandleException(HttpContext context, Exception ex, bool isDevelopment)
        {
            var httpStatusCode = (int)GetCode(ex);
            var responseBody = GetResponseBody(ex, isDevelopment, httpStatusCode);
            context.Response.ContentType = Constants.JSON_CONTENT_TYPE;
            context.Response.StatusCode = httpStatusCode;

            return context.Response.WriteAsync(responseBody);
        }

        private HttpStatusCode GetCode(Exception ex)
        {
            var exceptionToHandle = (ex as AggregateException)?.InnerExceptions.First() ?? ex;
            var exceptionType = exceptionToHandle.GetType();

            return _handledExceptions.TryGetValue(exceptionType, out HttpStatusCode httpCode) ? httpCode : HttpStatusCode.InternalServerError;
        }
    }
}