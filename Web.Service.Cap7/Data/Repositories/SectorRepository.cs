using Microsoft.EntityFrameworkCore;
using Web.Service.Cap7.Data.Context;
using Web.Service.Cap7.Interfaces;
using Web.Service.Cap7.Models;

namespace Web.Service.Cap7.Data.Repositories;

public class SectorRepository(AppDbContext context) : Repository<Sector>(context), ISectorRepository
{
    private readonly AppDbContext _context = context;

    public async Task<IEnumerable<Sector>> GetAllAsync(int userId, CancellationToken cancellationToken)
    {
        return await _context.Sectors
            .Where(x => x.UserId.Equals(userId))
            .ToListAsync(cancellationToken);
    }

    public async Task<Sector?> GetAsync(int sectorId, int userId, CancellationToken cancellationToken)
    {
        return await _context.Sectors
            .Include(x => x.Equipments)
            .Where(s => s.Id.Equals(sectorId) && s.UserId.Equals(userId))
            .FirstOrDefaultAsync(cancellationToken);
    }
}
