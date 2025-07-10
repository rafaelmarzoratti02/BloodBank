using BloodBank.Services.Donors.Application.ViewModels;
using BloodBank.Services.Donors.Core.Repositories;
using MediatR;

namespace BloodBank.Services.Donors.Application.Queries.Donor;

public class GetDonorByIdHandler : IRequestHandler<GetDonorById, ResultViewModel<DonorViewModel>>
{
    private readonly IDonorRepository _donorRepository;

    public GetDonorByIdHandler(IDonorRepository donorRepository)
    {
        _donorRepository = donorRepository;
    }

    public async Task<ResultViewModel<DonorViewModel>> Handle(GetDonorById request, CancellationToken cancellationToken)
    {
        var result = await _donorRepository.GetByIdAsync(request.Guid);
        if(result is null) return ResultViewModel<DonorViewModel>.Error("Donor not found");
        
        var model = DonorViewModel.FromEntity(result);
        
        return ResultViewModel<DonorViewModel>.Sucess(model);
    }
}