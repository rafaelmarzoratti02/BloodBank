
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BloodBank.Services.Donors.Middleware;

public class InternalAuthMiddleware
{
    private readonly RequestDelegate _next;


    public InternalAuthMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path.StartsWithSegments("/api/donors") ||
            (context.Request.Path.StartsWithSegments("/api/users")))
        {
            var gatewayToken = context.Request.Headers["X-Gateway-Token"].FirstOrDefault();
            var sourceService = context.Request.Headers["X-Source-Service"].FirstOrDefault();

            if (string.IsNullOrEmpty(gatewayToken) || sourceService != "gateway")
            {

                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Direct access forbidden");
                return;
            }
        }

        await _next(context);
    }
}
