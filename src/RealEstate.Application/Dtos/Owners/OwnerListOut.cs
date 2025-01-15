using RealEstate.Application.Dtos.Owner;
using RealEstate.CrossCutting.Common;

namespace RealEstate.Application.Dtos.Owners;

public class OwnerListOut : BaseOut
{
    public required List<OwnerDto> ListOwners { get; set; } = new List<OwnerDto>();
}