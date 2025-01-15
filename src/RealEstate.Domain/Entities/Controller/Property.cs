namespace RealEstate.Domain.Entities.Controller;

public class Property
{
    public int IdProperty { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public int Price { get; set; }
    public string CodeInternal { get; set; } = string.Empty;
    public int Year { get; set; }
    public int IdOwner { get; set; }
    public ICollection<PropertyImage> PropertyImages { get; set; }
    public ICollection<PropertyTrace> PropertyTraces { get; set; }
}