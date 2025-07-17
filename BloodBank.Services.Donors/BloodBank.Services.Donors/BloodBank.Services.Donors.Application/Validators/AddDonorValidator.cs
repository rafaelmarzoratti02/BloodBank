using BloodBank.Services.Donors.Application.Commands;
using BloodBank.Services.Donors.Core.Repositories;
using FluentValidation;

namespace BloodBank.Services.Donors.Application.Validators;

public class AddDonorValidator : AbstractValidator<AddDonor>
{
    public AddDonorValidator()
    {
        RuleFor(x => x.Weight)
            .GreaterThan(50)
            .WithMessage("Weight must be greater than 50");

        RuleFor(x => x.Birthdate)
            .Must(Utils.BeAtLeast18YearsOld)
            .WithMessage("Donor must be at least 18 years old");
    }

}