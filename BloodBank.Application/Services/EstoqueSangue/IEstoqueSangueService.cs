using BloodBank.Application.Models.EstoqueSangueModels;
using BloodBank.Core.Entities;

namespace BloodBank.Application.Services;

public interface IEstoqueSangueService
{

        Task <EstoqueSangueViewModel> GetAll();
        Task  AdicionaEstoque(Doacao doacaoSangue);

}