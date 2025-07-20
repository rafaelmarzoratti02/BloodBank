using BloodBank.Services.Donors.Core.Repositories;
using BloodBank.Services.Donors.Infra.Persistence;
using BloodBank.Services.Donors.Infra.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace BloodBank.Services.Donors.Infra;

public static class Extensions
{
    public static IServiceCollection AddMongo(this IServiceCollection services) {
        
        BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));
        
        services.AddSingleton(sp => {
            var configuration = sp.GetService<IConfiguration>();
            var options = new MongoDbOptions();

            configuration.GetSection("Mongo").Bind(options);

            return options;
        });

        services.AddSingleton<IMongoClient>(sp => {
            var options = sp.GetService<MongoDbOptions>();

            return new MongoClient(options.ConnectionString);
        });

        services.AddTransient(sp =>
        {
            
            var options = sp.GetService<MongoDbOptions>();
            var mongoClient = sp.GetService<IMongoClient>();

            return mongoClient.GetDatabase(options.Database);
        });
            
        return services;
    }
    
    public static IServiceCollection AddRepositories(this IServiceCollection services) {
        services.AddScoped<IDonorRepository, DonorRepository>();

        return services;
    }
}