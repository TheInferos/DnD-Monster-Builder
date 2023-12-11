using Microsoft.AspNetCore.Mvc;
using Monster_Builder_Web_API.Services;


namespace Monster_Builder_Web_API.Controllers;

[Route("api/[controller]")]
public class ArmouryController
{
    IArmourService _armourService;
    public ArmouryController(IArmourService armourService)
    {
        _armourService = armourService;
    }

    [HttpGet("AllArmours")]
    public Dictionary<string, List<string>> GetArmour()
    {

        var armorObject = new Dictionary<string, List<string>> { };

        foreach (var armour in _armourService.GetAllArmour())
        {
            string armorType = armour.Type.ToString();
            if (!armorObject.TryGetValue(armorType, out List<string>? value))
            {
                value = new List<string>();
                armorObject[armorType] = value;
            }
            value.Add(armour.Name);
        }
        return armorObject;
    }
}
