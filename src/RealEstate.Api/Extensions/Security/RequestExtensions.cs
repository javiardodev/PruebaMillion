using RealEstate.Api.Dtos.Security;
using RealEstate.Application.Dtos.Security;

namespace RealEstate.Api.Extensions.Security;

/// <summary>
/// Implementation for Map DTOs Request in SecurityController
/// </summary>
public static class RequestExtensions
{
    /// <summary>
    /// Function configuring for MapTo
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public static CredentialsIn MapToCredentialsIn(this CredentialsRequest request)
    {
        return new()
        {
            Username = request.Username,
            Password = request.Password
        };
    }
}
