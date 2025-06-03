using BloodBank.Core.Entities;

namespace BloodBank.Core.Repositories;

public interface IEstoqueSangueRepository
{

    Task<List<EstoqueSangue>> GetAll();
    Task<EstoqueSangue> GetByTipoAndRH(string  tipoSanguineo, string fatorRH);

    Task Update(EstoqueSangue doacaoSangue);
}