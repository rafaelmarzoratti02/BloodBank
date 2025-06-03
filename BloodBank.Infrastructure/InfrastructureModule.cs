using BloodBank.Core.Repositories;
using BloodBank.Infrastructure.Persistence;
using BloodBank.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BloodBank.Infrastructure;

public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructureModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddRepositories()
            .AddData(configuration);
        return services;
    }
    
    private static void AddData(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("BloodBankCs");

        services.AddDbContext<BloodBankDbContext>(o => o.UseSqlServer(connectionString));
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IDoadorRepository, DoadorRepository>();
        services.AddScoped<IEstoqueSangueRepository, EstoqueSangueRepository>();

        return services;
    } 
}