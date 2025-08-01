using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodBank.Services.Donors.Application.ViewModels;
using MediatR;

namespace BloodBank.Services.Donors.Application.Commands.Users.Login;

public class LoginCommand : IRequest<ResultViewModel<LoginUserViewModel>>
{
    public LoginCommand(string email, string password)
    {
        Email = email;
        Password = password;
    }

    public string Email { get; set; }
    public string Password { get; set; }
}
