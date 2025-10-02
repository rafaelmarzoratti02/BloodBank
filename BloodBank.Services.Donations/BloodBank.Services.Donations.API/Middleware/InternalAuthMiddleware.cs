using System.Security.Claims;

namespace BloodBank.Services.Donations.Middleware;

public class InternalAuthMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IConfiguration _configuration;

    public InternalAuthMiddleware(
         RequestDelegate next,
         IConfiguration configuration)
    {
        _next = next;
        _configuration = configuration;
    }

    private readonly HashSet<string> _publicPaths = new(StringComparer.OrdinalIgnoreCase)
    {
        "/swagger",
        "/swagger/index.html",
        "/swagger/v1/swagger.json",
        "/health",
        "/_framework",
        "/_vs"
    };

    public async Task InvokeAsync(HttpContext context)
    {
        if (IsPublicPath(context.Request.Path))
        {
            await _next(context);
            return;
        }

        if (!context.Request.Headers.TryGetValue("X-Gateway-Token", out var gatewayToken))
        {
            context.Response.StatusCode = 403;
            await context.Response.WriteAsync("Forbidden: Missing gateway token");
            return;
        }

        var expectedToken = _configuration["Security:GatewayToken"];

        if (string.IsNullOrEmpty(expectedToken))
        {
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("Internal server error");
            return;
        }

        if (gatewayToken != expectedToken)
        {
            context.Response.StatusCode = 403;
            await context.Response.WriteAsync("Forbidden: Invalid gateway token");
            return;
        }

        if (!context.Request.Headers.TryGetValue("X-Source-Service", out var sourceService)
            || sourceService != "gateway")
        {
            context.Response.StatusCode = 403;
            await context.Response.WriteAsync("Forbidden: Invalid source service");
            return;
        }

        if (context.Request.Headers.TryGetValue("X-User-Id", out var userId)
            && !string.IsNullOrEmpty(userId))
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId!)
            };

            if (context.Request.Headers.TryGetValue("X-User-Email", out var email)
                && !string.IsNullOrEmpty(email))
            {
                claims.Add(new Claim(ClaimTypes.Email, email!));
            }

            if (context.Request.Headers.TryGetValue("X-User-Role", out var role)
                && !string.IsNullOrEmpty(role))
            {
                claims.Add(new Claim(ClaimTypes.Role, role!));
            }

            var identity = new ClaimsIdentity(claims, "Gateway");
            context.User = new ClaimsPrincipal(identity);
        }


        await _next(context);
    }

    private bool IsPublicPath(PathString path)
    {
        foreach (var publicPath in _publicPaths)
        {
            if (path.StartsWithSegments(publicPath, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }
        return false;
    }
}