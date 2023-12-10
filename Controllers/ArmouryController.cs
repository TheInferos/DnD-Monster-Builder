using Microsoft.AspNetCore.Mvc;
using Monster_Builder_Web_API.Models;


namespace Monster_Builder_Web_API.Controllers
{
    [Route("api/[controller]")]
    public class ArmouryController
    {
        [HttpGet("AllArmours")]
        public Dictionary<string, List<string>> getArmour()
        { 

            var armorObject = new Dictionary<string, List<string>>
            {
                //{ "Natural", new List<string> { } },
                //{ "Light", new List<string> { } },
                //{ "Medium", new List<string> {  } },
                //{ "Heavy", new List<string> { } }
            };
            ArmouryManager ArmourList = new ArmouryManager();
            ArmourList.LoadBaseArmours();

            foreach(var armour in ArmourList.armours)
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
