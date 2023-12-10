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

        [HttpGet("AllArmours")]
        public Dictionary<string, List<string>> GetArmour()
        {

            var armorObject = new Dictionary<string, List<string>> { };
            ArmouryService ArmourList = new ArmouryService();
            ArmourList.LoadBaseArmours();

            foreach (var armour in ArmourList.armours)
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
