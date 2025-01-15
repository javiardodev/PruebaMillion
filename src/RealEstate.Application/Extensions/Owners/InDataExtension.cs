using RealEstate.Application.Dtos.Owners;
using RealEstate.Domain.Entities.Controller;

namespace RealEstate.Application.Extensions.Owners;

public static class InDataExtension
{
    public static Owner MapToEntity(this OwnerRegistryIn registry)
    {
        return new()
        {
            Name = registry.Name,
            Address = registry.Address,
            Birthday = registry.Birthday,
            Photo = registry.Photo
        };
    }
}