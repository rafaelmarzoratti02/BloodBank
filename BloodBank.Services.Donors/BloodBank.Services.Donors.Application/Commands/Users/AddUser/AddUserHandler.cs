using BloodBank.Services.Donors.Application.ViewModels;
using BloodBank.Services.Donors.Core.Interfaces;
using BloodBank.Services.Donors.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Services.Donors.Application.Commands.Users.AddUser;

public class AddUserHandler : IRequestHandler<AddUser, ResultViewModel<Guid>>
{

    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;

    public AddUserHandler(IUserRepository userRepository, IAuthService authService)
    {
        _userRepository = userRepository;
        _authService = authService;
    }

    public async  Task<ResultViewModel<Guid>> Handle(AddUser request, CancellationToken cancellationToken)
    {
        var senhaHash = _authService.ComputeSha256Hash(request.Password);
        var user = request.ToEntity(senhaHash);
        var result = await _userRepository.AddAsync(user);

        return ResultViewModel<Guid>.Sucess(result);
    }
}
