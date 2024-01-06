using Microsoft.AspNetCore.Mvc;
using Monster_Builder_Web_API.Models;
using Monster_Builder_Web_API.Models.DTOs;
using Monster_Builder_Web_API.Models.Enum;
using Monster_Builder_Web_API.Services;

namespace Monster_Builder_Web_API.Controllers
{
    /// <summary>
    /// This is the API Controller for Armour. 
    /// This makes use of the armouryService for saved armours and will be imported
    /// </summary>
    [Route("api/[controller]")]
        public class ArmourController: ControllerBase
    {
        private IArmouryService _armouryService { get; init; }
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

        /// <summary>
        /// This API will make the armour.
        /// </summary>
        /// <param name="formData"> This uses the Armour DTO Object which shoiuld </param>
        /// <returns>an ID for accessing the armour</returns>
        [HttpPost("MakeArmour")]
        public ActionResult<string> MakeArmour([FromBody] ArmourDTO formData)
        {
            Armour armour = new Armour(formData.Name, formData.AC, formData.Cost, formData.Weight, formData.Strength, formData.Stealth, formData.Type);
            return armour.ID;
        }

        //TODO
        //[HttpPut()]
        //public IActionResult UpdateArmour([FromBody] ArmourDTO newArmour)
        //{
        //    throw new NotImplementedException();
        //}

    }
}
