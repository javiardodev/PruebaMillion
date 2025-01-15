using RealEstate.CrossCutting.Common;

namespace RealEstate.Api.Dtos.Owner;

/// <summary>
/// Define Dto for show list owners
/// </summary>
public class OwnerListResponse : BaseOut
{
    /// <summary>
    /// Collection of Owners in db
    /// </summary>
    public List<OwnerDto> ListOwners { get; set; }
}