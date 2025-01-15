using RealEstate.CrossCutting.Common;

namespace RealEstate.Api.Dtos.Security;

/// <summary>
/// 
/// </summary>
public class CredentialsResponse : BaseOut
{
    public string? Token { get; set; }
}