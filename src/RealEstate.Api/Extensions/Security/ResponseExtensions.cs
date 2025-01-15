using RealEstate.Api.Dtos.Security;
using RealEstate.Application.Dtos.Security;

namespace RealEstate.Api.Extensions.Security;

/// <summary>
/// 
/// </summary>
public static class ResponseExtensions
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="credentials"></param>
    /// <returns></returns>
    public static CredentialsResponse MapToCredentialsResponse(this CredentialsOut credentials)
    {
        return new()
        {
            Token = credentials.Token,
            Message = credentials.Message,
            Result = credentials.Result,
            StatusCode = credentials.StatusCode
        };
    }
}