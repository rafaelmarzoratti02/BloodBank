using BloodBank.Services.Donors.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Services.Donors.Infra.Persistence;

public class MongoDbFactory : IMongoDbFactory
{
    private readonly IMongoClient _mongoClient;
    private readonly IConfiguration _configuration;

    public MongoDbFactory(IMongoClient mongoClient, IConfiguration configuration)
    {
        _mongoClient = mongoClient;
        _configuration = configuration;
    }

    public IMongoDatabase GetDonorsDatabase()
    {
        var dbName = _configuration["Mongo:Database"];
        return _mongoClient.GetDatabase(dbName);
    }

    public IMongoDatabase GetUsersDatabase()
    {
        var dbName = _configuration["MongoUsers:Database"];
        return _mongoClient.GetDatabase(dbName);
    }
}

