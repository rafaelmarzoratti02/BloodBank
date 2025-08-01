using BloodBank.Services.Donations.Core.Entities;
using BloodBank.Services.Donations.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Services.Donations.Application.ViewModels;

public class DonationViewModel
{
    public DonationViewModel(Guid id,Guid donorId, DateTime donationDate, int quantityMl)
    {
        Id = id;
        DonorId = donorId;
        DonationDate = donationDate;
        QuantityMl = quantityMl;
    }

    public Guid Id { get; set; }
    public Guid DonorId { get; set; }
    public DateTime DonationDate { get; set; }
    public int QuantityMl { get; set; }

    public static DonationViewModel FromEntity(Donation donation)
    {
        return new DonationViewModel(donation.Id,donation.DonorId, donation.DonationDate, donation.QuantityMl);
    }

}
