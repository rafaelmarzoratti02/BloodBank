using BloodBank.Services.Donors.Application.ViewModels;
using BloodBank.Services.Donors.Core.Repositories;
using MediatR;

namespace BloodBank.Services.Donors.Application.Commands;

public class AddDonorHandler : IRequestHandler<AddDonor, ResultViewModel<Guid>>
{
    private readonly IDonorRepository  _donorRepository;
    private readonly IUserRepository _userRepository;


    public AddDonorHandler(IDonorRepository donorRepository, IUserRepository userRepository)
    {
        _donorRepository = donorRepository;
        _userRepository = userRepository;
    }

    public async Task<ResultViewModel<Guid>> Handle(AddDonor request, CancellationToken cancellationToken)
    {
        var donor = request.ToEntity();
        var userExists = await _userRepository.UserExistsAsync(donor.UserId);
        var emailExists = await _donorRepository.EmailExistsAsync(donor.Email);

        if (!userExists) return ResultViewModel<Guid>.Error("User not found.");
        if (emailExists) return ResultViewModel<Guid>.Error("Email is already registered.");

        await _donorRepository.AddAsync(donor);
        
        foreach(var @event in donor.Events)
        {
            Console.WriteLine(@event.GetType().Name.ToDashCase());
        }
        
        return ResultViewModel<Guid>.Sucess(donor.Id);
    }
}