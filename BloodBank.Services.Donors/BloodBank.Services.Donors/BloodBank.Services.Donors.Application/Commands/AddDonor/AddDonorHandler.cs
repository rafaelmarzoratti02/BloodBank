using BloodBank.Services.Donors.Application.ViewModels;
using BloodBank.Services.Donors.Core.Repositories;
using MediatR;

namespace BloodBank.Services.Donors.Application.Commands;

public class AddDonorHandler : IRequestHandler<AddDonor, ResultViewModel<Guid>>
{
    private readonly IDonorRepository  _donorRepository;

    public AddDonorHandler(IDonorRepository donorRepository)
    {
        _donorRepository = donorRepository;
    }

    public async Task<ResultViewModel<Guid>> Handle(AddDonor request, CancellationToken cancellationToken)
    {
        var donor = request.ToEntity();
        
        var emailExists = await _donorRepository.EmailExistsAsync(donor.Email);
        if (emailExists) return ResultViewModel<Guid>.Error("Email is already registered.");
        
        await _donorRepository.AddAsync(donor);
        
        foreach(var @event in donor.Events)
        {
            Console.WriteLine(@event.GetType().Name.ToDashCase());
        }
        
        return ResultViewModel<Guid>.Sucess(donor.Id);
    }
}