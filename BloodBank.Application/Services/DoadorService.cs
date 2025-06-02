using BloodBank.Application.Models;
using BloodBank.Application.Models.DoadorModels;
using BloodBank.Core.Entities;
using BloodBank.Core.Repositories;

namespace BloodBank.Application.Services;

public class DoadorService : IDoadorService
{
    private readonly IDoadorRepository  _doadorRepository;

    public DoadorService(IDoadorRepository doadorRepository)
    {
        _doadorRepository = doadorRepository;
    }

    public async Task<ResultViewModel<List<DoadorItemViewModel>>> GetAllDoadores()
    {
       var doadores = await _doadorRepository.GetAll();
       var model =  doadores.Select(e=> DoadorItemViewModel.FromEntity(e)).ToList();
       return ResultViewModel<List<DoadorItemViewModel>>.Sucess(model);
    }

    public Task<int> AddDoador(Doador doadorDto)
    {
        throw new NotImplementedException();
    }
}