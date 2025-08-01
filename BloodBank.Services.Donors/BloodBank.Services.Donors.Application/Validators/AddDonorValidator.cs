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

        RuleFor(x => x.Email)
            .EmailAddress()
            .WithMessage("Invalid email format");

        RuleFor(x => x.Address.ZipCode)
            .Length(8)
            .WithMessage("Zipcode must be 8 characters long");
    }
}