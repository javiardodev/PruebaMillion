using RealEstate.Application.Dtos.PropertyImage;

namespace RealEstate.Application.Common.Interfaces;

public interface IPropertyImageService
{
    Task<int> UploadPropertyImage(ImagePropertyIn request, CancellationToken cancellationToken);
}