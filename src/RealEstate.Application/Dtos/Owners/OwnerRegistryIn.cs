using RealEstate.CrossCutting.Common;

namespace RealEstate.Application.Dtos.Owners;

public class OwnerRegistryIn : BaseIn
{
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string? Photo { get; set; } = string.Empty;
    public DateTime? Birthday { get; set; }
}
