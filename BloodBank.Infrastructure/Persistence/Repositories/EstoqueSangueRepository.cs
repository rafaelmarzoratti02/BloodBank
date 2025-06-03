using BloodBank.Core.Entities;
using BloodBank.Core.Repositories;

namespace BloodBank.Infrastructure.Persistence.Repositories;

public class EstoqueSangueRepository : IEstoqueSangueRepository
{
    
    private readonly BloodBankDbContext _context;

    public EstoqueSangueRepository(BloodBankDbContext context)
    {
        _context = context;
    }

    public Task<List<EstoqueSangue>> GetAll()
    {
       var  result = await _context.EstoqueSangues.
    }

    public Task Update(EstoqueSangue doacaoSangue)
    {
        throw new NotImplementedException();
    }
}