using BloodBank.Core.Entities;
using BloodBank.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Infrastructure.Persistence.Repositories;

public class EstoqueSangueRepository : IEstoqueSangueRepository
{
    
    private readonly BloodBankDbContext _context;

    public EstoqueSangueRepository(BloodBankDbContext context)
    {
        _context = context;
    }

    public async  Task<List<EstoqueSangue>> GetAll()
    {
        var result =  await _context.EstoqueSange.Where(d=> !d.IsDeleted).ToListAsync();
        
        return result;
    }

    public async Task<EstoqueSangue> GetByTipoAndRH(string tipoSanguineo, string fatorRH)
    {
        var result = await _context.EstoqueSange.SingleOrDefaultAsync(e=> e.TipoSanguineo == tipoSanguineo && e.FatorRh   == fatorRH);
        
        return result;
    }

    public async Task Update(EstoqueSangue doacaoSangue)
    {
        _context.Update(doacaoSangue);
        await _context.SaveChangesAsync();
    }
    
}