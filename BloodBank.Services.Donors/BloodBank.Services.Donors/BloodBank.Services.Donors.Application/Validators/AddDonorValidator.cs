using BloodBank.Services.Donors.Application.Commands;
using FluentValidation;

namespace BloodBank.Services.Donors.Application.Validators;

public class AddDonorValidator : AbstractValidator<AddDonor>
{
    public AddDonorValidator()
    {
        RuleFor(x => x.Weight)
            .GreaterThan(50)
            .WithMessage("Weight must be greater than 50");
        
        RuleFor(x=> x.Birthdate)
            .Must(BeAtLeast18YearsOld)
            .WithMessage("Donor must be at least 18 years old");
        
    }
    
    private bool BeAtLeast18YearsOld(DateTime birthdate)
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