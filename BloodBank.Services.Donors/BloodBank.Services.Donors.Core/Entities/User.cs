using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodBank.Services.Donors.Core.Enums;

namespace BloodBank.Services.Donors.Core.Entities;

public class User : BaseEntity
{

    public User(string email, string password, string name, UserType type):base()
    {
        Email = email;
        Password = password;
        Name = name;
        Type = type;
    }

    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public UserType Type { get; set; } 
}
