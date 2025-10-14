using Web.Service.Cap7.Data.Context;
using Web.Service.Cap7.Interfaces;

namespace Web.Service.Cap7.Data.Repositories;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    private readonly AppDbContext _context = context;

    public async Task CommitAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}
