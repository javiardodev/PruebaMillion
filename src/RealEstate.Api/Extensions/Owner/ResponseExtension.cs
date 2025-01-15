using RealEstate.Api.Dtos.Owner;
using RealEstate.Application.Dtos.Owners;

namespace RealEstate.Api.Extensions.Owner;

/// <summary>
/// 
/// </summary>
public static class ResponseExtension
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="registry"></param>
    /// <returns></returns>
    public static OwnerResponse MapToResponse(this OwnerRegistryOut registry)
    {
        return new()
        {
            Id = registry.Id,
            Message = registry.Message,
            Result = registry.Result,
            StatusCode = registry.StatusCode
        };
    }
}