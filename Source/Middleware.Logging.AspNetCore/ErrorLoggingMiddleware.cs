﻿using System;
using System.Threading.Tasks;
using Affecto.Logging;
using Microsoft.AspNetCore.Http;

namespace Affecto.Middleware.Logging.AspNetCore
{
    public class ErrorLoggingMiddleware : LoggingMiddleware
    {
        public ErrorLoggingMiddleware(ILoggerFactory loggerFactory)
            : base(loggerFactory)
        {
        }

        public override async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                logger.LogError(e, "Unhandled exception from request - {Method}: {Path}",
                    context.Request.Method,
                    context.Request.Path.Value);
            }
        }
    }
}