using BloodBank.Services.Donations.Application.Commands.AddDonation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Services.Donations.Application.Validators;

public class AddDonationValidator : AbstractValidator<AddDonation>
{
    public AddDonationValidator()
    {
        RuleFor(x => x.QuantityMl)
            .InclusiveBetween(420, 470);
    }
}
