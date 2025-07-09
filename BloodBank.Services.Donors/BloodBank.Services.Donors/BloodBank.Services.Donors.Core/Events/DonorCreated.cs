namespace BloodBank.Services.Donors.Core.Events;

public class DonorCreated : IDomainEvent
{
    public Guid Id { get; set; }
    public string Fullname { get; set; }
    public string Email { get; set; }
}