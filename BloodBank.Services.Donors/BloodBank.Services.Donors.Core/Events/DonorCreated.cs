namespace BloodBank.Services.Donors.Core.Events;

public class DonorCreated : IDomainEvent
{
    public DonorCreated(Guid id, string fullname, string email)
    {
        Id = id;
        Fullname = fullname;
        Email = email;
    }

    public Guid Id { get; set; }
    public string Fullname { get; set; }
    public string Email { get; set; }
}