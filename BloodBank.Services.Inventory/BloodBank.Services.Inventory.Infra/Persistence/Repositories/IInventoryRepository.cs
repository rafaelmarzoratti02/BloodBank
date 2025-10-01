using BloodBank.Services.Inventory.Core.Entities;
using BloodBank.Services.Inventory.Core.Repositories;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Services.Inventory.Infra.Persistence.Repositories;

public class InventoryRepository : IInvetoryRepository
{

    private readonly IMongoCollection<BloodStock> _collection;

    public InventoryRepository(IMongoDatabase mongoDatabase)
    {
        _collection = mongoDatabase.GetCollection<BloodStock>("inventory");
    }

    public async Task Insert(BloodStock bloodstock)
    {
        var stock = await _collection.Find(x => x.BloodType == bloodstock.BloodType && x.RhFactor == bloodstock.RhFactor).FirstOrDefaultAsync();
        stock.QuantityMl += bloodstock.QuantityMl;
    }

    public async Task Remove(BloodStock bloodstock)
    {
        var stock = await _collection.Find(x => x.BloodType == bloodstock.BloodType && x.RhFactor == bloodstock.RhFactor).FirstOrDefaultAsync();
        stock.QuantityMl -= bloodstock.QuantityMl;
    }
}
