using BloodBank.Services.Donations.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Services.Donations.Core.Repositories;

public interface IDonationRepository
{
    Task<List<Donation>> GetByDonorIdAsync(int donorId);
    Task AddAsync(Donation donation);
    Task <List<Donation>> GetAsync();
}
