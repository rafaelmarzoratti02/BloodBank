using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Services.Donations.Core.Events;

public class DonationCreated :IDomainEvent
{
   public DonationCreated(Guid id, string fullname)
    {
        Id = id;
        DonorFullname = fullname;

    }

    public Guid Id { get; set; }
    public string DonorFullname { get; set; }
}

