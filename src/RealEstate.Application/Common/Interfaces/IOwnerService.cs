using Microsoft.AspNetCore.Http;
using RealEstate.Application.Dtos.Owners;

namespace RealEstate.Application.Common.Interfaces;

public interface IOwnerService
{
    Task<OwnerListOut> QueryOwners(CancellationToken cancellationToken);//OwnerListIn

    Task<OwnerRegistryOut> CreateOwner(OwnerRegistryIn registry, IFormFile photo, CancellationToken cancellationToken);
}