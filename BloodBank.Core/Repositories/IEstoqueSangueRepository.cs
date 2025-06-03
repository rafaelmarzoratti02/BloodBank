using BloodBank.Core.Entities;

namespace BloodBank.Core.Repositories;

public interface IEstoqueSangueRepository
{
    Task<List<EstoqueSangue>> GetAll();
    Task Update(EstoqueSangue doacaoSangue);
    Task<bool> Exists(int id);
}