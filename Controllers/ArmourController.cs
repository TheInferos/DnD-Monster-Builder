using Microsoft.AspNetCore.Mvc;
using Armours;
using Monster_Builder_Web_API.Services;
using Monster_Builder_Web_API.Models.DTOs;
using Monster_Builder_Web_API.Models.Exceptions;

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
    public Task<IActionResult> MakeArmour([FromBody] ArmourDTO newArmour)
    {
        try
        {
            //return StatusCodeResult(200);
            var v = _armourService.AddNewArmour(newArmour);
            return Ok(v);
        }
        catch (Exception ex)
        {
            if(ex is ConflictException)
            {
                return this.BadRequest("");
            }
        }
        return true;
    }
}
