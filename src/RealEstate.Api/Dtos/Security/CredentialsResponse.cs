using RealEstate.CrossCutting.Common;

namespace RealEstate.Api.Dtos.Security;

public class CredentialsResponse : BaseOut
{
    public string? Token { get; set; }
}