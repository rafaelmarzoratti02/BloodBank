using BloodBank.Services.Donors.Core;
using BloodBank.Services.Donors.Core.Interfaces;
using BloodBank.Services.Donors.Core.Repositories;
using MongoDB.Driver;

namespace BloodBank.Services.Donors.Infra.Persistence.Repositories;

public class DonorRepository : IDonorRepository
{
    private readonly IMongoCollection<Donor> _collection;

    public DonorRepository(IMongoDbFactory mongoDbFactory)
    {
        var database = mongoDbFactory.GetDonorsDatabase(); 
        _collection = database.GetCollection<Donor>("donors");
    }

    public async Task<Donor> GetByIdAsync(Guid id)
    {
        return await _collection.Find(x => x.Id == id).SingleOrDefaultAsync();
    }

    public async Task AddAsync(Donor donor)
    {
        await _collection.InsertOneAsync(donor);
    }

    public async Task UpdateAsync(Donor donor)
    {
        await _collection.ReplaceOneAsync(x => x.Id == donor.Id, donor);
    }

    public async Task<bool> EmailExistsAsync(string email)
    {
        var filter = Builders<Donor>.Filter.Eq(x => x.Email, email);
        return await _collection.Find(filter).AnyAsync();
    }
}