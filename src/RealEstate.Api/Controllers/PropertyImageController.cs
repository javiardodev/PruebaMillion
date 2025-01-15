using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Api.Dtos.PropertyImage;
using RealEstate.Application.Common.Interfaces;
using RealEstate.Application.Dtos.PropertyImage;

namespace RealEstate.Api.Controllers;

/// <summary>
/// 
/// </summary>
/// <param name="propertyImageService"></param>
[AllowAnonymous]
[ApiController]
[ApiExplorerSettings(IgnoreApi = false)]
[Produces("application/json")]
[Route("api/[controller]")]
public class PropertyImageController(IPropertyImageService propertyImageService) : ControllerBase
{
    private readonly IPropertyImageService _propertyImageService = propertyImageService;
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("Upload")]
    public async Task<IActionResult> Post([FromBody] ImageUploadRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var output = await _propertyImageService.UploadPropertyImage(new ImagePropertyIn(), cancellationToken);
            return Ok(output); 
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = $"Se presento error al listar informacion, {ex.Message}" });
        }
    }
}
