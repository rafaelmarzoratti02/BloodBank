namespace BloodBank.Services.Donors.Core;

public class BaseEntity
{
    public BaseEntity()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
        IsDeleted = false;
    }

    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsDeleted { get; set; }

    public void SetAsDeleted()
    {
        IsDeleted = true;
    }
}
