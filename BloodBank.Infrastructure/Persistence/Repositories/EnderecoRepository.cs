using BloodBank.Core.Entities;
using BloodBank.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Infrastructure.Persistence.Repositories;

public class EnderecoRepository : IEnderecoRepository
{
    
    private readonly BloodBankDbContext _context;

    public EnderecoRepository(BloodBankDbContext context)
    {
        _context = context;
    }

    public  async Task<List<Endereco>> GetAll()
    {
        var enderecos = await _context.Endereco.Where(e=> !e.IsDeleted).ToListAsync();
        return enderecos;
    }

    public async Task<int> Add(Endereco endereco)
    {
        await _context.Endereco.AddAsync(endereco);
        return endereco.Id;
    }

    public Task<Endereco> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Update(Endereco endereco)
    {
        throw new NotImplementedException();
    }
}