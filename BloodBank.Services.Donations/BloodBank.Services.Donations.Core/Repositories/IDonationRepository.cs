using BloodBank.Services.Donations.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Services.Donations.Core.Repositories;

public interface IDonationRepository
{
    Task<Donation> GetByDonorId(Guid donorId);
    Task Add(Donation donation);
    Task <List<Donation>> Get();
}
