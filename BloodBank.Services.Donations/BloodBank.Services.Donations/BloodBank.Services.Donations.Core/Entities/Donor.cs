using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Services.Donations.Core.Entities;

public class Donor : BaseEntity
{
    public Donor(string fullName)
    {
        FullName = fullName;
    }

    public string FullName { get; private set; }
}
