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
        var donor = new Donor("Teste douglas", "teste@email.com", new DateTime(2002, 7, 17, 14, 30, 0), Gender.Male, 76, BloodType.A, RhFactor.Negative, new Address("Rua Caralinhos", "10", "Poa", "RS", "918827"),"123");

        Assert.True(donor.IsDeleted == false);
        Assert.False(donor.IsDeleted);
    }

    [Fact]
    public void DonorShouldBeAtLeast18YearsOld()
    {
        var donor = new Donor("Teste douglas", "teste@email.com", new DateTime(2002, 7, 17, 14, 30, 0), Gender.Male, 76, BloodType.A, RhFactor.Negative, new Address("Rua Caralinhos", "10", "Poa", "RS", "918827"),"123");

        Assert.True(Utils.BeAtLeast18YearsOld(donor.Birthdate));
        Assert.False(!Utils.BeAtLeast18YearsOld(donor.Birthdate));
    }

    [Fact]
    public void DonorShouldNotAppearAfterSetAsDeleted()
    {
        var donors = new List<Donor>
        {
            new Donor("Alice", "alice@email.com", new DateTime(1990, 1, 1), Gender.Female, 60, BloodType.O, RhFactor.Positive, new Address("Street 1", "1", "CityA", "ST", "00001"),"123"),
            new Donor("Bob", "bob@email.com", new DateTime(1985, 5, 5), Gender.Male, 80, BloodType.B, RhFactor.Negative, new Address("Street 2", "2", "CityB", "ST", "00002"),"123")
        };

        var donorToDelete = new Donor("Teste douglas", "teste@email.com", new DateTime(2002, 7, 17, 14, 30, 0), Gender.Male, 76, BloodType.A, RhFactor.Negative, new Address("Rua Caralinhos", "10", "Poa", "RS", "918827"), "123");

        donorToDelete.SetAsDeleted(); 
        donors.Add(donorToDelete);

        var activeDonors = donors.Where(d => !d.IsDeleted).ToList();

        Assert.DoesNotContain(donorToDelete, activeDonors);
    }
}