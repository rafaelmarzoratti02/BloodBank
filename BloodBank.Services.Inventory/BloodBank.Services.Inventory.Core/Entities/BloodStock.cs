using BloodBank.Services.Inventory.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Services.Inventory.Core.Entities;

public class BloodStock
{
    public BloodStock(Guid id, BloodType bloodType, RhFactor rhFactor, int quantityMl)
    {
        BloodType = bloodType;
        RhFactor = rhFactor;
        QuantityMl = quantityMl;
    }

    public Guid Id { get; set; }
    public BloodType BloodType { get; set; }
    public RhFactor RhFactor { get; set; }
    public int QuantityMl { get; set; }

}
