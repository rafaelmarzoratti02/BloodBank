using BloodBank.Core.Entities;

namespace BloodBank.Core.Repositories;

public interface IEnderecoRepository
{
    Task<List<Endereco>> GetAll();
    Task<int> Add(Endereco endereco);
    Task<Endereco> GetById(int id);
    Task Update(Endereco endereco);
}