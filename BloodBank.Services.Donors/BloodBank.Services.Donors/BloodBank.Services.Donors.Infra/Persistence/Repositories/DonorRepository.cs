using BloodBank.Services.Donors.Core;
using BloodBank.Services.Donors.Core.Repositories;
using MongoDB.Driver;

namespace BloodBank.Services.Donors.Infra.Persistence.Repositories;

public class DonorRepository : IDonorRepository
{
    public DonorRepository(IMongoDatabase mongoDatabase)
    {
        _collection = mongoDatabase.GetCollection<Donor>("donors");
    }

    private readonly IMongoCollection<Donor> _collection;
    
    public async Task<Donor> GetByIdAsync(Guid id)
    {
        return await _collection.Find(x => x.Id == id).SingleOrDefaultAsync();
    }

    public async Task AddAsync(Donor donor)
    {
        await  _collection.InsertOneAsync(donor);
    }

    public async Task UpdateAsync(Donor donor)
    {
       await _collection.ReplaceOneAsync(x => x.Id == donor.Id, donor);
    }
}