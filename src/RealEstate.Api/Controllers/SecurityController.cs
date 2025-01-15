using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Api.Dtos.Security;
using RealEstate.Api.Extensions.Security;
using RealEstate.Application.Common.Interfaces;
using RealEstate.Application.Dtos.Security;

namespace RealEstate.Api.Controllers;

/// <summary>
/// Resources about SecurityController
/// </summary>
/// <remarks>
/// Constructor method
/// </remarks>
/// <param name="securityService"></param>
[AllowAnonymous]
[ApiController]
[ApiExplorerSettings(IgnoreApi = false)]
[Produces("application/json")]
[Route("api/[controller]")]
public class SecurityController(ISecurityService securityService) : ControllerBase
{
    private readonly ISecurityService _securityService = securityService;

    /// <summary>
    /// Getting a JWT Token by Username
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Jwt Token</returns>
    /// <remarks>POST: api/Security/TokenIssue</remarks>
    /// <response code="200"><strong>Success</strong><br/>
    /// <ul>
    ///     <li><b>message:</b> Request description was doing.</li>
    ///     <li><b>result:</b> Results index.
    ///         <ul>
    ///             <li>Success => 0</li>
    ///             <li>Error => 1</li>
    ///             <li>NoRecords => 2</li>
    ///             <li>IsNotActive => 3</li>
    ///             <li>InvalidPassword => 4</li>
    ///         </ul>
    ///     </li>
    ///     <li><b>resultAsString:</b> <i>Result</i> description value </li>
    ///     <li><b>token:</b> Jwt base64</li>
    /// </ul>
    /// </response>
    /// <response code="400"><strong>BadRequest</strong></response>
    /// <response code="500"><strong>InternalError</strong></response>
    [ProducesResponseType(typeof(CredentialsOut), 200)]
    [ProducesResponseType(typeof(CredentialsOut), 400)]
    [ProducesResponseType(typeof(ValidationProblemDetails), 500)]
    [HttpPost("TokenIssue")]
    public async Task<IActionResult> TokenIssue([FromBody] CredentialsRequest request, CancellationToken cancellationToken)
    {
        try
        {
            CredentialsOut output = await _securityService.ValidateUser(request.MapToCredentialsIn(), cancellationToken);

            return Ok(output.MapToCredentialsResponse());
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = $"El usuario no existe, {ex.Message}" });
        }
    }

    /// <summary>
    /// Creating a new JWT Credentials 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Confirmation by registry</returns>
    /// <remarks>POST: api/Security/CredentialsCreate</remarks>
    /// <response code="200"><strong>Success</strong><br/>
    /// <ul>
    ///     <li><b>message:</b> Request description was doing.</li>
    ///     <li><b>result:</b> Results index.
    ///         <ul>
    ///             <li>Success => 0</li>
    ///             <li>Error => 1</li>
    ///             <li>NoRecords => 2</li>
    ///             <li>IsNotActive => 3</li>
    ///             <li>InvalidPassword => 4</li>
    ///         </ul>
    ///     </li>
    ///     <li><b>resultAsString:</b> <i>Result</i> description value.</li>
    ///     <li><b>token:</b> null</li>
    /// </ul>
    /// </response>
    /// <response code="400"><strong>BadRequest</strong></response>
    /// <response code="500"><strong>InternalError</strong></response>
    [ProducesResponseType(typeof(CredentialsOut), 200)]
    [ProducesResponseType(typeof(CredentialsOut), 400)]
    [ProducesResponseType(typeof(ValidationProblemDetails), 500)]
    [HttpPost("CredentialsCreate")]
    public async Task<IActionResult> CredentialsCreate([FromBody] CredentialsRequest request, CancellationToken cancellationToken)
    {
        try
        {
            CredentialsOut output = await _securityService.CreateUser(request.MapToCredentialsIn(), cancellationToken);

            return Ok(output.MapToCredentialsResponse());
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = $"El usuario no existe, {ex.Message}" });
        }
    }
}