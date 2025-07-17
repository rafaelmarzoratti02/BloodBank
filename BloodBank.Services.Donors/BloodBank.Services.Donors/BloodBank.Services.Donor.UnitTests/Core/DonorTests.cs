using BloodBank.Services.Donors.Application;
using BloodBank.Services.Donors.Core;
using BloodBank.Services.Donors.Core.Enums;
using BloodBank.Services.Donors.Core.ValueObjects;

namespace BloodBank.Services.Donors.UnitTests.Core;

public class DonorTests
{
    [Fact]
    public void DonorIsCreated()
    {
        var donor = new Donor("Teste douglas", "teste@email.com", new DateTime(2002, 7, 17, 14, 30, 0), Gender.Male, 76, BloodType.A, RhFactor.Negative, new Address("Rua Caralinhos", "10", "Poa", "RS", "918827"));



        Assert.True(donor.IsDeleted == false);
        Assert.False(donor.IsDeleted);
    }

    [Fact]
    public void DonorShouldBeAtLeast18YearsOld()
    {
        var donor = new Donor("Teste douglas", "teste@email.com", new DateTime(2002, 7, 17, 14, 30, 0), Gender.Male, 76, BloodType.A, RhFactor.Negative, new Address("Rua Caralinhos", "10", "Poa", "RS", "918827"));

        Assert.True(Utils.BeAtLeast18YearsOld(donor.Birthdate));
        Assert.False(!Utils.BeAtLeast18YearsOld(donor.Birthdate));

    }
}