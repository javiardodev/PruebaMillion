using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Api.Dtos.Owner;
using RealEstate.Api.Extensions.Owner;
using RealEstate.Application.Common.Interfaces;
using RealEstate.Application.Dtos.Owners;
using RealEstate.Application.Services;

namespace RealEstate.Api.Controllers
{
    /// <summary>
    /// Resources about SecurityController
    /// </summary>
    /// <remarks>
    /// Constructor method
    /// </remarks>
    /// <param name="ownerService"></param>
    /// <param name="webHostEnvironment"></param>
    [AllowAnonymous]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = false)]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class OwnerController(IOwnerService ownerService) : ControllerBase
    {
        private readonly IOwnerService _ownerService = ownerService;

        // GET: api/<OwnerController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="photo"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Consumes("multipart/form-data")]
        [HttpPost("Registry")]
        public async Task<IActionResult> Post([FromForm] OwnerRequest request, IFormFile photo, CancellationToken cancellationToken)
        {
            try
            {
                OwnerRegistryOut output = await _ownerService.CreateOwner(request.MapToRegistryIn(), photo ,cancellationToken);
                return Ok(output.MapToResponse());
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = $"El usuario no existe, {ex.Message}" });
            }
        }
    }
}
