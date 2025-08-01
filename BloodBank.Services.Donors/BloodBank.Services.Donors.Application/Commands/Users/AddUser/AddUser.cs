using BloodBank.Services.Donors.Application.InputModels;
using BloodBank.Services.Donors.Application.ViewModels;
using BloodBank.Services.Donors.Core;
using BloodBank.Services.Donors.Core.Entities;
using BloodBank.Services.Donors.Core.Enums;
using BloodBank.Services.Donors.Core.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Services.Donors.Application.Commands.Users.AddUser;

public class AddUser : IRequest<ResultViewModel<Guid>>
{

    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public int Type { get; set; }


    public User ToEntity(string password)
    {
        return new User(Email, password, Name, (UserType)Type);
    }
}
