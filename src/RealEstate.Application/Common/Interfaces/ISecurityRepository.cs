using RealEstate.Domain.Entities.Security.Jwt;

namespace RealEstate.Application.Common.Interfaces;

public interface ISecurityRepository
{
    Task<User?> GetUserAsync(User userCredentials, CancellationToken cancellationToken);
    Task AddUserAsync(User user, CancellationToken cancellationToken);
}