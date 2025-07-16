using BloodBank.Services.Donations.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Services.Donations.Application.Queries.GetDonationById;

public class GetDonationById : IRequest<ResultViewModel<DonationViewModel>>
{
    public GetDonationById(Guid id)
    {
        Id = id;

    }
    public Guid Id { get; set; }

}

