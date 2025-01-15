namespace RealEstate.Domain.Entities.Controller;

public class PropertyTrace
{
    public int IdPropertyTrace { get; set; }
    public DateTime DateSale { get; set; }
    public string Name { get; set; } = string.Empty;
    public float Value { get; set; }
    public float Tax { get; set; }
    public int IdProperty { get; set; }
    public virtual Property Property { get; set; }
}
