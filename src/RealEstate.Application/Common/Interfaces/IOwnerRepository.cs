using RealEstate.Domain.Entities.Controller;

namespace RealEstate.Application.Common.Interfaces;

public interface IOwnerRepository
{
    Task<List<Owner>> GetAllAsync(CancellationToken cancellationToken);
    Task<int> AddItem(Owner data, CancellationToken cancellationToken);
}