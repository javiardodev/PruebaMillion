using RealEstate.Application.Common.Interfaces;
using RealEstate.Application.Dtos.PropertyImage;
using RealEstate.Domain.Entities.Controller;

namespace RealEstate.Application.Services;

public class PropertyImageService(IPropertyImageRepository propertyImageRepository) : IPropertyImageService
{
    private readonly IPropertyImageRepository _propertyImageRepository = propertyImageRepository;

    public async Task<int> UploadPropertyImage(ImagePropertyIn request, CancellationToken cancellationToken)
    {
		try
		{
            PropertyImage propertyImage = new();// = request.MapToEntity();
            return await _propertyImageRepository.AddAsync(propertyImage);
        }
		catch (Exception ex)
		{
            throw;
		}
    }
}