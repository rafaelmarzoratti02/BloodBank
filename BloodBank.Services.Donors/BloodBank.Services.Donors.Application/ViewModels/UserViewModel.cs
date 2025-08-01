using BloodBank.Services.Donors.Core;
using BloodBank.Services.Donors.Core.Entities;
using BloodBank.Services.Donors.Core.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BloodBank.Services.Donors.Application.ViewModels;

public class UserViewModel
{
    public UserViewModel(Guid id,string email, string name, UserType type)
    {
        Id = id;
        Email = email;
        Name = name;    
        Type = type.ToString();

    }

    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }

    public static UserViewModel FromEntity(User user)
    {
        return new UserViewModel(user.Id, user.Email, user.Name, user.Type);
    }
}
