namespace Monster_Builder_Web_API.Models;

//I used a DTO because there was a fair bit of logic in the Armour class
public class ArmourDTO
{
    public required string Name {  get; set; }
    public int AC { get; set; }
    public int Cost {  get; set; }
    public int Weight {  get; set; }
    public int? Strength { get; set; }
    public bool Stealth { get; set; }
    public ArmourType Type { get; set; }
}
