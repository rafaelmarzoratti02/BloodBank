using BloodBank.Services.Donors.Core.Interfaces;
using BloodBank.Services.Donors.Core.Repositories;
using BloodBank.Services.Donors.Infra.Persistence;
using BloodBank.Services.Donors.Infra.Persistence.Repositories;
using BloodBank.Services.Donors.Infra.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace BloodBank.Services.Donors.Infra;

public static class Extensions
{
    public static IServiceCollection AddMongo(this IServiceCollection services)
    {
        BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));

        services.AddSingleton<IMongoClient>(sp =>
        {
            var configuration = sp.GetService<IConfiguration>();
            var connectionString = configuration["Mongo:ConnectionString"];
            return new MongoClient(connectionString);
        });

        services.AddSingleton<IMongoDbFactory, MongoDbFactory>();

        return services;
    }


    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IDonorRepository, DonorRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
    
     public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey
                            (Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                    };
                });
            
            return services;
        }
}