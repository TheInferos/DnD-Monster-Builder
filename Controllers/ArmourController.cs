using Microsoft.AspNetCore.Mvc;
using Armours;
using Monster_Builder_Web_API.Services;
using Monster_Builder_Web_API.Models;

namespace Monster_Builder_Web_API.Controllers
{
        [Route("api/[controller]")]
        public class ArmourController: ControllerBase
    {
        private readonly ArmouryService _armouryService;
        /// <summary>
        /// Returns the Armour Object by the name provided
        /// </summary>
        /// <returns> Json of the Armour Object</returns>
        [HttpGet("{name}")]
        public ActionResult<string> getArmour(string name)
        {
            try
            {
                Armour armour = _armouryService.GetArmourByName(name);
                return Ok(armour);
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

        //Turn into a [FromBody] ArmourDTO newArmour
        [HttpPost("MakeArmour")]
        public ActionResult<string> MakeArmour(string name, int ac, int cost, int strength, int weight, bool stealth, ArmourType type)
        {
            Armour armour = new Armour(name, ac, cost, weight, strength, stealth, type);
            return armour.ToString();
        }

        //TODO
        //[HttpPut()]
        //public IActionResult UpdateArmour([FromBody] ArmourDTO newArmour)
        //{
        //    throw new NotImplementedException();
        //}

    }
}
