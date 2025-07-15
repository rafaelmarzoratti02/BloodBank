using BloodBank.Services.Donations.Core.Entities;
using BloodBank.Services.Donations.Core.Repositories;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Services.Donations.Infra.Persistence.Repositories;


public class DonationRepository : IDonationRepository
{
    private readonly IMongoCollection<Donation> _collection;

    public DonationRepository(IMongoDatabase mongoDatabase )
    {
        _collection = mongoDatabase.GetCollection<Donation>("donations");
    }

    public async Task AddAsync(Donation donation)
    {
        await _collection.InsertOneAsync(donation);
    }

    public async Task<List<Donation>> GetAsync()
    {
       return await _collection.Find(x => !x.IsDeleted).ToListAsync();
    }

    public async Task<List<Donation>> GetByDonorIdAsync(int donorId)
    {
        var filter = Builders<Donation>.Filter.Eq(x => x.DonorId, donorId);
        return await _collection.Find(filter).ToListAsync();
    }
}
