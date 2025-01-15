using RealEstate.Application.Common.Interfaces;
using RealEstate.Domain.Entities.Controller;
using RealEstate.Infrastructure.Data;

namespace RealEstate.Infrastructure.Repositories;

public class PropertyImageRepository(ApiDbContext context) : IPropertyImageRepository
{
    private readonly ApiDbContext _context = context;

    public async Task<int> AddAsync(PropertyImage propertyImage)
    {
        _context.PropertyImages.Add(propertyImage);
        await _context.SaveChangesAsync();

        return propertyImage.Id;
    }
}