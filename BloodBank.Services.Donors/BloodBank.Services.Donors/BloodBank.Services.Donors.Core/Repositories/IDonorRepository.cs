namespace BloodBank.Services.Donors.Core.Repositories;

public interface IDonorRepository
{
    Task<Donor> GetByIdAsync(Guid id);
    Task AddAsync(Donor donor);
    Task UpdateAsync(Donor donor);
}