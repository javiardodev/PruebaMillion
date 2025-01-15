using RealEstate.CrossCutting.Common;

namespace RealEstate.Api.Dtos.Owner;

/// <summary>
/// 
/// </summary>
public class OwnerRequest : BaseIn
{
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string? Photo { get; set; } = string.Empty;
    public DateTime? Birthday { get; set; }
}