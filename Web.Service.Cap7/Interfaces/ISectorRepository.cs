using Web.Service.Cap7.Models;

namespace Web.Service.Cap7.Interfaces;

public interface ISectorRepository : IRepository<Sector>
{
    Task<Sector?> GetAsync(int sectorId, int userId, CancellationToken cancellationToken);
    Task<IEnumerable<Sector>> GetAllAsync(int userId, CancellationToken cancellationToken);
}
