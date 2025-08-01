using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBank.Services.ApiGateway;

public class AddHeadersHandler : DelegatingHandler
{
    
    private readonly IConfiguration _configuration;

    public AddHeadersHandler(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
    {
        request.Headers.Add("X-Gateway-Token", _configuration["InternalService:Token"]);
        request.Headers.Add("X-Source-Service", "gateway");

        return await base.SendAsync(request, cancellationToken);
    }
}
