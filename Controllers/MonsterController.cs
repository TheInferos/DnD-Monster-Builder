using Armours;
using Microsoft.AspNetCore.Mvc;
using Monster_Builder;
using Statlines;
using System.Text.Json;

namespace Monster_Builder_Web_API.Controllers
{
    [Route("api/[controller]")]
    public class MonstersController : ControllerBase
    {
        // GET api/monsters
        [HttpGet]
        public ActionResult<string> GetSystemMonster()
        {
            Monster Guard = new Monster("Guard", 3);
            return Guard.ToString();
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
            Monster Guard = new Monster("Guard", 3);
            Guard.addWeapon(new Weapon(weapon));
            return Guard.ToString();
        }

        [HttpPost("SwitchArmour")]
        public ActionResult<string> changeArmour(string armour)
        {
            Monster Guard = new Monster("Guard", 3);
            Guard.changeArmour(new Armour(armour));
            return Guard.ToString();
        }

        [HttpPost("ChangeStats")]
        public ActionResult<string> setStats(int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma)
        {
            Monster Guard = new Monster("Guard", 3);
            Guard.Stats.changeStats(strength, dexterity, constitution, intelligence, wisdom, charisma);
            return Guard.ToString();
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