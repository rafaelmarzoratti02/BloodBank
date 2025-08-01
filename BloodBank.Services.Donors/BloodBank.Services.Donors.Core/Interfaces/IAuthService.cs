using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBank.Services.Donors.Core.Interfaces;

public interface IAuthService
{
    string GenerateJWTToken(string email, string role);

    string ComputeSha256Hash(string password);
}
