using Armours;
using Monster_Builder;
using Monster_Builder_Web_API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Monster_Builder_Web_API.Models.DTOs;

namespace Monster_Builder_Web_API.Controllers
{
    [Route("api/[controller]")]
    public class MonsterController : ControllerBase
    {
        BeastiaryService _beastiaryService;
        ArmouryService _armouryService;
        public MonsterController(BeastiaryService beastiaryService, ArmouryService armouryService) 
        {
            _beastiaryService = beastiaryService;
            _armouryService = armouryService;
        }

        //TODO Change To Exception onm return error, change to Ok(monster)
        [HttpPost("MakeMonster")]
        public ActionResult<string> MakeMonster([FromBody] InitialMonsterRequestDTO formData)
        {
            if (string.IsNullOrEmpty(formData.Name) || formData.CR < 0)
            {
                return "{\"error\": \"Name and/ or challenge rating not provided\"}";
            }
            Monster monster = new Monster(formData.Name, formData.CR);
            _beastiaryService.AddMonster(monster);
            return JsonSerializer.Serialize(monster);
        }

        [HttpPost("{id}/GiveWeapon")]
        public ActionResult<string> AddWeapon(string weapon, string id)
        {
            Monster monster = _beastiaryService.GetMonsterByID(id);
            monster.AddWeapon(new Weapon(weapon));
            return JsonSerializer.Serialize(monster);
        }

        [HttpPost("{id}/SwitchArmour")]
        public ActionResult<string> changeArmour(string armourString,string id)
        {
            Monster monster = _beastiaryService.GetMonsterByID(id);
            Armour armour = _armouryService.GetArmourByName(armourString);
            monster.ChangeArmour(armour);
            return JsonSerializer.Serialize(monster);
        }

        [HttpPost("{id}/ChangeStats")]
        public ActionResult<string> setStats(int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma, string id)
        {
            Monster monster = _beastiaryService.GetMonsterByID(id);
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