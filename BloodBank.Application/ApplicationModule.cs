﻿using BloodBank.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BloodBank.Application;

public static class ApplicationModule
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddServices();
        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IDoadorService, DoadorService>();
        return services;
    }
    
    
}