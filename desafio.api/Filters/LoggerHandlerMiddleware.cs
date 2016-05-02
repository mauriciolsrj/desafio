using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.Logging;
using System.Threading.Tasks;
using System.Net;
using desafio.app;
using System;
using desafio.app.model;

namespace desafio.api
{
    public class LoggerHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public LoggerHandlerMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<LoggerHandlerMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            _logger.LogInformation("Iniciando requisição: " + context.Request.Path);
            
            await _next.Invoke(context);
            
            _logger.LogInformation("Encerrada a requisição.");
            
            await _next(context);
        }
    }
    
    public static class LoggerHandlerExtensions
    {
        public static IApplicationBuilder UseLoggerHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggerHandlerMiddleware>();
        }
    }
}