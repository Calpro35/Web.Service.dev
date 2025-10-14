using Microsoft.EntityFrameworkCore;
using Web.Service.Cap7.Data.Context;
using Web.Service.Cap7.Interfaces;
using Web.Service.Cap7.Models;

namespace Web.Service.Cap7.Data.Repositories;

public class UserRepository(AppDbContext context) : Repository<User>(context), IUserRepository
{
    private readonly AppDbContext _context = context;

    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email.Equals(email), cancellationToken);
    }
}
