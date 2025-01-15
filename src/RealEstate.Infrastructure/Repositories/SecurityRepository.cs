using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Common.Interfaces;
using RealEstate.Domain.Entities.Security.Jwt;
using RealEstate.Infrastructure.Data;

namespace RealEstate.Infrastructure.Repositories;

public class SecurityRepository(ApiDbContext context) : ISecurityRepository
{
    private readonly ApiDbContext _context = context;

    public async Task<User?> GetUserAsync(User userCredentials, CancellationToken cancellationToken)
    {
        return await _context.TokenUser
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Username == userCredentials.Username, cancellationToken);
    }

    public async Task AddUserAsync(User user, CancellationToken cancellationToken)
    {
        await _context.TokenUser.AddAsync(user, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}