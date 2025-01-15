using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using RealEstate.Application.Common.Interfaces;
using RealEstate.Application.Dtos.Owners;
using RealEstate.Application.Extensions.Owners;
using RealEstate.CrossCutting.Common;
using RealEstate.Domain.Entities.Controller;

namespace RealEstate.Application.Services;

public class OwnerService(IOwnerRepository ownerRepository, ILogger<OwnerService> logger, IWebHostEnvironment webHostEnvironment) : IOwnerService
{
    private readonly IOwnerRepository _ownerRepository = ownerRepository;
    private readonly ILogger<OwnerService> _logger = logger;
    private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;

    public async Task<OwnerRegistryOut> CreateOwner(OwnerRegistryIn registry, IFormFile photo, CancellationToken cancellationToken)
    {
        try
        {
            Owner data = registry.MapToEntity();
            data.IsDeleted = false;
            data.CreatedAt = DateTime.UtcNow;

            if (photo.Length > 0 && IsValidImageExtension(photo.FileName))
            {
                string path = UploadImageOwner(photo);

                data.Photo = path + photo.FileName;
            }

            int idOwner = await _ownerRepository.AddItem(data, cancellationToken);

            OwnerRegistryOut output = new()
            {
                Id = idOwner,
                Message = $"Propietario registrado con exito. ID: {idOwner}",
                Result = nameof(Result.Success),
                StatusCode = StatusCodes.Status200OK
            };

            _logger.LogInformation("Se registro exitosamente la informacion del propietario: ID '{idOwner}' con datos {@data}", idOwner, data);

            return output;
        }
        catch (Exception ex)
        {
            return new OwnerRegistryOut
            {
                Message = $"Ha ocurrido un error. {ex.Message}",
                Result = nameof(Result.Error),
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }
    }

    public async Task<OwnerListOut> QueryOwners(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    private string UploadImageOwner(IFormFile photo)
    {
        string path = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", "owners");

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        using FileStream filestream = File.Create(path + photo.FileName);
        photo.CopyTo(filestream);
        filestream.Flush();

        return path;
    }
    private static bool IsValidImageExtension(string fileName)
    {
        var fileExtensions = new string[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".tiff", ".webp" };
        var fileExtension = Path.GetExtension(fileName).ToLower();

        return fileExtensions.Contains(fileExtension);
    }

}