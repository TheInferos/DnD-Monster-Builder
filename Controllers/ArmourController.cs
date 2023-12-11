using Microsoft.AspNetCore.Mvc;
using Armours;
using Monster_Builder_Web_API.Services;
using Monster_Builder_Web_API.Models;

namespace Monster_Builder_Web_API.Controllers;

[Route("api/[controller]")]
public class ArmourController
{
    private readonly IArmourService _armourService;
    public ArmourController(IArmourService armourService) {
        _armourService = armourService;
    }

    [HttpGet("BasicArmour")]
    public ActionResult<Armour> GetArmour(string name)
    {
        return _armourService.GetArmourByName(name);
    }

    [HttpPost("MakeArmour")]
    public ActionResult<bool> MakeArmour([FromBody] ArmourDTO newArmour)
    {
        return _armourService.AddNewArmour(newArmour);
    }
}
