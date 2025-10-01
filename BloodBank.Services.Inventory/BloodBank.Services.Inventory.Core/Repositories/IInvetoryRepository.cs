using BloodBank.Services.Inventory.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Services.Inventory.Core.Repositories;

public interface IInvetoryRepository
{
    Task Insert(BloodStock bloodstock);
    Task Remove(BloodStock bloodstock);

}

