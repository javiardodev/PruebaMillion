using RealEstate.Application.Dtos.Security;

namespace RealEstate.Application.Common.Interfaces;

public interface ISecurityService
{
    Task<CredentialsOut> ValidateUser(CredentialsIn userCredentials, CancellationToken cancellationToken);

    Task<CredentialsOut> CreateUser(CredentialsIn userCredentials, CancellationToken cancellationToken);
}