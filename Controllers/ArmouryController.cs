using Microsoft.AspNetCore.Mvc;
using Monster_Builder;
using Monster_Builder_Web_API.Services;
using System.Text.Json;
using System.Threading;


namespace Monster_Builder_Web_API.Controllers
{
    [Route("api/[controller]")]
    public class ArmouryController
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
                string armorType = armour.Value.Type;
                if (!armorObject.ContainsKey(armorType))
                {
                    armorObject[armorType] = new List<string>();
                }
                armorObject[armorType].Add(armour.Key);
            }

            return armorObject;
        }
    }
}
