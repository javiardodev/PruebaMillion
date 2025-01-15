using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RealEstate.Application.Common.Interfaces;
using RealEstate.CrossCutting.Configuration.Jwt;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace RealEstate.Infrastructure.Services.Security;

public class JwtGenerator(IOptions<JwtCredentials> setting) : IJwtGenerator
{
    private readonly JwtCredentials _setting = setting.Value;
    public string GenerateJwt()
    {
        SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_setting.Secret));
        SigningCredentials credentials = new(securityKey, SecurityAlgorithms.HmacSha256);

        JwtSecurityToken token = new(
            issuer: _setting.Issuer,
            audience: _setting.Audience,
            expires: DateTime.Now.AddMinutes(_setting.ExpirationTime),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}