using RealEstate.CrossCutting.Common;

namespace RealEstate.Api.Dtos.Security;

/// <summary>
/// 
/// </summary>
//public record CredentialsRequest(string usernname, string password );
public class CredentialsRequest : BaseIn
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}