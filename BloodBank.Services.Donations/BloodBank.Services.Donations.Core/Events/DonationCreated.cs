using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Services.Donations.Core.Events;

public class DonationCreated :IDomainEvent
{
   public DonationCreated(Guid id)
    {
        Id = id;

    }

    public Guid Id { get; set; }
}

