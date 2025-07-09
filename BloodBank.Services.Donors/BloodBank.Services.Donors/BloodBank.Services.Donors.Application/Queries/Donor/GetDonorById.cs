using BloodBank.Services.Donors.Application.ViewModels;
using MediatR;

namespace BloodBank.Services.Donors.Application.Queries.Donor;

public class GetDonorById : IRequest<DonorViewModel>
{
    public GetDonorById(Guid guid)
    {
        Guid = guid;
    }

    public Guid Guid { get; set; }
}