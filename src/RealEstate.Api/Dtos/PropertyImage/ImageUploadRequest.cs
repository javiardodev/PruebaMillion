using RealEstate.CrossCutting.Common;

namespace RealEstate.Api.Dtos.PropertyImage;

/// <summary>
/// 
/// </summary>
public class ImageUploadRequest : BaseOut
{
    public string File { get; set; } = string.Empty;
    public bool Enabled { get; set; }
}
