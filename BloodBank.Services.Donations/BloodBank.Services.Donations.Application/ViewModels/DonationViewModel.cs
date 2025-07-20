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
    public DonationViewModel(Guid donorId, DateTime donationDate, int quantityMl, string donor)
    {
        DonorId = donorId;
        DonationDate = donationDate;
        QuantityMl = quantityMl;
        DonorFullname = donor;
    }

    public Guid DonorId { get; set; }
    public DateTime DonationDate { get; set; }
    public int QuantityMl { get; set; }
    public string DonorFullname { get; set; }

    public static DonationViewModel FromEntity(Donation donation)
    {
        return new DonationViewModel(donation.Id, donation.DonationDate, donation.QuantityMl, donation.Donor.FullName);
    }

}
