using Microsoft.AspNetCore.Mvc;
using Monster_Builder_Web_API.src.Services;


namespace Monster_Builder_Web_API.src.Controllers
{
    /// <summary>
    /// This is the controller for all Weapons and Armours.
    /// They are collected together into a single Armoury which can hold them all.
    /// </summary>
    [Route("api/[controller]")]
    public class ArmouryController : ControllerBase
    {
        private IArmouryService ArmouryService { get; init; }
        /// <summary>
        /// This is the constructor for creating the ArmouryController.
        /// </summary>
        /// <param name="armouryService"> It takes in the armoury service which contains the repositories.</param>
        public ArmouryController(IArmouryService armouryService)
        {
            ArmouryService = armouryService;
        }
        /// <summary>
        /// This will get all the names of the armour. This does not return the ID's (used by the webpage to display items)
        /// </summary>
        /// <returns>a String List of Armour Names.</returns>
        [HttpGet("GetArmours")]
        public Dictionary<string, List<string>> GetArmours()
        {
            return ArmouryService.GetArmourNames();
        }
    }
}
