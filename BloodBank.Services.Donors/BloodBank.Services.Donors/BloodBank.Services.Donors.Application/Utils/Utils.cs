using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Services.Donors.Application;

public static class Utils
{
    public static bool BeAtLeast18YearsOld(DateTime birthdate)
    {
        var today = DateTime.Today;
        var age = today.Year - birthdate.Year;

        if (birthdate.Date > today.AddYears(-age))
        {
            age--;
        }

        return age >= 18;
    }


}