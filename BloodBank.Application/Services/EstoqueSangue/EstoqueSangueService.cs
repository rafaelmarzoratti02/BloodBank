using BloodBank.Application.Models;
using BloodBank.Application.Models.EstoqueSangueModels;
using BloodBank.Core.Entities;
using BloodBank.Core.Repositories;

namespace BloodBank.Application.Services;

public class EstoqueSangueService : IEstoqueSangueService
{
    
    private readonly IEstoqueSangueRepository _repository;

    public EstoqueSangueService(IEstoqueSangueRepository repository)
    {
        _repository = repository;
    }

    public async  Task<ResultViewModel<List<EstoqueSangueViewModel>>> GetAll()
    {
        var result = await _repository.GetAll();
        
        var model = result.Select(x=> EstoqueSangueViewModel.FromEntity(x)).ToList();
        return ResultViewModel<List<EstoqueSangueViewModel>>.Sucess(model);
    }

    public async Task<ResultViewModel> AddEstoque(Doacao doacaoSangue, string tipoSanguineo, string fatorRH)
    {
        var estoque = await _repository.GetByTipoAndRH(tipoSanguineo, fatorRH);
        if (estoque is null)
        {
            return ResultViewModel.Error("Nenhum estoque encontrado");
        }
        estoque.QuantidadeML += doacaoSangue.QuantidadeML;
        await _repository.Update(estoque);
        return ResultViewModel.Sucess("Quantidade adicionada ao estoque");
    }
    
}