namespace RealEstate.CrossCutting.Common;

public class BaseOut
{
    public required string Message { get; set; } = string.Empty;
    public required string Result { get; set; } = string.Empty;
    public required int StatusCode { set; get; }
}