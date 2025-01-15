using RealEstate.Domain.Entities.Controller;

namespace RealEstate.Application.Common.Interfaces;

public interface IPropertyImageRepository
{
    Task<int> AddAsync(PropertyImage propertyImage);
}