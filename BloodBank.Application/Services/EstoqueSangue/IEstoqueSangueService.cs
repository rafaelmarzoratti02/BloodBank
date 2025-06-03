using BloodBank.Application.Models.EstoqueSangueModels;
using BloodBank.Core.Entities;

namespace BloodBank.Application.Services;

public interface IEstoqueSangueService
{

        Task <List<EstoqueSangueViewModel>> GetAll();
        Task  AddEstoque(Doacao doacaoSangue);
}