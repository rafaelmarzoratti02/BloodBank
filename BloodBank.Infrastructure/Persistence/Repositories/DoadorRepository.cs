using BloodBank.Core.Entities;
using BloodBank.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Infrastructure.Persistence.Repositories;

public class DoadorRepository : IDoadorRepository
{
    
    private readonly BloodBankDbContext _context;

    public DoadorRepository(BloodBankDbContext context)
    {
        _context = context;
    }

    public  Task<List<Doador>> GetAll()
    {
        var doadores =  _context.Doadores.Where(d=> !d.IsDeleted).ToListAsync();
        return doadores;
    }

    public async Task<int> Add(Doador doador)
    {
        await _context.Doadores.AddAsync(doador);
        return doador.Id;
    }
    

    public async Task<Doador> GetById(int id)
    {
       var doador = await _context.Doadores.SingleOrDefaultAsync(d => d.Id == id);
       return doador;
    }

    public Task Update(Doador doador)
    {
        throw new NotImplementedException();
    }
}