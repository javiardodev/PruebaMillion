using System;

namespace RealEstate.Domain.Entities.Controller;

public class Owner
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string? Photo { get; set; } = string.Empty;
    public DateTime? Birthday { get; set; } //'1900-01-01'
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; } //'1900-01-01 00:00:00' NOT NULL,
    public DateTime? UpdatedAt { get; set; }
}