using BloodBank.Services.Donors.Core.Entities;
using BloodBank.Services.Donors.Core.Interfaces;
using BloodBank.Services.Donors.Core.Repositories;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace BloodBank.Services.Donors.Infra.Persistence.Repositories;
public class UserRepository : IUserRepository
{
    public UserRepository(IMongoDbFactory mongoDbFactory)
    {
        var database = mongoDbFactory.GetUsersDatabase();
        _collection = database.GetCollection<User>("users");
    }
    private readonly IMongoCollection<User> _collection;
    public async Task<User> GetByIdAsync(Guid id)
    {
        return await _collection.Find(x => x.Id == id).SingleOrDefaultAsync();
    }
    public async Task<Guid> AddAsync(User user)
    {
        await _collection.InsertOneAsync(user);
        return user.Id;
    }
    public async Task UpdateAsync(User user)
    {
        await _collection.ReplaceOneAsync(x => x.Id == user.Id, user);
    }
    public async Task<User> GetUserByEmailAndPasswordAsync(string email, string password)
    {
        return await _collection.Find(x => x.Email == email && x.Password == password).SingleOrDefaultAsync();
    }
    public async Task<bool> UserExistsAsync(string userId)
    {
        return await _collection.Find(x => x.Id == Guid.Parse(userId)).AnyAsync();
    }
}