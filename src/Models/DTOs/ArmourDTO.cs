using Monster_Builder_Web_API.Models.ENUM;
namespace Monster_Builder_Web_API.Models.DTOs;

/// <summary>
/// This is a simple class for passing data about the Armour. 
/// </summary>
public class ArmourDTO
{
    /// <summary>
    /// This is the planed name of the Armour
    /// </summary>
    public required string Name { get; set; }
    /// <summary>
    /// This is the base Armour Class for the object
    /// </summary>
    public int AC { get; set; }
    /// <summary>
    /// This is the cost in copper pieces for the Armour
    /// </summary>
    public int Cost { get; set; }
    /// <summary>
    /// This is the weight in lbs of the Armour
    /// </summary>
    public int Weight { get; set; }
    /// <summary>
    /// This is the mininium strength required to wear the armour with proficency
    /// </summary>
    public int Strength { get; set; }
    /// <summary>
    /// This is weather steath operates normally (True) or at disadvantage(false)
    /// </summary>
    public bool Stealth { get; set; }
    /// <summary>
    /// This is the type of armour that the user is wearing (Light Medium Heavy ect)
    /// </summary>
    public ArmourType Type { get; set; }
}