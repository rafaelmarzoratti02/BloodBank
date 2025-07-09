using BloodBank.Services.Donors.Core.Repositories;
using MediatR;

namespace BloodBank.Services.Donors.Application.Commands;

public class AddDonorHandler : IRequestHandler<AddDonor, Guid>
{
    private readonly IDonorRepository  _donorRepository;

    public AddDonorHandler(IDonorRepository donorRepository)
    {
        _donorRepository = donorRepository;
    }

    public async Task<Guid> Handle(AddDonor request, CancellationToken cancellationToken)
    {
        var donor = request.ToEntity();
        
        await _donorRepository.AddAsync(donor);
        
        foreach(var @event in donor.Events)
        {
            Console.WriteLine(@event.GetType().Name.ToDashCase());
        }
        
        return donor.Id;
    }
}