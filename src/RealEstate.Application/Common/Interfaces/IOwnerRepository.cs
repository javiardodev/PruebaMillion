using RealEstate.CrossCutting.Common;
using RealEstate.Domain.Entities.Controller;

namespace RealEstate.Application.Common.Interfaces;

public interface IOwnerRepository
{
    Task<IEnumerable<Owner>> GetFilteredOwnersAsync(OwnerFilterDto filters, CancellationToken cancellationToken);
    Task<int> AddItem(Owner data, CancellationToken cancellationToken);
}