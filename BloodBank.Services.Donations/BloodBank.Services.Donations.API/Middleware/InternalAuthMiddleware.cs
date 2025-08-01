namespace BloodBank.Services.Donations.Middleware;

public class InternalAuthMiddleware
{
    private readonly RequestDelegate _next;


    public InternalAuthMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path.StartsWithSegments("/api/donations"))
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
