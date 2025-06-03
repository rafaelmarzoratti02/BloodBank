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

    public async  Task<List<EstoqueSangueViewModel>> GetAll()
    {
        var result = await _repository.GetAll();
        
        var model = result.Select(x=> EstoqueSangueViewModel.FromEntity(x)).ToList();
        
        return model;
    }

    public Task AddEstoque(Doacao doacaoSangue)
    {
        throw new NotImplementedException();
    }
    
}