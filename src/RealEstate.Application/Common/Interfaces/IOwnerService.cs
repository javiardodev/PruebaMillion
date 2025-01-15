using Microsoft.AspNetCore.Http;
using RealEstate.Application.Dtos.Owners;
using RealEstate.CrossCutting.Common;

namespace RealEstate.Application.Common.Interfaces;

public interface IOwnerService
{
    Task<OwnerListOut> GetFilteredOwners(OwnerFilterDto filters, CancellationToken cancellationToken);

    Task<OwnerRegistryOut> CreateOwner(OwnerRegistryIn registry, IFormFile photo, CancellationToken cancellationToken);
}