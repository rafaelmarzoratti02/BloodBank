using BloodBank.Services.Donations.Application.InputModels;
using BloodBank.Services.Donations.Application.ViewModels;
using BloodBank.Services.Donations.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Services.Donations.Application.Commands.AddDonation;

public class AddDonation : IRequest<ResultViewModel<Guid>>
{
    public AddDonation(Guid donorId, DateTime donationDate, int quantityMl)
    {
        DonorId = donorId;
        DonationDate = donationDate;
        QuantityMl = quantityMl;

    }

    public Guid DonorId { get; set; }
    public DateTime DonationDate { get; set; }
    public int QuantityMl { get; set; }

    public Donation ToEntity()
    {
        return new Donation(
            DonorId,
            DonationDate,
            QuantityMl
        );
    }
}
