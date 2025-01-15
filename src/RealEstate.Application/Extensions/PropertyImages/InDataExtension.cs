using RealEstate.Application.Dtos.PropertyImage;
using RealEstate.Domain.Entities.Controller;

namespace RealEstate.Application.Extensions.PropertyImages;

public static class InDataExtension
{
    public static PropertyImage MapToEntity(this ImagePropertyIn request)
    {
        return new()
        {
            File = request.File,
            Enabled = request.Enabled
        };
    }
}