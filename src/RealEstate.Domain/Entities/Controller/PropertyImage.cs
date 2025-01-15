namespace RealEstate.Domain.Entities.Controller;

public class PropertyImage
{
    public int Id { get; set; }
    public int IdProperty { get; set; }
    public string File { get; set; } = string.Empty;
    public bool Enabled { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public virtual Property Property { get; set; }
}