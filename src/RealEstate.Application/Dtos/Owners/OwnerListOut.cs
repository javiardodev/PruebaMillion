using RealEstate.CrossCutting.Common;
using RealEstate.Domain.Entities.Controller;

namespace RealEstate.Application.Dtos.Owners;

public class OwnerListOut : BaseOut
{
    public required List<Owner> ListOwners { get; set; }
}