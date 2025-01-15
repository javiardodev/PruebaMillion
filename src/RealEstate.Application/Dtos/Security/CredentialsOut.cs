using RealEstate.CrossCutting.Common;

namespace RealEstate.Application.Dtos.Security;

public class CredentialsOut : BaseOut
{
    public string? Token { get; set; }
}