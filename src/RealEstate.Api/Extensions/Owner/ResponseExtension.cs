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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="list"></param>
    /// <returns></returns>
    public static OwnerListResponse MapToResponse(this OwnerListOut list)
    {
        return new()
        {
            ListOwners = list.ListOwners.Select(x => new OwnerDto
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                Photo = x.Photo,
                Birthday = x.Birthday
            }).ToList(),
            Message = list.Message,
            Result = list.Result,
            StatusCode = list.StatusCode
        };
    }
}