using RealEstate.CrossCutting.Common;

namespace RealEstate.Application.Dtos.Security;

public class CredentialsIn : BaseIn
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}