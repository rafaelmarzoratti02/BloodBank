namespace BloodBank.Services.ApiGateway;

public class AddHeadersHandler : DelegatingHandler
{
    private readonly IConfiguration _configuration;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AddHeadersHandler(
        IConfiguration configuration,
        IHttpContextAccessor httpContextAccessor)
    {
        _configuration = configuration;
        _httpContextAccessor = httpContextAccessor;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var gatewayToken = _configuration["InternalService:Token"];
        request.Headers.Add("X-Gateway-Token", gatewayToken);
        request.Headers.Add("X-Source-Service", "gateway");

        var httpContext = _httpContextAccessor.HttpContext;

        if (httpContext?.User?.Identity?.IsAuthenticated == true)
        {
            var userId = httpContext.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            var userEmail = httpContext.User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value;
            var userRole = httpContext.User.FindFirst(System.Security.Claims.ClaimTypes.Role)?.Value;

            if (!string.IsNullOrEmpty(userId))
            {
                request.Headers.Add("X-User-Id", userId);

                if (!string.IsNullOrEmpty(userEmail))
                    request.Headers.Add("X-User-Email", userEmail);

                if (!string.IsNullOrEmpty(userRole))
                    request.Headers.Add("X-User-Role", userRole);
            }
        }

        // 4. Adiciona Correlation ID para rastreamento
        var correlationId = httpContext?.TraceIdentifier ?? Guid.NewGuid().ToString();
        if (!request.Headers.Contains("X-Correlation-Id"))
        {
            request.Headers.Add("X-Correlation-Id", correlationId);
        }

        return await base.SendAsync(request, cancellationToken);
    }
}