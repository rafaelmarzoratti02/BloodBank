using BloodBank.Services.Donations.Application.ViewModels;
using BloodBank.Services.Donations.Core.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Services.Donations.Application.Queries.GetDonationById;

public class GetDonationByIdHandler : IRequestHandler<GetDonationById, ResultViewModel<DonationViewModel>>
{

    private readonly IDonationRepository _repository;

    public GetDonationByIdHandler(IDonationRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel<DonationViewModel>> Handle(GetDonationById request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetByDonorId(request.Id);

        if(result is null) return ResultViewModel<DonationViewModel>.Error("Donation not found");

        var model = DonationViewModel.FromEntity(result);

        return ResultViewModel<DonationViewModel>.Sucess(model);
    }
}
