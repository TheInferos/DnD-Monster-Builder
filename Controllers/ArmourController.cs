using Microsoft.AspNetCore.Mvc;
using Monster_Builder_Web_API.Services;
using Monster_Builder_Web_API.Models.DTOs;
using Monster_Builder_Web_API.Models.Exceptions;

namespace Monster_Builder_Web_API.Controllers;

[Route("api/[controller]")]
public class ArmourController : ControllerBase
{
    private readonly IArmourService _armourService;
    public ArmourController(IArmourService armourService) {
        _armourService = armourService;
    }

    [HttpGet("BasicArmour")]
    public IActionResult GetArmour(string name)
    {
        try
        {
            var result = _armourService.GetArmourByName(name);
            return Ok(result);
        }
        catch (Exception ex)
        {
            if (ex is KeyNotFoundException)
            {
                return NotFound();
            }
            throw;
        }
    }

    [HttpPost("MakeArmour")]
    public IActionResult MakeArmour([FromBody] ArmourDTO newArmour)
    {
        try
        {
            var v = _armourService.AddNewArmour(newArmour);
            return Ok(v);
        }
        catch (Exception ex)
        {
            if(ex is ConflictException)
            {
                return Conflict(false);
            }
            else if (ex is ValidationException)
            {
                return BadRequest(ex.Message);
            }
            throw;
        }
    }
}
