using RealEstate.Api.Dtos.Owner;
using RealEstate.Api.Dtos.Security;
using RealEstate.Application.Dtos.Owners;
using RealEstate.Application.Dtos.Security;
using RealEstate.CrossCutting.Common;

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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public static OwnerFilterDto MapToFiltersIn(this OwnerFilterRequest request)
    {
        return new()
        {
            Name = request.Name,
            Address = request.Address
        };
    }
}