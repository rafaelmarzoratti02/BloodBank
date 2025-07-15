using BloodBank.Services.Donations.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Services.Donations.Core.Entities;

public class Donation : AggregateRoot
{
    public Donation(int donorId, DateTime donationDate, int quantityMl, Donor donor)
    {
        Id = Guid.NewGuid();
        DonorId = donorId;
        DonationDate = donationDate;
        QuantityMl = quantityMl;
        Donor = donor;
        AddEvent(new DonationCreated(Id, donor.FullName));
    }

    public int DonorId { get; set; }
     public DateTime DonationDate { get; set; }
    public int QuantityMl { get; set; }
    public Donor Donor { get; set; }
}
