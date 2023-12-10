using Armours;
using Microsoft.AspNetCore.Mvc;
using Monster_Builder;
using Statlines;
using System.Text.Json;
using System.Threading;

namespace Monster_Builder_Web_API.Controllers
{
    [Route("api/[controller]")]
    public class MonsterController : ControllerBase
    {
        // GET api/monster
        [HttpGet]
        public ActionResult<string> GetSystemMonster()
        {
            Monster monster = new Monster("Guard", 3);
            return monster.ToString();
        }

        [HttpPost("MakeMonster")]
        public ActionResult<string> MakeMonster([FromBody] InitialMonsterRequest formData)
        {
            if (string.IsNullOrEmpty(formData.Name) || formData.CR < 0)
            {
                return "{\"error\": \"Name and/ or challenge rating not provided\"}";
            }
            Monster monster = new Monster(formData.Name, formData.CR);
            return JsonSerializer.Serialize(monster);
        }

        [HttpPost("GiveWeapon")]
        public ActionResult<string> AddWeapon(string weapon)
        {
            Monster monster = new Monster("Guard", 3);
            monster.addWeapon(new Weapon(weapon));
            return monster.ToString();
        }

        [HttpPost("SwitchArmour")]
        public ActionResult<string> changeArmour(string armour)
        {
            Monster monster = new Monster("Guard", 3);
            monster.changeArmour(new Armour(armour));
            return JsonSerializer.Serialize(monster);
        }

        [HttpPost("ChangeStats")]
        public ActionResult<string> setStats(int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma)
        {
            Monster monster = new Monster("Guard", 3);
            monster.Stats.changeStats(strength, dexterity, constitution, intelligence, wisdom, charisma);
            return monster.ToString();
        }


        //// GET api/monsters/{id}
        //[HttpGet("{id}")]
        //public ActionResult GetMonster(int id)
        //{
        //    // Implementation for getting a specific monster by id
        //}

        //// POST api/monsters
        //[HttpPost]
        //public ActionResult CreateMonster([FromBody] Monster monster)
        //{
        //    // Implementation for creating a new monster
        //}

        //// Other actions for updating, deleting, etc.
    }
}