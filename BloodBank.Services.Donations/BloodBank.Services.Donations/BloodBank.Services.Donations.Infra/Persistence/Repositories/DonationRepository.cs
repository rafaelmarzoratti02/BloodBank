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

    public async Task Add(Donation donation)
    {
        await _collection.InsertOneAsync(donation);
    }

    public async Task<List<Donation>> Get()
    {
       return await _collection.Find(x => !x.IsDeleted).ToListAsync();
    }

    public async Task<Donation> GetByDonorId(Guid id)
    {
        return await _collection.Find(x => x.Id == id && !x.IsDeleted).SingleOrDefaultAsync();
    }

}
