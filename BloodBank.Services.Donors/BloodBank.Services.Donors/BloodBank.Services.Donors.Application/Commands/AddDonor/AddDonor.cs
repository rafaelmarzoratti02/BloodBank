using BloodBank.Services.Donors.Application.InputModels;
using BloodBank.Services.Donors.Core;
using BloodBank.Services.Donors.Core.Enums;
using BloodBank.Services.Donors.Core.ValueObjects;
using MediatR;

namespace BloodBank.Services.Donors.Application.Commands;

public class AddDonor :IRequest<Guid>
{
    public AddDonor(string fullname, string email, DateTime birthdate, double weight, int bloodtype,
        int rhFactor, AddressInputModel address): base()
    {
        Fullname = fullname;
        Email = email;
        Birthdate = birthdate;
        Weight = weight;
        BloodType = bloodtype;
        RhFactor = rhFactor;
        Address = address;
    }
    
    public string Fullname { get; set; }
    public string Email { get; set; }
    public DateTime Birthdate { get; set; }
    public double Weight { get; set; }
    public int BloodType { get; set; }
    public int RhFactor { get; set; }
    public AddressInputModel Address { get; set; }

    public Donor ToEntity()
    {
        return new Donor(Fullname, Email, Birthdate, Weight, (BloodType)BloodType, (RhFactor)RhFactor,
            new Address(Address.Street, Address.Number, Address.City, Address.State, Address.ZipCode)
        );
    }

}