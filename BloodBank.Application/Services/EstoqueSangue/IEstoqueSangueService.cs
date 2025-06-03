using BloodBank.Application.Models;
using BloodBank.Application.Models.EstoqueSangueModels;
using BloodBank.Core.Entities;

namespace BloodBank.Application.Services;

public interface IEstoqueSangueService
{

        Task <ResultViewModel<List<EstoqueSangueViewModel>>> GetAll();
        Task<ResultViewModel> AddEstoque(Doacao doacaoSangue, string tipoSanguineo, string fatorRH);
}