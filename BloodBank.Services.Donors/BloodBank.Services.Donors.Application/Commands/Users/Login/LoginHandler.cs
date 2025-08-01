using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodBank.Services.Donors.Application.ViewModels;
using BloodBank.Services.Donors.Core.Interfaces;
using BloodBank.Services.Donors.Core.Repositories;
using MediatR;

namespace BloodBank.Services.Donors.Application.Commands.Users.Login;

public class LoginHandler : IRequestHandler<LoginCommand, ResultViewModel<LoginUserViewModel>>
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;

    public LoginHandler(IUserRepository donorRepository, IAuthService authService)
    {
        _userRepository = donorRepository;
        _authService = authService;
    }

    public async Task<ResultViewModel<LoginUserViewModel>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var passworhHash = _authService.ComputeSha256Hash(request.Password);
        var user = await _userRepository.GetUserByEmailAndPasswordAsync(request.Email, passworhHash);

        if (user is null)
        {
            return ResultViewModel<LoginUserViewModel>.Error("Usuário ou senha inválidos!");
        }
        var token = _authService.GenerateJWTToken(user.Email, user.Type.ToString());

        var model = new LoginUserViewModel(user.Email, token);

        return ResultViewModel<LoginUserViewModel>.Sucess(model);
    }
}
