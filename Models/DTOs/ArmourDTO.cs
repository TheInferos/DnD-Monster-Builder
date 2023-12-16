
namespace Monster_Builder_Web_API.Models.DTOs;

public class ArmourDTO
{
    public required string Name { get; set; }
    public int AC { get; set; }
    public int Cost { get; set; }
    public int Weight { get; set; }
    public int? Strength { get; set; }
    public bool Stealth { get; set; }
    public ArmourType Type { get; set; }
}