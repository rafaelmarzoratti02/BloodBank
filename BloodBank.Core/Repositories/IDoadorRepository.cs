using BloodBank.Core.Entities;

namespace BloodBank.Core.Repositories;

public interface IDoadorRepository 
{
     Task<List<Doador>> GetAll();
     Task<int> Add(Doador doador);
     Task<Doador> GetById(int id);
     Task Update(Doador doador);
}