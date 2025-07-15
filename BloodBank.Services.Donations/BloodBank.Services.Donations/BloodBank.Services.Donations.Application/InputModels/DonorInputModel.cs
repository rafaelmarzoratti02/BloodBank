using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Services.Donations.Application.InputModels;

public class DonorInputModel
{
    public string FullName { get; private set; }
    public string Email { get; private set; }
}
