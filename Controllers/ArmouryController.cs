using Microsoft.AspNetCore.Mvc;
using Monster_Builder_Web_API.Services;


namespace Monster_Builder_Web_API.Controllers;

[Route("api/[controller]")]
public class ArmouryController
{
    ArmouryService _armouryService;
    public ArmouryController(ArmouryService armouryService)
    {
        _armouryService = armouryService;
    }

    [HttpGet("AllArmours")]
    public Dictionary<string, List<string>> GetArmour()
    {

        var armorObject = new Dictionary<string, List<string>> { };

        foreach (var armour in _armouryService.GetAllArmour())
        {
            string armorType = armour.Type;
            if (!armorObject.ContainsKey(armorType))
            {
                armorObject[armorType] = new List<string>();
            }
            armorObject[armorType].Add(armour.Name);
        }

        return armorObject;
    }
}
