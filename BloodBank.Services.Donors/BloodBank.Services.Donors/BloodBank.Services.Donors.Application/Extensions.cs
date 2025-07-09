using BloodBank.Services.Donors.Application.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace BloodBank.Services.Donors.Application;

public static class Extensions
{
    public static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<AddDonor>());
        
        return services;
    }
}