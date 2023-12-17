using Microsoft.AspNetCore.Mvc;
using Weapons;
using Monster_Builder_Web_API.Models;
using Monster_Builder_Web_API.Services;
using System.Text.Json;
using System.Threading;


namespace Monster_Builder_Web_API.Controllers
{
    [Route("api/[controller]")]
    public class ArmouryController : ControllerBase
    {
        ArmouryService _armouryService;
        public ArmouryController(ArmouryService armouryService)
        {
            _armouryService = armouryService;
        }

        [HttpGet("GetArmours")]
        public Dictionary<string, List<string>> GetArmours()
        {

            var armorObject = new Dictionary<string, List<string>> { };
            //TODO Clean this up should be returning as a dictionary based on Armour Type
            foreach (var armour in _armouryService.armours)
            {
                var armorTypeString = Enum.GetName(typeof(ArmourType), armour.Value.Type);
                if (!armorObject.ContainsKey(armorTypeString))
                {
                    armorObject[armorTypeString] = new List<string>();
                }
                armorObject[armorTypeString].Add(armour.Key);
            }

            return armorObject;
        }
    }
}
