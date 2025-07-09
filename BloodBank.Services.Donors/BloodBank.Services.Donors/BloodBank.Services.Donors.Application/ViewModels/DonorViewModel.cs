using BloodBank.Services.Donors.Application.InputModels;
using BloodBank.Services.Donors.Core;
using BloodBank.Services.Donors.Core.Enums;

namespace BloodBank.Services.Donors.Application.ViewModels;

public class DonorViewModel
{
    public DonorViewModel(string fullname,string email, BloodType bloodType, RhFactor rhFactor)
    {
        Fullname = fullname;
        Email = email;
        BloodType = bloodType.ToString();
        RhFactor = rhFactor.ToString();
    }

    public string Fullname { get; set; }
    public string Email { get; set; }
    public string BloodType { get; set; } 
    public string RhFactor { get; set; } 
    
    public static DonorViewModel FromEntity(Donor donor) {
        return new DonorViewModel(donor.Fullname, donor.Email, donor.BloodType, donor.RhFactor);
    }

}