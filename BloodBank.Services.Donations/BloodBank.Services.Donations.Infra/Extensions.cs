using BloodBank.Services.Donations.Core.Repositories;
using BloodBank.Services.Donations.Infra.MessageBus;
using BloodBank.Services.Donations.Infra.Persistence;
using BloodBank.Services.Donations.Infra.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using RabbitMQ.Client;


namespace BloodBank.Services.Donations.Infra;

public static class Extensions
{
    public static IServiceCollection AddMongo(this IServiceCollection services)
    {
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

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IDonationRepository, DonationRepository>();

        return services;
    }

    //public static IServiceCollection AddMessageBus(this IServiceCollection services)
    //{
    //    var connectionFactory = new ConnectionFactory
    //    {
    //        HostName = "localhost"
    //    };

    //    var connection = connectionFactory.CreateConnectionAsync("donations-service-producer");

    //    services.AddSingleton(sp => new ProducerConnection(connection.Result));
    //    services.AddSingleton<IMessageBusClient, RabbitMQClient>();

    //    return services;
    //}
}
