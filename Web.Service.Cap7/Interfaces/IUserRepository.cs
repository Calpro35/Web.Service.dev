using Web.Service.Cap7.Models;

namespace Web.Service.Cap7.Interfaces;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken);
}
