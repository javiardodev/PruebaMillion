using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using RealEstate.Application.Common.Interfaces;
using RealEstate.Application.Dtos.Security;
using RealEstate.CrossCutting.Common;
using RealEstate.Domain.Entities.Security.Jwt;
using System.Text;

namespace RealEstate.Application.Services;

public class SecurityService(ISecurityRepository securityRepository, IJwtGenerator jwtGenerator, ILogger<SecurityService> logger) : ISecurityService
{
    private readonly ISecurityRepository _securityRepository = securityRepository;
    private readonly IJwtGenerator _jwtGenerator = jwtGenerator;
    private readonly ILogger<SecurityService> _logger = logger;

    public async Task<CredentialsOut> ValidateUser(CredentialsIn userCredentials, CancellationToken cancellationToken)
    {
        try
        {
            User CredentialsDto = MapToEntity(userCredentials);
            User? dataUser = await _securityRepository.GetUserAsync(CredentialsDto, cancellationToken);

            if (!IsUserAllowedToRequestToken(dataUser))
            {
                _logger.LogInformation("El username '{Username}' esta inactivo o no existe", userCredentials.Username);
                return new CredentialsOut { Message = "El username esta inactivo o no existe", Result = nameof(Result.Error), StatusCode = StatusCodes.Status404NotFound };
            }

            bool isValid = PassCheck(dataUser, userCredentials);
            string? token = isValid ? _jwtGenerator.GenerateJwt() : null;

            string message = isValid ? "El token se genero correctamente" : "La password es incorrecta";
            string result = isValid ? nameof(Result.Success) : nameof(Result.InvalidPassword);

            int status = isValid ? StatusCodes.Status200OK : StatusCodes.Status401Unauthorized;

            _logger.LogInformation("{message}: '{Username}'", message, userCredentials.Username);
            return CreateCredentialsOut(message, result, token, status);
        }
        catch (Exception ex)
        {
            return new CredentialsOut { 
                Message = $"Ha ocurrido un error. {ex.Message}", 
                Result = nameof(Result.Error), 
                StatusCode = StatusCodes.Status500InternalServerError 
            };
        }
    }

    public async Task<CredentialsOut> CreateUser(CredentialsIn userCredentials, CancellationToken cancellationToken)
    {
        try
        {
            userCredentials.Password = GetEncryptPassword(userCredentials.Password);

            User CredentialsDto = MapToEntity(userCredentials);
            CredentialsDto.IsActive = true;
            CredentialsDto.CreatedAt = DateTime.UtcNow;

            await _securityRepository.AddUserAsync(CredentialsDto, cancellationToken);

            string message = "Creacion de usuario realizado exitosamente";
            _logger.LogInformation("{message}: '{Username}'", message, userCredentials.Username);

            return CreateCredentialsOut(message, nameof(Result.Success), null, StatusCodes.Status200OK);
        }
        catch (Exception ex)
        {
            return new CredentialsOut
            {
                Message = $"Ha ocurrido un error: {ex.Message}",
                Result = nameof(Result.Error),
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }
    }

    private static bool IsUserAllowedToRequestToken(User? user) => user is not null && user.IsActive;

    private static string GetEncryptPassword(string text)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(text);
        return Convert.ToBase64String(bytes);
    }

    private static bool PassCheck(User data, CredentialsIn user)
    {
        try
        {
            string encodedPassword = GetEncryptPassword(user.Password);

            return string.Equals(encodedPassword, data.Password, StringComparison.Ordinal);
        }
        catch (Exception)
        {
            return false;
        }
    }

    private static CredentialsOut CreateCredentialsOut(string message, string result, string? token, int status)
    {
        return new()
        {
            Message = message,
            Result = result,
            Token = token,
            StatusCode = status
        };
    }

    private static User MapToEntity(CredentialsIn access)
    {
        return new User()
        {
            Username = access.Username,
            Password = access.Password
        };
    }
}