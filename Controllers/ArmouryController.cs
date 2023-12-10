using Microsoft.AspNetCore.Mvc;
using Monster_Builder;
using Monster_Builder_Web_API.Models;
using System.Text.Json;
using System.Threading;


namespace Monster_Builder_Web_API.Controllers
{
    [Route("api/[controller]")]
    public class ArmouryController
    {
        [HttpGet("AllArmours")]
        public Dictionary<string, List<string>> GetArmour()
        {

            var armorObject = new Dictionary<string, List<string>> { };
            ArmouryManager ArmourList = new ArmouryManager();
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

        [HttpPost("SaveMonster")]
        public void SaveMonster(string name)
        {
            ArmouryManager Armoury = new ArmouryManager();
            Monster monster = new Monster(name, 3);
            Armoury.AddMonster(monster);
            Armoury.SaveMonsters("Data/Monsters.json");
        }

        [HttpGet("GetMonster")]
        public string GetMonster(string name)
        {
            ArmouryManager Armoury = new ArmouryManager();
            return JsonSerializer.Serialize(Armoury.monsters[name]);
        }
    }
}
