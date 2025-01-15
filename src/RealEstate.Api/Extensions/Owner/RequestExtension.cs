using RealEstate.Api.Dtos.Owner;
using RealEstate.Application.Dtos.Owners;

namespace RealEstate.Api.Extensions.Owner;

/// <summary>
/// 
/// </summary>
public static class RequestExtension
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public static OwnerRegistryIn MapToRegistryIn(this OwnerRequest request)
    {
        return new()
        {
            Name = request.Name,
            Address = request.Address,
            Birthday = request.Birthday,
            Photo = request.Photo
        };
    }
}